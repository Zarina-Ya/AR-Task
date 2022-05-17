using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void Awake()
    {
        //this.gameObject.SetActive(false);
        EventManager.OnEndGame.AddListener(SetActivePanel);
    }

    private void SetActivePanel()
    {
        //this.gameObject.SetActive(true);
        Application.LoadLevel("EndGame");
    }

   
}
