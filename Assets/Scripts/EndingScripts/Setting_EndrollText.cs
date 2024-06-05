using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Setting_EndrollText : MonoBehaviour
{
    //text取得
    public TextMeshProUGUI endRollText;

    string text;

    void Start()
    {
        text = TextFileReader.ContentOfTxtFile(@"Assets\Scripts\EndingScripts\EndrollText.txt");

        endRollText.text = text;
    }
}
