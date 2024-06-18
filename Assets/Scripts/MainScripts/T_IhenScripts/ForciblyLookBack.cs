using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/*
未完成
※完成しなければ実装しない

強制的に振り返らせる
オブジェクトにプレイヤーのレイが当たった時、背後へ視線誘導する
*/
public class ForciblyLookBack : MonoBehaviour
{
    //視線誘導されるオブジェクト:プレイヤーの目線
    public GameObject player;
    public GameObject orientation;

    //視線誘導する方のオブジェクトのレイヤー
    public LayerMask forcibly;

    //orientationの取得状態
    bool haveOrientation;

    //誘導先のオブジェクト
    public Transform target;

    private void OnTriggerEnter(Collider other)
    {
        //trigger通過でorientation取得
        player = other.gameObject.transform.parent.gameObject;
        orientation = player.transform.GetChild(1).gameObject;

        //orientation取得状態をtrue
        haveOrientation = true;
    }

    void Update()
    {
        //orientation取得状態でのみ作用する
        if (haveOrientation)
        {
            //orientation:視線方向にray飛ばす
            Ray ray = new Ray(orientation.transform.position, orientation.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 5f, forcibly))
            {
                Debug.Log("当たった");
                //forciblyのコライダーにrayがぶつかったら、視線が背後に誘導される処理

                //視点誘導
                // Vector3 relativePos = target.position - player.transform.position;
                // Quaternion rotation = Quaternion.LookRotation(relativePos);
                // orientation.transform.rotation = Quaternion.Slerp(orientation.transform.rotation, rotation, 1f);
                // orientation.transform.LookAt(target.transform);
            }


        }
    }
}
