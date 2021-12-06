using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI button;
    // Start is called before the first frame update
    private void OnMouseEnter()
    {
        Debug.Log("here");
        button.color = Color.green;
    }
}
