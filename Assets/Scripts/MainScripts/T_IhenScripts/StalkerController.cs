using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
プレイヤーにStalkerをくっつける
stalkerはプレイヤーの移動に従うように足音を鳴らす
*/
public class StalkerController : MonoBehaviour
{
    public GameObject stalker;
    Rigidbody rb;

    private void Start()
    {
        stalker.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        stalker.SetActive(true);
        stalker.transform.parent = other.gameObject.transform;
        rb = other.gameObject.GetComponent<Rigidbody>();
    }
}
