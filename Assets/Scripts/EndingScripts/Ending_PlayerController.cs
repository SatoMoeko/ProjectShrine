using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ending_PlayerController : MonoBehaviour
{
    //endingのテスト用
    //途中

    public float moveSpeed = 3;
    Rigidbody rb;

    float keyHorizontal;
    float keyVertical;

    Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }


    void Update()
    {

    }

    void KeyChecked()
    {
        keyHorizontal = Input.GetAxisRaw("Horizontal");
        keyVertical = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
    }
}
