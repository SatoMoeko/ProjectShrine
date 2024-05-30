using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//エンドロール用
//作成中

public class Ending_Endroll : MonoBehaviour
{
    public TextMeshProUGUI endRollTxt;

    //スクロールスピード
    public float textScrollSpeed = 30f;
    //テキスト制限位置
    public float limitPosition;

    //エンドロールが終了したかどうか
    bool isStopEndRoll;
    //シーン遷移コルーチン
    Coroutine endRollCoroutne;

    void Start()
    {
        // limitPosition = ;
        endRollTxt.text = "endroll\nendroll\nendroll\nendroll\nsample\nsample\nsample\nsample\n\n\ntxt";

    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x,
                    transform.position.y + textScrollSpeed * Time.deltaTime);

        // if (isStopEndRoll)
        // {
        //     // endRollCoroutne = StartCoroutine(GoToStartScene());
        // }
        // else
        // {
        //     // //テキストがリミットを超えるまで動かす
        //     // if (transform.position.y <= limitPosition)
        //     // {
        //     //     transform.position = new Vector2(transform.position.x,
        //     //         transform.position.y + textScrollSpeed * Time.deltaTime);
        //     // }
        //     // else
        //     // {
        //     //     isStopEndRoll = true;
        //     // }
        // }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
    }

    IEnumerator GoToStartScene()
    {
        //5秒待つ
        yield return new WaitForSeconds(5f);

        if (Input.GetKeyDown("space"))
        {
            StopCoroutine(endRollCoroutne);
            SceneManager.LoadScene("Main");
        }

        yield return null;
    }
}
