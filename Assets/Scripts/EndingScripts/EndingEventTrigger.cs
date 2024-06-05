using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//エンディング分岐のトリガー
//接触したらプレイヤー停止、二択を選ぶ
public class EndingEventTrigger : MonoBehaviour
{
    //エンディング分岐パネル
    public GameObject selectEndingPanel;
    public GameObject player;


    private void Awake()
    {
        Panel_NotActive();
    }

    void OnTriggerEnter(Collider other)
    {
        selectEndingPanel.SetActive(true);
        Debug.Log("player接触");
    }

    //振り返るを選択
    public void LookBackTrigger()
    {
        Debug.Log("振り返る");

        //パネル非表示
        Panel_NotActive();

        //この後、プレイヤーは振り返って異変とご対面
        //プレイヤー(0,0,0)、背後を左回りで振り返る
        player.transform.DORotate(new Vector3(0, -180, 0), 6f).SetEase(Ease.InOutSine).SetDelay(2f);

        //ご対面したらエンドロールへ
    }

    public void NotlookBackTorigger()
    {
        Debug.Log("振り返らない");

        //パネル非表示
        Panel_NotActive();

        //この後、参拝するムービー再生

        //ムービー再生したらエンドロールへ

    }

    void Panel_NotActive()
    {
        selectEndingPanel.SetActive(false);
    }

}
