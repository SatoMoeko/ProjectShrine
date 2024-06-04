using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_Camera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    // public Transform playerRotation;
    public Transform CamHolder;

    float xRotation;
    float yRotation;


    void Update()
    {
        LookAround();
        CursorLocked();
    }

    public void LookAround()
    {
        //y軸起点では360度見渡し可能
        //マウス入力取得
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        //y方向のみ視点に上限
        xRotation = Mathf.Clamp(xRotation, -60, 60);
        yRotation = Mathf.Clamp(yRotation, -135, 135);

        //カメラとプレイヤーの向きを動かす
        CamHolder.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        // playerRotation.rotation = Quaternion.Euler(0, yRotation, 0);

    }

    public void CursorLocked()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //escでマウスポインタ非固定、可視化
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetMouseButton(0))
        {
            //左クリックでマウスポインタ中央固定、不可視化
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
