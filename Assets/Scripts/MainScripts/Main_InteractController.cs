using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_InteractController : MonoBehaviour
{
    //UIをセット
    public GameObject look;
    public GameObject rulePaper;
    //カメラをセット
    public GameObject camera;


    //タンスが開いているか判定

    bool getLook = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called once per frame

    void FixedUpdate()
    {

        if (look.activeSelf && Input.GetKey(KeyCode.F))
        {
            //UIをひらく
            if (getLook)
                rulePaper.SetActive(true);//あける処理
            else
                rulePaper.SetActive(false);//しめる処理
        }
        getLook = !getLook;
    }

    void OnTriggerStay(Collider other)
    {
        look.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        look.SetActive(false);
    }
}

