using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    [SerializeField]
    private TMPro.TextMeshProUGUI timeCounter;

    float currentTime;
    bool timerActive = false;
    // Start is called before the first frame update
    void Awake(){
        instance = this;
    }
    void Start(){
        currentTime = 0;
    }
    void Update(){
        if(timerActive){
            currentTime += Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timeCounter.text = time.ToString("mm':'ss':'ff");
    }
    public void StartTimer(){
        timerActive = true;
    }
    public void StopTimer(){
        timerActive = false;
    }
}
