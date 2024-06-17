using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEndTrigger : MonoBehaviour
{
    public GameObject ihen;

    void OnTriggerEnter(Collider other)
    {
        ihen.SetActive(false);
    }
}
