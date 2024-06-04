using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class TitleDotween : MonoBehaviour
{

    public float DurationSeconds;
    public Ease EaseType;

    private CanvasGroup canvasGroup;

    void Start()
    {
        this.canvasGroup = this.GetComponent<CanvasGroup>();
        this.canvasGroup.DOFade(0.0f, this.DurationSeconds).SetEase
        (this.EaseType).SetLoops(-1, LoopType.Yoyo);
    }



}
