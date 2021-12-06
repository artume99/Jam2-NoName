using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text text;

    // Update is called once per frame
    public void ShowText(float typingTime, string textToShow)
    {
        text.text = textToShow;
    }

    public void TurnOffText()
    {
        text.text = "";
    }
}