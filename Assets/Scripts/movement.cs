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
            if (Time.time < 60f) { life--; }
            if (Time.time > 60f && Time.time < 120f) { life = life - 2; PlayerMovement.life++; }
            if (Time.time > 120f && Time.time < 180f) { life = life - 3; PlayerMovement.life++; }
            if (Time.time > 180f && Time.time < 240f) { life = life - 4; PlayerMovement.life++; }
            if (Time.time > 240f && Time.time < 320f) { life = life - 5; PlayerMovement.life++; }
            if (Time.time > 320f && Time.time < 400f) { life = life - 6; PlayerMovement.life++; }
            if (Time.time > 400f && Time.time < 480f) { life = life - 7; PlayerMovement.life++; }

            if (life<=0)
            {
                gameObject.SetActive(false);
                Uicontroller.score++;
            }
           
           

        }

        if(collision.gameObject.CompareTag("Player"))
        {
            print("OUT");
            Time.timeScale = 0;
        }
    }
}
