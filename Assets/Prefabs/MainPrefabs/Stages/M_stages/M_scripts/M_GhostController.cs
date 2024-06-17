using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_GhostController : MonoBehaviour
{
    public GameObject ghost;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ghost"))
        {
            Debug.Log("GHostEnter");
            Destroy(ghost);
        }
    }
}
