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
    float screenWidth;

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

        // //画面のサイズを取得
        // screenHeight = Screen.height;
        // screenWidth = Screen.width;

        //ED曲取得
        music = GetComponent<AudioSource>();

        // //エンドロールの内容をテキストファイルから取得
        // text = TextFileReader.ContentOfTxtFile(@"Assets\Scripts\EndingScripts\EndrollText.txt");

        // //取得した内容をtextに渡す
        // endRollText.text = text;
        // Debug.Break();
    }

    void Start()
    {
        //画面のサイズを取得
        //currentResolutionある方がいいのか？ない方がいいのか？
        screenHeight = Screen.currentResolution.height;
        screenWidth = Screen.width;

        // Debug.Log(screenHeight);
        // Debug.Break();

        //テキストボックスのサイズ取得
        titleBoxSize = endRollTitle.preferredHeight;
        textBoxSize = endRollText.preferredHeight;
        msgBoxSize = endRollMsg.preferredHeight;

        //全テキストボックスの位置を調整
        SetPosition();

        //ED再生
        music.Play();
    }

    void Update()
    {
        //スペースキー
        if (Input.GetKeyDown(KeyCode.Space))
        {
            endRollMsgCoroutine = StartCoroutine(GoToStartScene());
        }

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
            float limit = textBoxSize + screenHeight / 2;
            if (limit <= endRollText.rectTransform.localPosition.y)
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
            if (endRollMsg.rectTransform.localPosition.y >= 0)
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
        //スペースキーで早送り：３倍速
        if (Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift))
        {
            endRoll.transform.position = new Vector2(endRoll.transform.position.x,
            endRoll.transform.position.y + textScrollSpeed * 3 * Time.deltaTime);
        }
        else
        {
            endRoll.transform.position = new Vector2(endRoll.transform.position.x,
                endRoll.transform.position.y + textScrollSpeed * Time.deltaTime);
        }
    }

    //UI座標⇔ワールド座標


    //初期位置設定
    void SetPosition()
    {
        //タイトル位置
        float center = titleBoxSize / 2;
        endRollTitle.rectTransform.localPosition = new Vector3(0, center, 0);

        //テキストの位置、下辺中央
        float bottom = screenHeight / 2;
        endRollText.rectTransform.localPosition = new Vector3(0, -bottom, 0);

        //メッセージの位置、下辺中央
        endRollMsg.rectTransform.localPosition = new Vector3(0, -bottom, 0);
        Debug.Break();
    }

    //タイトルを五秒待った後にスクロールさせ、画面外に出たらたたむ
    IEnumerator StartEndRollTitle()
    {
        //３秒まつ
        yield return new WaitForSeconds(3f);

        //画面外に出たら
        float limit = titleBoxSize + screenHeight / 2;
        if (limit <= endRollTitle.rectTransform.anchoredPosition.y)
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
        //3秒停止
        yield return new WaitForSeconds(3f);

        //コルーチン停止とタイトル遷移
        StopCoroutine(endRollMsgCoroutine);
        SceneManager.LoadScene("TiltleScene");
    }

}
