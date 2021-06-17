using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] AudioClip buttonClick;
    AudioSource aSource;

    void Start(){
        aSource = GetComponent<AudioSource>();
    }

    void Update() {
        OpenMenuInGame();
    }
    public void PlayGame() {
        Movement.buttonsEnabled = true;
        GetComponent<Canvas>().enabled = false; // disabling menu screen
    }

    public void QuitGame(){
        Debug.Log("Quit game pressed");
        Application.Quit();
    }

    public void PlayButtonClickAudio(){
        aSource.PlayOneShot(buttonClick);
    }

    public void OpenMenuInGame(){
        if(Input.GetKey(KeyCode.Escape) && !TimerController.isEndScreen){
            GetComponent<Canvas>().enabled = true; // showing menu screen
            PauseGame();
        }
    }

    public void restartGame(){

    }

    void PauseGame(){
        Time.timeScale = 0; // pausing game
    }

    public void ResumeGame(){
        Time.timeScale = 1; // resuming game
    }
}
