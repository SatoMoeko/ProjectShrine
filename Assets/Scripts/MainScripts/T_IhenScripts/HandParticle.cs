using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandParticle : MonoBehaviour
{
    public GameObject handParticle;

    void Start()
    {
        handParticle.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        handParticle.SetActive(true);
    }
}
