using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public enum VolumeType { MASTER, BGM, SE }
    [SerializeField]
    VolumeType volumeType = 0;
    Slider slider;
    SoundManager soundManager;

    void Start()
    {
        slider = GetComponent<Slider>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void OnValueChanged()
    {
        switch (volumeType)
        {
            // case VolumeType.MASTER:
            //     soundManager.Volume = slider.value;
            //     break;
            case VolumeType.BGM:
                soundManager.BGMvolume = slider.value;
                break;
            case VolumeType.SE:
                soundManager.Sevolume = slider.value;
                break;
        }
    }

    void Update()
    {

    }
}
