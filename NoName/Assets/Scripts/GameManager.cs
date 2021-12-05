using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    // References
    public TextManager textManager;
    public BatMovement bat;
    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Update is called once per frame
    private void Start()
    {
        textManager.ShowText(3,"Clap Your Hands");
    }
}
