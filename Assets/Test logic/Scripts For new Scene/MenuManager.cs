using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("TestScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
