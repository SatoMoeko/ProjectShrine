using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class M_SittingController : MonoBehaviour
{
    public List<GameObject> SittingZombieList = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            for (int i = 0; i < SittingZombieList.Count; i++)
            {
                GameObject SittingZombie = SittingZombieList[i];
                SittingZombieList.RemoveAt(i);
                Destroy(SittingZombie);

            }
        }
    }
}
