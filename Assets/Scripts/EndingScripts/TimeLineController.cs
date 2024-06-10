using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineController : MonoBehaviour
{
    //タイムラインの取得
    public PlayableDirector director;

    //スクリプトが有効になった時、イベントハンドラ設定
    private void OnEnable()
    {
        director.stopped += OnPlayableDirectoreStopped;
    }

    //停止時に呼び出されるメソッド
    void OnPlayableDirectoreStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
        {
            //停止時の処理

        }
    }

    //スクリプトが無効になった時、イベントハンドラ解除
    private void OnDisable()
    {
        director.stopped -= OnPlayableDirectoreStopped;
    }

    //一時停止
    public void TimeLinePause()
    {
        director.Pause();
    }

    //再生
    public void TimeLineRestart()
    {
        director.Resume();
    }
}
