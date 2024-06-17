using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_GameController : MonoBehaviour
{


    int point = 0;
    public GameObject sushi;

    //ポイント処理
    public void DefaultStagePoint()
    {
        if (sushi.activeInHierarchy)
        {
            this.point = 0;
        }
        else
        {
            this.point += 1;
        }
    }
    public void OtherStagePoint()
    {
        if (sushi.activeInHierarchy)
        {
            this.point += 1;
        }
        else
        {
            this.point = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.point);
        //ポイントが５ならラストシーン遷移
        if (this.point == 5)
        {
            enabled = false; //これ以上の更新は止める
            Invoke("TurnToEnd", 2.0f); //2秒後にTurnToEndをよびだす
        }
    }

    void TurnToEnd()
    {
        SceneManager.LoadScene("Ending-T");
    }




}
