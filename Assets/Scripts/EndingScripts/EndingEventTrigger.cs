using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//エンディング分岐のトリガー
//接触したらプレイヤー停止、二択を選ぶ
public class EndingEventTrigger : MonoBehaviour
{
    //エンディング分岐パネル
    public GameObject selectEndingPanel;

    EndingSceneController esc;

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
        esc.LookBack();
    }

    public void NotlookBackTorigger()
    {
        Debug.Log("振り返らない");

        //パネル非表示
        Panel_NotActive();

        //この後、参拝するムービー
    }

    void Panel_NotActive()
    {
        selectEndingPanel.SetActive(false);
    }

}
