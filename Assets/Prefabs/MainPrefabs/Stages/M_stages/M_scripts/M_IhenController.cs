using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_IhenController : MonoBehaviour
{
    public GameObject Ihen;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("IhenEnter");
            Destroy(Ihen);
        }
    }
}
