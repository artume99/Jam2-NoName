using System;
/*using System.Collections;
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
}*/
using UnityEngine;  
using System.Collections;
using TMPro;
using UnityEngine.EventSystems;  
using UnityEngine.UI;
 
public class ColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Color sonar = new Color(0.2156f,0.6352f,0.0823f );
    public TextMeshProUGUI theText;
 
    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = sonar; //Or however you do your color
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = Color.white; //Or however you do your color
    }
}
