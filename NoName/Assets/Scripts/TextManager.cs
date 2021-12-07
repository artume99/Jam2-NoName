using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TextManager : MonoBehaviour
{
    public Text text;

    public void ShowText(float typingTime, string textToShow)
    {
        StartCoroutine(ShowTextAnimation(textToShow));
    }

    public void TurnOffText()
    {
        text.text = "";
    }

    private const string abc = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    private int animDuration = 7;
    private IEnumerator ShowTextAnimation(string textToShow)
    {
        int currInd = 0;
        while (text.text.Length < textToShow.Length)
        {
            StringBuilder builder = new StringBuilder(text.text);
            builder.Append("a");
            for (int i = 0; i < animDuration; i++)
            {
                int rndAbc = Random.Range(0, abc.Length);
                builder[^1] = abc[rndAbc];
                text.text = builder.ToString();
                yield return new WaitForSeconds(0.05f);
            }
            builder[^1] = textToShow[currInd];
            text.text = builder.ToString();
            currInd++;
        }
        yield return null;
    }
}