using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Uicontroller : MonoBehaviour
{
    public static int wave;
    public TextMeshProUGUI time;
    public TextMeshProUGUI Scoretext;
    public TextMeshProUGUI Lifepower;
    public TextMeshProUGUI attackpowertext;
    public TextMeshProUGUI wavetextanim;
    public int attackpower;
    public static int score = 0;
    public GameObject outpanel;
    public Animator waveanim;
    public TextMeshProUGUI scoreout;

    void Start()
    {
      
        wave = 1;
        attackpower = 1;
        wavetextanim.text = wave.ToString();
        waveanim.Play("Waveanim");
    }


    void Update()
    {
        scoreout.text = Scoretext.text;
        if(PlayerMovement.die)
        {
            outpanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }

        Scoretext.text = score.ToString();
        if(PlayerPrefs.GetInt("highscore",0) <score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        var timeSpan = TimeSpan.FromSeconds(Time.time);
       
        time.text = string.Format("{0:D2}:{1:D2}",  timeSpan.Minutes, timeSpan.Seconds);

        if (Time.time < 60f) { wave = 1; increaseattack(); }
        if (Time.time > 60f && Time.time < 120f) { wave=2; increaseattack(); }
        if (Time.time > 120f && Time.time < 180f) { wave=3; increaseattack(); }
        if (Time.time > 180f && Time.time < 240f) { wave=4; increaseattack(); }
        if (Time.time > 240f && Time.time < 320f) { wave=5; increaseattack(); }
        if (Time.time > 320f && Time.time < 400f) { wave=6 ; increaseattack(); }
        if (Time.time > 400f) { wave=7; increaseattack(); }
        string att = "";
        for (int i = 0; i <PlayerMovement.life; i++)
        {
                att = att + "I";
        }
        Lifepower.text = att;
    }

    public void loadscene()
    {
        SceneManager.LoadScene(1);
    }

    public void increaseattack()
    {
       
        if(attackpower != wave)
        {
            wavetextanim.text = wave.ToString();
            waveanim.Play("Waveanim");

            string att="I";
            for(int i=1;i<wave;i++)
            {
                att = att + "I";
            }
            attackpower = wave;
            attackpowertext.text = att;
            PlayerMovement.life++;
        }
    }
}
