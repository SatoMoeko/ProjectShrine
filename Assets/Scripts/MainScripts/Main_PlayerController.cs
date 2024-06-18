using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_PlayerController : MonoBehaviour
{
    Vector3 moveDirection;
    Rigidbody rb;
    AudioSource audioSource;

    float HorizontalInput;
    float VerticalInput;

    public Transform orientation;

    public StageGenerator stageGenerator;
    public Main_GameController gameController;

    public float moveSpeed;
    public float groundDrag;

    public float playerheight;
    public LayerMask Ground;
    bool grounded;

    int point;



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
        audioSource = GetComponent<AudioSource>();

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

        if (Input.GetKey(KeyCode.W))
        {
            audioSource.PlayOneShot(audioSource.clip);

        }

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


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DefaultSushi"))
        {
            GameObject stage = other.gameObject.transform.parent.gameObject;
            GameObject sushi = stage.transform.Find("Inari").gameObject;
            Debug.Log(sushi.activeSelf);

            if (sushi.activeSelf == true)
            {
                point = 0;
            }
            if (sushi.activeSelf == false)
            {
                point += 1;
            }
        }
        if (other.CompareTag("OtherSushi"))
        {
            GameObject stage = other.gameObject.transform.parent.gameObject;
            GameObject sushi = stage.transform.Find("Inari").gameObject;

            if (sushi.activeSelf == true)
            {
                point += 1;
            }
            if (sushi.activeSelf == false)
            {
                point = 0;
            }
        }
        //道案内看板文字表示変更
        if (other.CompareTag("Paper"))
        {
            GameObject stage = other.gameObject.transform.parent.gameObject;
            GameObject papers = stage.transform.Find("TurnPapers").gameObject;

            if (point == 0)
            {
                GameObject paper = papers.transform.Find("5nomine").gameObject;
                paper.SetActive(true);
            }
            if (point == 1)
            {
                GameObject paper = papers.transform.Find("4nomine").gameObject;
                paper.SetActive(true);
            }
            if (point == 2)
            {
                GameObject paper = papers.transform.Find("3nomine").gameObject;
                paper.SetActive(true);
            }
            if (point == 3)
            {
                GameObject paper = papers.transform.Find("2nomine").gameObject;
                paper.SetActive(true);
            }
            if (point == 4)
            {
                GameObject paper = papers.transform.Find("1nomine").gameObject;
                paper.SetActive(true);
            }
        }

    }

}
