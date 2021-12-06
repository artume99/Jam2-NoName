using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RisingPlatform : MonoBehaviour
{
    private bool rocked = false;
    private bool rise = false;
    private Transform costumePos;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    private GameObject o;
    
    
    private void Update()
    {
        if(o)
            if (Math.Abs(o.transform.position.y - transform.position.y) > 3)
                rocked = false;
        if (rocked)
        {
            transform.position = Vector3.Lerp(transform.position,end.position, Time.deltaTime);
           
        }
        else if (rise)
        {
            transform.position = Vector3.Lerp(costumePos.position, start.position, Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rock")
        {
            rocked = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rock")
        {
            o = other.gameObject;
            rise = true;
            costumePos = transform;
            

        }
    }
}
