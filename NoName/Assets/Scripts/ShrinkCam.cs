using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkCam : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bat")
        {
            Camera.main.orthographicSize = 2;
        }
    }
}
