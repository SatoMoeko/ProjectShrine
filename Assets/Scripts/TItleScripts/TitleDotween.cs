using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(CanvasGroup))]
public class TitleDotween : MonoBehaviour
{
    //秒数  
    public float DurationSeconds;
    //EaseTypeの選択
    public Ease EaseType;

    private CanvasGroup canvasGroup;
    Tween tween;

    //マウスを乗せたとき、文字点滅
    public void OnMouseOver()
    {
        this.canvasGroup = this.GetComponent<CanvasGroup>();
        tween = this.canvasGroup.DOFade(0.0f, this.DurationSeconds).SetEase
       (this.EaseType).SetLoops(-1, LoopType.Yoyo);
    }
    //マウスを離したとき、文字のFadeをもとの状態に戻す
    public void OnMouseExit()
    {
        tween.Kill();
        this.canvasGroup.DOFade(1f, 1f);
    }

}



