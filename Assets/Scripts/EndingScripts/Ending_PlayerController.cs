using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//ending内での動作テスト用
//作成途中

public class Ending_PlayerController : MonoBehaviour
{
    //オブジェクト
    public Transform orientation;

    //コンポーネント
    Rigidbody rb;

    //移動関係
    Vector3 velocity; //移動速度
    Vector3 moveInput; //移動の入力値
    Vector3 moveDirection; //実際の移動距離
    public float walkSpeed = 3f; //歩行速度

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //回転を制限
        rb.freezeRotation = true;
    }

    void Update()
    {
    }


    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //入力値
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //向いている方向
        moveDirection = orientation.forward * moveInput.z + orientation.right * moveInput.x;

        //移動速度の計算
        var clampedInput = Vector3.ClampMagnitude(moveDirection, 1f);
        velocity = clampedInput * walkSpeed;

        //移動速度の制限
        velocity -= rb.velocity;
        velocity = new Vector3(Mathf.Clamp(velocity.x, -walkSpeed, walkSpeed), 0f, Mathf.Clamp(velocity.z, -walkSpeed, walkSpeed));

        //移動処理
        rb.AddForce(rb.mass * velocity / Time.fixedDeltaTime, ForceMode.Force);
    }

    //orientation：プレイヤー視線に合わせて体の向きを変える
    void LineOfSight()
    {
        transform.rotation = orientation.rotation;
    }

}
