using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLebelUpdate : MonoBehaviour
{

    private void Awake()
    {
        EventManager.OnTextUpdate.AddListener(UpdateText);  
    }



    public void UpdateText(float val)
    {
        GetComponent<Text>().text = $"Температура: {val}";
    }
}
