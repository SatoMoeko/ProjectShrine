using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

//エンドロール
//お試し用、本番では使わない

public class Ending_Endroll : MonoBehaviour
{
    //tmpro取得
    public TextMeshProUGUI endRollTxt;

    //コライダ取得
    BoxCollider endRollBc;

    //スクロールスピード
    public float textScrollSpeed = 30f;

    //シーン遷移コルーチン
    Coroutine endRollCoroutne;

    //エンドロールが終わったかどうか
    bool isStopEndRoll;

    void Awake()
    {
        //ボックスコライダ取得
        endRollBc = GetComponent<BoxCollider>();

        //エンドロールの内容を取得
    }

    void Start()
    {
        //エンドロールのテキストボックスの縦サイズを取得
        float boxHeightSize = endRollTxt.preferredHeight;

        Debug.Log(endRollTxt.transform.position.y);
        Debug.Log(boxHeightSize);

        //ボックスコライダの位置を下辺に持っていく
        endRollBc.center = new Vector3(0, -boxHeightSize, 0);
        // Debug.Break();
    }

    void Update()
    {
        //エンドロールを下から上にスクロール
        if (isStopEndRoll)
        {
            endRollCoroutne = StartCoroutine(GoToStartScene());
        }
        else
        {
            transform.position = new Vector2(transform.position.x,
                    transform.position.y + textScrollSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
        isStopEndRoll = true;
    }

    IEnumerator GoToStartScene()
    {
        //5秒待つ
        yield return new WaitForSeconds(5f);

        //space押下でタイトルシーンへ
        //後で自動的にタイトルへ移行するようにする
        if (Input.GetKeyDown("space"))
        {
            StopCoroutine(endRollCoroutne);
            SceneManager.LoadScene("TitleScene");
        }

        yield return null;
    }
}
