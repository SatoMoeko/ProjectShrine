using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_GameController : MonoBehaviour
{
    public Main_PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerController.Point());
        //ポイントが５ならラストシーン遷移
        if (playerController.Point() == 5)
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
