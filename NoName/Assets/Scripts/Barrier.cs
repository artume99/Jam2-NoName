using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        
        if (other.tag == "Shard")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
