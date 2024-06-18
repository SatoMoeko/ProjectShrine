using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleController : MonoBehaviour
{

    void Start()
    {

    }

    public void OnStartButtonClicked()
    {
        Initiate.Fade("Main", Color.black, 1.0f);
        //SceneManager.LoadScene("Main");
    }

}
