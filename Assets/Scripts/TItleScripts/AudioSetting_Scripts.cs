using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting_Scripts : MonoBehaviour
{

    //スライダー
    private Slider BGMvolumeSlider;
    private Slider SEvolumeSlider;

    //オーディオソース
    public GameObject BGMaudioSource;
    public GameObject SEaudioSource;

    // BGM SEリスト
    public List<AudioClip> BGMs;
    public List<AudioClip> SEs;

    //音量管理システムが開かれているかどうか
    public bool Opened_Audio_Setting = false;

    void Start()
    {
        //シーン内からSliderを探して取得
        BGMvolumeSlider = GameObject.Find("BGMvolumeSlider").GetComponent<Slider>();
        SEvolumeSlider = GameObject.Find("SEvolumeSlider").GetComponent<Slider>();

        //保存された音量を反映
        BGMvolumeSlider.value = Update_Volume.BGMsliderValue;
        SEvolumeSlider.value = Update_Volume.SEsliderValue;

    }

    void Update()
    {
        //スライダーの値を取得
        Update_Volume.BGMsliderValue = BGMvolumeSlider.value;
        Update_Volume.SEsliderValue = SEvolumeSlider.value;

        //オーディオの音量設定
        BGMaudioSource.GetComponent<AudioSource>().volume = Update_Volume.BGMsliderValue;
        SEaudioSource.GetComponent<AudioSource>().volume = Update_Volume.SEsliderValue;

        //スライダーの値が変更された時の処理を記録
        BGMvolumeSlider.onValueChanged.AddListener(ChangeVolumeBGM);
        SEvolumeSlider.onValueChanged.AddListener(ChangeVolumeSE);

        //キーが押されたときの処理
        if (Input.GetKeyDown(KeyCode.T) && !Opened_Audio_Setting)
        {
            Debug.Log("OPEN");
            Open_Audio_Setting();
        }
        else if (Input.GetKeyDown(KeyCode.T) && Opened_Audio_Setting)
        {
            Debug.Log("CLOSE");
            Close_Audio_Setting();
        }
    }

    void ChangeVolumeBGM(float newVolume)
    {
        //スライダーの値によって音量を変更
        BGMaudioSource.GetComponent<AudioSource>().volume = newVolume;
    }
    void ChangeVolumeSE(float newVolume)
    {
        //スライダーの値によって音量を変更
        SEaudioSource.GetComponent<AudioSource>().volume = newVolume;
    }

    void PauseGame()
    {
        //ゲームの時間停止
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        //ゲームの時間を再開
        Time.timeScale = 1f;
    }

    //Opened_Audio_SettingがFalseのときに実行される
    //音量調節画面を開く
    public void Open_Audio_Setting()
    {
        if (!Opened_Audio_Setting)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 250f, gameObject.transform.position.z);
            Opened_Audio_Setting = true;
            PauseGame();
        }
    }

    //👇Opened_Audio_SettingがTrueの時に実行される
    //音量調節画面を閉じる
    public void Close_Audio_Setting()
    {
        if (Opened_Audio_Setting)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 250f, gameObject.transform.position.z);
            Opened_Audio_Setting = false;
            ResumeGame();
        }
    }

    //SEを鳴らす
    public void Play_SE(int seIndex)
    {
        SEaudioSource.GetComponent<AudioSource>().clip = SEs[seIndex];
        SEaudioSource.GetComponent<AudioSource>().Play();
    }
    //BGMを鳴らす
    public void Play_BGM(int bgmIndex)
    {
        BGMaudioSource.GetComponent<AudioSource>().clip = BGMs[bgmIndex];
        BGMaudioSource.GetComponent<AudioSource>().Play();
    }

}
