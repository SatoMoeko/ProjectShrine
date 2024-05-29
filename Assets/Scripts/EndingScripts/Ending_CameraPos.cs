using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_CameraPos : MonoBehaviour
{
    public Transform cameraPos;
    void Update()
    {
        transform.position = cameraPos.position;
    }
}