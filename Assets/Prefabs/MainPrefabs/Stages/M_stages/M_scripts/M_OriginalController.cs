using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_OriginalController : MonoBehaviour
{

    public GameObject ihen;
    public GameObject original;
    bool isEnter = false;

    void OnTriggerEnter(Collider other)
    {

        if (!isEnter && other.CompareTag("Player"))
        {
            Debug.Log("IhenEnter");
            Destroy(ihen);
            Debug.Log("seikaiSet");
            original.SetActive(true);
            isEnter = true;
        }
    }
}
