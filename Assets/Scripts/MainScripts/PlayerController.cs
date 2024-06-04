using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float RotateSpeed = 1.5f;
    public float MoveSpeed = 7.0f;

    Vector3 Pos_Player = Vector2.zero;
    Vector3 Rot_Player = Vector2.zero;

    public GameObject sushi;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Pos_Player += transform.forward * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Pos_Player -= transform.forward * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Pos_Player += transform.right * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Pos_Player -= transform.right * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            sushi.SetActive(true);
        }

        transform.position = Pos_Player;


        Rot_Player.x -= Input.GetAxis("Mouse Y") * RotateSpeed;
        Rot_Player.y += Input.GetAxis("Mouse X") * RotateSpeed;

        transform.rotation = Quaternion.Euler(Rot_Player.x, Rot_Player.y, 0);

    }
}
