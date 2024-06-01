using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


//エンドロールのコントロール
//確認中

public class EndRollController : MonoBehaviour
{
    //ED曲
    AudioSource music;

    //TMPro取得
    public TextMeshProUGUI endRollTitle;
    public TextMeshProUGUI endRollText;
    public TextMeshProUGUI endRollMsg;

    //テキストボックスのサイズ取得
    float titleBoxSize;
    float textBoxSize;
    float msgBoxSize;

    //画面の縦のサイズ
    float screenHeight;

    //エンドロールの内容を取得する変数
    string text;

    //テキストのスクロールスピード
    public float textScrollSpeed = 30f;

    //トリガー
    bool isOutTitle;
    bool isOutText;
    bool isStopMsg;

    //コルーチン
    Coroutine endRollTitleCoroutine;
    Coroutine endRollMsgCoroutine;

    void Awake()
    {
        //画面の縦のサイズを取得
        screenHeight = Screen.currentResolution.height;

        // //テキストを非表示
        // endRollText.enabled = false;
        // endRollMsg.enabled = false;

        //ED曲取得
        music = GetComponent<AudioSource>();

        //エンドロールの内容をテキストファイルから取得
    }

    void Start()
    {
        //テキストボックスのサイズ取得
        titleBoxSize = endRollTitle.preferredHeight;
        textBoxSize = endRollText.preferredHeight;
        msgBoxSize = endRollMsg.preferredHeight;

        //text,msgテキストボックスの位置を画面下辺に来るように調整
        SetPosition(endRollTitle);
        SetPosition(endRollText);
        SetPosition(endRollMsg);

        //確認用
        Debug.Log(endRollTitle.transform.position);
        Debug.Log(endRollText.transform.position);
        Debug.Log(endRollMsg.transform.position);
        Debug.Break();

        //ED再生
        music.Play();
    }

    void Update()
    {
        //エンドロールを下から上にスクロール
        //タイトル
        if (!isOutTitle)
        {
            endRollTitleCoroutine = StartCoroutine(StartEndRollTitle());
        }
        //テキスト:isOutTitle:trueかつisOutText:falseなら実行
        if (isOutTitle && !isOutText)
        {
            CheckedEndRollPosition(endRollText, textBoxSize, isOutText);
            ScrollStart(endRollText);
        }

        //メッセージ:isOutTitle:trueかつisOutText:trueかつisStopMsg:false
        //メッセージを中央まで送って停止、その後タイトルへ
        if (isOutTitle && isOutText && !isStopMsg)
        {
            endRollMsgCoroutine = StartCoroutine(GoToStartScene());
        }
    }

    void ScrollStart(TextMeshProUGUI endRoll)
    {   //スクロール
        endRoll.transform.position = new Vector2(endRoll.transform.position.x,
            endRoll.transform.position.y + textScrollSpeed * Time.deltaTime);
    }

    //
    void SetPosition(TextMeshProUGUI endRoll)
    {
        //titleの位置、センター
        if (endRoll == endRollTitle)
        {
            float center = screenHeight / 2 + titleBoxSize / 2;
            endRoll.rectTransform.position = new Vector3(0, center, 0);
        }
        //text msgは画面下辺
        else
        {
            endRoll.rectTransform.position = new Vector2(0, -screenHeight);
        }

    }

    //5秒停止後、タイトルをスクロールさせるコルーチン
    IEnumerator StartEndRollTitle()
    {
        //5秒まつ
        yield return new WaitForSeconds(5f);

        //画面外に出たらisOutTitleをTrue
        CheckedEndRollPosition(endRollTitle, titleBoxSize, isOutTitle);

        //タイトルをスクロールさせる
        ScrollStart(endRollTitle);

        //コルーチン停止
        yield break;
    }

    //中央に来たら五秒停止してタイトルシーンへ移行するコルーチン
    IEnumerator GoToStartScene()
    {
        CheckedEndRollPosition(endRollMsg, msgBoxSize, isStopMsg);
        ScrollStart(endRollMsg);

        yield return new WaitForSeconds(5f);

        //コルーチン停止とタイトル遷移
        StopCoroutine(endRollMsgCoroutine);
        SceneManager.LoadScene("TitleScene");
    }

    //エンドロールの位置をチェックする
    void CheckedEndRollPosition(TextMeshProUGUI endRoll, float textBoxSize, bool isChecked)
    {
        //endRollMsgなら
        if (endRoll == endRollMsg)
        {
            float center = screenHeight / 2 + textBoxSize / 2;
            //中央で止まる
            if (endRoll.transform.position.y <= center)
            {
                isChecked = true;
            }
        }
        //それ以外
        else
        {
            if (textBoxSize <= endRoll.transform.position.y)
            {
                isChecked = true;
                endRoll.enabled = false;
            }
        }
    }


}
