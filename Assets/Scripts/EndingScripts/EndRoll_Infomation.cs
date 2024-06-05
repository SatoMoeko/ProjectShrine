using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EndRoll_Infomation : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        text.DOFade(0f, 1f).SetLoops(-1, LoopType.Yoyo);
    }
}
