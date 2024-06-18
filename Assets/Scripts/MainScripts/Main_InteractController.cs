using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_InteractController : MonoBehaviour
{
    //UIをセット
    public GameObject look;
    public GameObject rulePaper;
    AudioSource audioSource;


    //UIみえているか判定

    bool getLook = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            GetComponent<AudioSource>().Play();
            //UIをひらく
            if (getLook)
            {
                rulePaper.SetActive(true);//みえる処理
            }
            else
            {
                rulePaper.SetActive(false);//かくす処理
            }
        }
        getLook = !getLook;
    }

    void OnTriggerStay(Collider other)
    {
        look.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        rulePaper.SetActive(false);
        look.SetActive(false);
    }
}
