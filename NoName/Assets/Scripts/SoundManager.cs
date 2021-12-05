using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public enum SoundType
    {
        Stone,
        Walking,
        Stalactite,
        ThemeSound
    }
    
    
    // Start is called before the first frame update
    public void PlaySound(SoundType soundType)
    {
        MasterAudio.PlaySound(soundType.ToString());
    }
    
}
