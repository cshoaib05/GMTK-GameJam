using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Uicontroller : MonoBehaviour
{
    public static int wave;
    public TextMeshProUGUI time;
    public TextMeshProUGUI Scoretext;
    public static int score = 0;
    void Start()
    {
        wave = 0;
    }

    
    void Update()
    {
        Scoretext.text = score.ToString();


        var timeSpan = TimeSpan.FromSeconds(Time.time);
       
        time.text = string.Format("{0:D2}:{1:D2}",  timeSpan.Minutes, timeSpan.Seconds);

        if (Time.time < 60f) { wave=1; }
        if (Time.time > 60f && Time.time < 120f) { wave=2; }
        if (Time.time > 120f && Time.time < 180f) { wave=3; }
        if (Time.time > 180f && Time.time < 240f) { wave=4; }
        if (Time.time > 240f && Time.time < 320f) { wave=5; }
        if (Time.time > 320f && Time.time < 400f) { wave=6 ; }
        if (Time.time > 400f && Time.time < 480f) { wave=7; }
        print(wave);
    }
}
