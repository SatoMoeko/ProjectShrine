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
        SceneManager.LoadScene("Main");
    }

}
