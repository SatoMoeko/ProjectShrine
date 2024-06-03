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

    private void Awake()
    {
        //プレイヤー操作を受け付けない設定にする
    }

    private void Start()
    {
        //プレイヤー(0,0,6)、trigger(0,1,21)の位置まで移動する
        player.transform.DOMove(new Vector3(0f, 1f, 21f), 6f);
    }

    public void LookBack()
    {
        //プレイヤー(0,0,0)、背後を左回りで振り返る
        player.transform.DORotate(new Vector3(0, -180, 0), 6f).SetEase(Ease.InOutSine).SetDelay(3f);
    }

}
