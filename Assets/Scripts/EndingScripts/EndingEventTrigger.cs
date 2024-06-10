using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Playables;
using System.Linq.Expressions;

//エンディング分岐のトリガー
//接触したらプレイヤー停止、二択を選ぶ
public class EndingEventTrigger : MonoBehaviour
{
    //エンディング分岐パネル
    public GameObject selectEndingCanvas;
    //プレイヤー
    public Transform player;

    void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        selectEndingCanvas.SetActive(true);
        Debug.Log("player接触");
    }
}
