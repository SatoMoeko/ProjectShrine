using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

/*
プレイヤーに処理を追加しないで実装できるようにする
プレイヤーがキャスト内に侵入したら、UIではがす指示表示する
はがされたらオブジェクト破棄してはがした数カウント
*/

public class KaminingyouController : MonoBehaviour, IInteractable
{
    public TextMeshProUGUI peelOffText;

    //キャスト用情報
    public float radius; //キャスト半径
    public LayerMask targetLayer; //キャストが取得するレイヤー：player

    // public Collider[] result = new Collider[1]; //取得するコライダー：プレイヤーのみなので１

    //プレイヤーが範囲内にいるかどうか
    bool inRange;

    void Update()
    {
        RaycastHit hit;

        // Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.SphereCast(transform.position, radius, transform.forward, out hit, 0f, LayerMask.GetMask("Player")))
        {
            Debug.Log("player接近");
        }

        // if (Physics.SphereCast(transform.position, radius, transform.forward, out hit, 0f, targetLayer))
        // {
        //     //範囲内に入った
        //     if (!inRange)
        //     {
        //         inRange = true;
        //         Debug.DrawRay(transform.position, transform.forward, Color.red, 3.0f);
        //         Debug.Log("プレイヤー接近");
        //     }
        // }
        // else
        // {
        //     //範囲外に出た
        //     if (inRange)
        //     {
        //         inRange = false;

        //         Debug.Log("プレイヤー離脱");
        //     }
        // }



    }

    //円の可視化
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Interact()
    {
        //インタラクト時の処理
        //UI表示、はがされたら削除

    }
}
