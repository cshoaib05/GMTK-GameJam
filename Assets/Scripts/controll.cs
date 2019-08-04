using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class controll : MonoBehaviour
{
    public GameObject loadpanel;
    public Slider slider;
    public TextMeshProUGUI highscore;
    public GameObject Scorepanel;

    private void Start()
    {
      
    }

    public void showpanel()
    {
        Scorepanel.SetActive(true);
    }

    public void hidepanel()
    {
        Scorepanel.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        highscore.text = PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    public void loadscene()
    {
        StartCoroutine(asloadasync(0));
        Time.timeScale = 1;
    }

   

    IEnumerator asloadasync(int name)
    {
        loadpanel.SetActive(true);
        AsyncOperation oper = SceneManager.LoadSceneAsync(name);

        while (!oper.isDone)
        {
            float progress = Mathf.Clamp01(oper.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
