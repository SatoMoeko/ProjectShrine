using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

//エンディングシーンのコントロールを行う
/*
エンディングシーンでの演出
・プレイヤー：自動的にtriggerまで移動する、歩行および視点移動を受け付けない
・triggerに接触したらプレイヤー停止、目の前に二択が出現
    ∟　1：振り返る→左回りでゆっくり視点移動、鳥居の方を向く→出会った異変たちとご対面
    ∟　2：振り返らない→お参りするムービー
・エンドロール再生
*/

public class EndingSceneController : MonoBehaviour
{
    //イベントシステム
    public EventSystem es;

    //プレイヤー
    public GameObject player;

    //エンドロール操作
    public GameObject endRollDirecter;

    //エンディングイベント操作
    public GameObject endingEventDirecter;

    //イベントUI
    public GameObject selectEndingPanel;
    //エンドロールUI
    public GameObject endRollPanel;

    private void Awake()
    {
        //endRollDirecter非活性
        endRollDirecter.SetActive(false);

        //UI非表示
        Panel_NotActive();
        endRollPanel.SetActive(false);

    }

    private void Start()
    {
        //プレイヤー(0,1,6)、trigger(0,1,21)の位置まで移動する
        player.transform.DOMove(new Vector3(0f, 1f, 21f), 7f);
    }

    //振り返るを選択
    public void LookBackTrigger()
    {
        Debug.Log("振り返る");

        //パネル非表示
        Panel_NotActive();

        StartCoroutine(E_LookBackCoroutine());
        // //プレイヤー(0,0,0)、1秒後に背後を左回りで振り返る
        // player.transform.DORotate(new Vector3(0, -180, 0), 6f).SetEase(Ease.InOutSine).SetDelay(1f);

        //ご対面したらエンドロールへ
    }

    public void NotlookBackTorigger()
    {
        Debug.Log("振り返らない");

        //パネル非表示
        Panel_NotActive();

        //この後、参拝する

        //参拝したらエンドロールへ

    }

    void Panel_NotActive()
    {
        selectEndingPanel.SetActive(false);
    }

    //振り返る
    IEnumerator E_LookBackCoroutine()
    {
        //プレイヤー(0,0,0)、1秒後に背後を左回りで振り返る
        player.transform.DORotate(new Vector3(0, -180, 0), 6f).SetEase(Ease.InOutSine).SetDelay(2f);

        //DOTween含め10秒待ってからエンドロールへ
        yield return new WaitForSeconds(10F);

        //エンドロール再生
        endRollPanel.SetActive(true);
        endRollDirecter.SetActive(true);

        //コルーチン停止
        yield break;
    }

    //振り返らない
    IEnumerator E_NotLookBackCoroutine()
    {
        //参拝する

        //エンドロールへ

        yield return null;
    }

}
