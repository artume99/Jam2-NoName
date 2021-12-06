using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningManager : MonoBehaviour
{
    private const string ThemeSound = "ThemeSound";
    [SerializeField] private LevelLoader lvlLoad;

    private void Start()
    {
        MasterAudio.PlaySound(ThemeSound);
    }

    public void Play()
    {
        lvlLoad.LoadNextLevel();
    }

    public void Exit()
    {
        Application.Quit();
    }
    
}
