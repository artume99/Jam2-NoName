using System;
using System.Collections;
using System.Collections.Generic;
using GameJam2;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    // References
    public TextManager textManager;
    public GameObject shardsContainer;
    public GameObject thirdPart;
    
    // Prefabs
    public GameObject shardsPrefab;
    public GameObject thirdPartPrefab;
    
    public Image whiteScreen;
    
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        ShowText("Clap");
    }


    public void SaveState(Vector2 pos)
    {
        PlayerState.SaveState(pos);
    }

    public void GameOver()
    {
        var lastState = PlayerState.GetState();
        BatMovement.Instance.transform.position = lastState;

        if (lastState.x < 20)
        {
            Destroy(shardsContainer.gameObject);
            shardsContainer = Instantiate(shardsPrefab, null, false);
        }
        else
        {
            Destroy(thirdPart.gameObject);
            thirdPart = Instantiate(thirdPartPrefab, null, false);
        }
    }

    public IEnumerator EndGame()
    {
        while (whiteScreen.color.a < 1)
        {
            var color = whiteScreen.color;
            color.a += 0.001f;
            whiteScreen.color = color;
            yield return new WaitForSeconds(0.001f);
        }

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);

    }
    
    

    public void ShowText(string text)
    {
        textManager.ShowText(3, text);
    }

    public void TurnOffText()
    {
        textManager.TurnOffText();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
    
}
