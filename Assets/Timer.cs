using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    float timer = 10f;
    bool changer = false;
    public bool notStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if(!notStarted){
        return;
    }
        //if(quiz is on)
        timer -= Time.deltaTime;

        if(timer < 0f && !changer){
            timer = 3f;
            changer = true;
        }
        if(timer < 0f && changer){
            timer = 10f;
            changer = false;
        }

    ShowTimer();
    }
    void ShowTimer(){
        timerText.text = timer.ToString("F2");
    }
}
