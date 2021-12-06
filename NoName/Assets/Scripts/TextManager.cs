using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public TypeOutScript text;

    // Update is called once per frame
    public void ShowText(float typingTime, string textToShow)
    {
        text.TotalTypeTime = typingTime;
        text.FinalText = textToShow;
        text.On = true;
    }

    public void TurnOffText()
    {
        text.reset = true;
    }
}