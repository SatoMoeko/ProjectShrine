using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


//エンドロールのコントロール
//ほぼ完成

public class EndRollController : MonoBehaviour
{
    //エンドロールパネル
    public GameObject endRollPanel;

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

    //画面の縦横のサイズ
    float screenHeight;
    // float screenWidth;

    //エンドロールの内容を取得するためのもの
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
        // endRollPanel.SetActive(true);

        //画面のサイズを取得
        //currentResolutionある方がいいのか？ない方がいいのか？
        screenHeight = Screen.height;

        //ED曲取得
        music = GetComponent<AudioSource>();

        //エンドロールの内容をテキストファイルから取得
        text = TextFileReader.ContentOfTxtFile(@"Assets\Scripts\EndingScripts\EndrollText.txt");

        //取得した内容をtextに渡す
        endRollText.text = text;
        // Debug.Break();
    }

    void Start()
    {
        //テキストボックスのサイズ取得
        titleBoxSize = endRollTitle.preferredHeight;
        textBoxSize = endRollText.preferredHeight;
        msgBoxSize = endRollMsg.preferredHeight;

        //全テキストボックスの位置を調整
        SetPosition();

        // //確認用
        Debug.Log(endRollTitle.rectTransform.anchoredPosition);
        Debug.Log(endRollText.rectTransform.anchoredPosition);
        Debug.Log(endRollMsg.rectTransform.anchoredPosition);
        Debug.Break();

        //ED再生
        music.Play();
    }

    void Update()
    {
        //エンドロールを下から上にスクロール
        //タイトルのスクロール
        if (!isOutTitle)
        {
            //isOutTitle:falseなら5秒停止後にスクロール
            endRollTitleCoroutine = StartCoroutine(StartEndRollTitle());
        }

        //テキスト:isOutTitle:trueかつisOutText:falseならtextのスクロール実行
        if (isOutTitle && !isOutText)
        {
            if (textBoxSize <= endRollText.rectTransform.anchoredPosition.y)
            {
                //画面上辺中央にきたらfalse
                isOutText = true;
                //画面外に出たらオブジェクトをたたむ
                endRollText.enabled = false;
            }
            //スクロール
            ScrollStart(endRollText);
        }

        //メッセージ:isOutTitle:trueかつisOutText:trueかつisStopMsg:false
        //メッセージを中央まで送って停止、その後タイトルへ
        if (isOutTitle && isOutText && !isStopMsg)
        {
            //中央で止まる
            float Ycenter = screenHeight / 2 - msgBoxSize / 2;
            if (endRollMsg.rectTransform.anchoredPosition.y >= -Ycenter)
            {
                isStopMsg = true;

            }
            ScrollStart(endRollMsg);


        }
        else if (isOutText && isOutText && isStopMsg)
        {
            endRollMsgCoroutine = StartCoroutine(GoToStartScene());
        }
    }

    //スクロールをする
    void ScrollStart(TextMeshProUGUI endRoll)
    {
        endRoll.transform.position = new Vector2(endRoll.transform.position.x,
            endRoll.transform.position.y + textScrollSpeed * Time.deltaTime);
    }

    //初期位置設定
    void SetPosition()
    {
        //titleの位置、画面中央
        float Ycenter = screenHeight / 2 - titleBoxSize / 2;
        endRollTitle.rectTransform.anchoredPosition = new Vector2(0, -Ycenter);

        //textの位置、下辺中央
        endRollText.rectTransform.anchoredPosition = new Vector2(0, -screenHeight);

        //msgの位置、下辺中央
        endRollMsg.rectTransform.anchoredPosition = new Vector2(0, -screenHeight);
    }

    //タイトルを五秒待った後にスクロールさせ、画面外に出たらたたむ
    IEnumerator StartEndRollTitle()
    {
        //5秒まつ
        yield return new WaitForSeconds(5f);

        //画面外に出たら
        if (titleBoxSize <= endRollTitle.rectTransform.anchoredPosition.y)
        {
            //フラグをtrue
            isOutTitle = true;

            //trueになったらオブジェクトをたたむ
            endRollTitle.enabled = false;
        }
        else
        {
            //スクロール
            ScrollStart(endRollTitle);
        }

        //コルーチン停止
        StopCoroutine(endRollTitleCoroutine);
    }

    //五秒停止後、タイトルシーンへ移行
    IEnumerator GoToStartScene()
    {
        //5秒停止
        yield return new WaitForSeconds(5f);

        //コルーチン停止とタイトル遷移
        StopCoroutine(endRollMsgCoroutine);
        SceneManager.LoadScene("TiltleScene"); //誤字！
    }

}
