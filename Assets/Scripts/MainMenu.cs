using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        Movement.buttonsEnabled = true;
        GetComponent<Canvas>().enabled = false;
    }

    public void QuitGame(){
        Debug.Log("Quit game pressed");
        Application.Quit();
    }
}
