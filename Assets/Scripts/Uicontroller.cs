using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Uicontroller : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI Scoretext;
    public static int score = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
        Scoretext.text = score.ToString();


        var timeSpan = TimeSpan.FromSeconds(Time.time);
       
        //time.text = Time.time.ToString("0.0");
        time.text = string.Format("{0:D2}:{1:D2}",  timeSpan.Minutes, timeSpan.Seconds);

    }
}
