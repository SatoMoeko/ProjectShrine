using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemyGenerator : MonoBehaviour
{
    bool isEnter = false;
    public GameObject remy;
    public Main_GameController gameController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEnter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isEnter = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isEnter)
        {
            remy.SetActive(true);


        }

    }
}
