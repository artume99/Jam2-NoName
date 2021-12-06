using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeConsistent : MonoBehaviour
{
    private bool flag = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!flag)
        {
            flag = true;
            GameManager.Instance.TurnOffText();
            GameManager.Instance.ShowText("Consistency");
            
        }
    }
}
