using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

//エンディングシーンのコントロールを行う
/*
エンディングシーンでの演出
・プレイヤー：自動的にtriggerまで移動
・triggerに接触したらプレイヤー停止、目の前に二択が出現
    ∟　1：振り返る→左回りでゆっくり視点移動、鳥居の方を向く→出会った異変たちとご対面
    ∟　2：振り返らない→お参りするムービー
・エンドロール再生
*/

public class EndingSceneController : MonoBehaviour
{
    //タイムライン
    public PlayableDirector TLDirector;
    public GameObject endingTimeLine;

    //エンドロール操作
    public GameObject endRollDirector;

    //エンディングイベント操作
    public GameObject endingEventDirector;

    //イベントUI
    public GameObject selectEndingPanel;
    //エンドロールUI
    public GameObject endRollPanel;

    //イベントムービー
    public GameObject endingMovie;

    //BGM
    public AudioSource BGM;

    private void Awake()
    {
        //タイムライン活性化
        endingTimeLine.SetActive(true);

        //endRollDirecter非活性
        endRollDirector.SetActive(false);

        //UI非表示
        Panel_NotActive();
        endRollPanel.SetActive(false);

        //ムービー非表示
        endingMovie.SetActive(false);

    }

    private void Start()
    {
        //マウスポインタ中央固定、不可視化
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //プレイヤー(0,1,6)、trigger(0,1,21)の位置まで移動する、タイムラインによる制御
        TLDirector.Play();

    }

    //振り返るを選択
    public void LookBackTrigger()
    {
        //マウスポインタ不可視化
        Cursor.visible = false;

        Debug.Log("振り返る");

        //選択肢パネル非表示
        Panel_NotActive();

        //コルーチン
        StartCoroutine(E_LookBackCoroutine());
    }

    //振り返らない選択
    public void NotlookBackTorigger()
    {
        //マウスポインタ不可視化
        Cursor.visible = false;
        Debug.Log("振り返らない");

        //選択肢パネル非表示
        Panel_NotActive();

        //スタートタイムライン非活性
        endingTimeLine.SetActive(false);

        //BGM停止
        BGM.Stop();

        //ムービー再生
        endingMovie.SetActive(true);

        //参拝したらエンドロールへ
        StartCoroutine(E_NotLookBackCoroutine());
    }

    void Panel_NotActive()
    {
        selectEndingPanel.SetActive(false);
    }

    //振り返る
    IEnumerator E_LookBackCoroutine()
    {
        //プレイヤー(0,0,0)、1秒後に背後を左回りで振り返る
        //タイムラインを再生
        TLDirector.time = 8;
        TLDirector.Resume();

        //タイムラインの再生が終わったら
        yield return new WaitUntil(() => TimeLineController.isPlay == true);

        //BGM停止
        BGM.Stop();

        //エンドロール再生
        endRollPanel.SetActive(true);
        endRollDirector.SetActive(true);

        //コルーチン停止
        yield break;
    }

    //振り返らない
    IEnumerator E_NotLookBackCoroutine()
    {
        //videoControllerのisPlayがtrueになるまで待機
        yield return new WaitUntil(() => VideoController.isPlay == true);

        //ムービー後、エンドロールへ
        endRollPanel.SetActive(true);
        endRollDirector.SetActive(true);

        //コルーチン停止
        yield break;
    }

}
