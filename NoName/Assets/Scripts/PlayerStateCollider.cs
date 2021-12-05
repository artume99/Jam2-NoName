using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameJam2;
using UnityEngine;

public class PlayerStateCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Bat"))
        {
            GameManager.Instance.SaveState(transform.position);
            Destroy(gameObject);
        }
    }
    
}
