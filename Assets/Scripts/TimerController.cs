using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    [SerializeField]
    private TMPro.TextMeshProUGUI timeCounter;

    [SerializeField]
    private TMPro.TextMeshProUGUI endTime;
    
    [SerializeField]
    Canvas can;
    float currentTime;
    bool timerActive = false;

    public static bool isEndScreen = false;
    // Start is called before the first frame update
    void Awake(){
        instance = this;
    }
    void Start(){
        currentTime = 0;
        can.enabled = false;
    }
    void Update(){
        if(timerActive){
            currentTime += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            timeCounter.text = time.ToString("mm':'ss':'ff");
        }
    }
    public void StartTimer(){
        timerActive = true;
    }
    public void StopTimer(){
        timerActive = false;
    }

    public void ResetTimer(){
        Debug.Log("time set to 0");
        currentTime = 0;
    }

    public void showEndTime(){
        Debug.Log("Er si iets asgeawbrsdf");
        can.enabled = true;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timeCounter.text = "";
        endTime.text = "You saved Elon Musks marriage in this time: " + time.ToString("mm':'ss':'ff");
        isEndScreen = true;
    }
     public void RestartGame(){
        DestroyCurrentUi();
        SceneManager.LoadScene(0);
        can.enabled = false;
        Movement.buttonsEnabled = false;
        isEndScreen = false;
    }

    void DestroyCurrentUi(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("UI");
        Debug.Log(objs);
         foreach(GameObject go in objs){
            Destroy(go.GetComponent<DontDestroy>());
            Destroy(go);
        }
    }
}
