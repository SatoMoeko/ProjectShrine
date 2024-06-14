using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Stalker : MonoBehaviour
{
    //親オブジェクト
    GameObject player;
    //ルートオブジェクト
    GameObject playerRoot;

    //親オブジェクトの位置
    Transform target;
    //ルートのrigidbody
    Rigidbody rootRb;


    //追従位置
    Vector3 offset;

    //親があるかどうか
    bool haveParent;

    private void Start()
    {
        offset = new Vector3(0, 0, -2);
    }
    private void Update()
    {
        //親がない時
        if (!haveParent)
        {
            if (transform.parent.gameObject)
            {
                //親オブジェクトの座標を取得
                player = transform.parent.gameObject;
                target = player.transform;

                //root取得
                playerRoot = transform.root.gameObject;
                rootRb = playerRoot.GetComponent<Rigidbody>();

                //親オブジェクトから0,0,2の距離で追従させる
                transform.position = target.position + offset;
                haveParent = true;
            }
        }
        //親ある
        else
        {
            //追従し、歩いている間はうしろから足音がする
            if (!rootRb.IsSleeping())
            {
                //動いているとき
            }
            else
            {
                //うごいてないとき
            }

        }
    }
}
