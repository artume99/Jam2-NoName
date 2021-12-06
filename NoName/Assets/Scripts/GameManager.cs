using System;
using System.Collections;
using System.Collections.Generic;
using GameJam2;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    // References
    public TextManager textManager;
    public BatMovement bat;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

  
    public void SaveState(Vector2 pos)
    {
        PlayerState.SaveState(pos);
    }

    public void GameOver()
    {
        var lastState = PlayerState.GetState();
        BatMovement.Instance.transform.position = lastState;

    }
    

    // Update is called once per frame
    private void Start()
    {
        textManager.ShowText(3,"Clap");
    }
}
