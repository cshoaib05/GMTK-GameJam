using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class movement : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public int life;
    
    void Start()
    { 
        speed = 0.1f * Time.deltaTime;   
    }

    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position, speed);
        speed += speed * Time.deltaTime / 10;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            if(life==1)
            {
                gameObject.SetActive(false);
                Uicontroller.score++;
            }
            else
            {
                life--;
            }
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            print("OUT");
            Time.timeScale = 0;
        }
    }
}
