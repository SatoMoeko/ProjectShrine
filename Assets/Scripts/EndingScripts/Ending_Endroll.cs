using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.SceneManagement;

//エンドロール用
//作成中

public class Ending_Endroll : MonoBehaviour
{
    public TextMeshProUGUI endRollTxt;

    //スクロールスピード
    public float textScrollSpeed = 30f;
    //シーン遷移コルーチン
    Coroutine endRollCoroutne;

    bool isStopEndRoll;

    void Start()
    {

    }

    void Update()
    {
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

        if (Input.GetKeyDown("space"))
        {
            StopCoroutine(endRollCoroutne);
            SceneManager.LoadScene("Main"); //シーン遷移のお試しにMainへ飛ぶ
        }

        yield return null;
    }
}
