using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float RotateSpeed = 1.5f;
    public float MoveSpeed = 7.0f;

    Vector3 Pos_Camera = Vector2.zero;
    Vector3 Rot_Camera = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        //カーソルみえなくするやつ
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        //初期位置
        Pos_Camera = this.player.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            Pos_Camera += transform.forward * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Pos_Camera -= transform.forward * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Pos_Camera += transform.right * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Pos_Camera -= transform.right * MoveSpeed * Time.deltaTime;
        }


        transform.position = Pos_Camera;



        Rot_Camera.x -= Input.GetAxis("Mouse Y") * RotateSpeed;
        Rot_Camera.y += Input.GetAxis("Mouse X") * RotateSpeed;

        transform.rotation = Quaternion.Euler(Rot_Camera.x, Rot_Camera.y, 0);

    }
}
