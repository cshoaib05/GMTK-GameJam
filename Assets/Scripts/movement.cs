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

    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position, speed);
        speed += speed * Time.deltaTime / 10;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            collision.gameObject.SetActive(false);
            
            if (Time.time < 60f) { life--; }
            if (Time.time > 60f && Time.time < 120f) { life = life - 2;}
            if (Time.time > 120f && Time.time < 180f) { life = life - 3;  }
            if (Time.time > 180f && Time.time < 240f) { life = life - 4;  }
            if (Time.time > 240f && Time.time < 320f) { life = life - 5;  }
            if (Time.time > 320f && Time.time < 400f) { life = life - 6; }
            if (Time.time > 400f && Time.time < 480f) { life = life - 7;  }

            if (life<=0)
            {
                gameObject.SetActive(false);
                Uicontroller.score++;
            }

        }

        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement.life--;
            if(PlayerMovement.life<=0)
            {
               PlayerMovement.die = true;
                
            }
            gameObject.SetActive(false);   
        }
    }


    
}
