using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{

    public VideoPlayer vp;
    public static bool isPlay;

    private void Start()
    {
        isPlay = false;
        vp.loopPointReached += LoopPointReached;
        vp.Play();
    }

    public void LoopPointReached(VideoPlayer vp)
    {
        //動画再生終了時の処理
        // Debug.Log("動画再生終了");
        isPlay = true;
        //自objectを非活性化
        gameObject.SetActive(false);
    }
}
