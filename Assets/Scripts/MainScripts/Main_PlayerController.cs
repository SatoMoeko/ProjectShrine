using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_PlayerController : MonoBehaviour
{
    const int DefaultPoint = 0;

    Vector3 moveDirection;
    Rigidbody rb;

    int point = DefaultPoint;
    float HorizontalInput;
    float VerticalInput;

    public Transform orientation;

    public StageGenerator stageGenerator;
    public GameObject sushi;

    public float moveSpeed;
    public float groundDrag;

    public float playerheight;
    public LayerMask Ground;
    bool grounded;

    public int Point()
    {
        return point;
    }

    // Start is called before the first frame update
    void Start()
    {
        //必要なコンポーネントを自動取得
        stageGenerator = GetComponent<StageGenerator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        //動き処理
        //地面と接しているかを判断
        grounded = Physics.Raycast(transform.position, Vector3.down, playerheight * 0.5f + 0.2f, Ground);

        //接している場合は、設定した減速値を代入しプレイヤーを滑りにくくする
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        ProcessInput();
        SpeedControl();

        //ポイント処理
        //いまプレイヤーがいるステージがdefaultのとき
        // if (stageGenerator.NextStage() == 0)
        //{
        //    if (sushi.activeInHierarchy)
        //    {
        //        point = 0;
        //    }
        //   else
        //   {
        //        point += 1;
        //    }
        //   }
        //   else //ステージがそれ以外のとき
        //   {
        //      if (sushi.activeInHierarchy)
        //      {
        //          point += 1;
        //      }
        //      else
        //      {
        //         point += 0;
        //     }
        //  }
    }

    void FixedUpdate()
    {
        movePlayer();
    }

    void ProcessInput()
    {
        //入力を取得
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }


    void movePlayer()
    {
        //向いている方向に進む
        moveDirection = orientation.forward * VerticalInput + orientation.right * HorizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }


    void SpeedControl()
    {
        //プレイヤーのスピードを制限
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

}
