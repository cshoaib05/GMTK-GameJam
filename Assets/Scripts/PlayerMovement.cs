using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed;
    public float speed;


    public Rigidbody2D projectile;
    public GameObject bullet;
    public GameObject bulletposition;

    private Queue<Rigidbody2D> bulletqueue;

    private void Awake()
    {
        bulletqueue = new Queue<Rigidbody2D>();    
    }

    void Start()
    {
        
        for (int i=0; i<=50 ;i++)
        {
            GameObject bulletinst = Instantiate(bullet, bulletposition.transform.position, bulletposition.transform.rotation);
            bulletinst.SetActive(false);
            projectile = bulletinst.gameObject.GetComponent<Rigidbody2D>();
            bulletqueue.Enqueue(projectile);
        }

       
    }

    void FixedUpdate()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotation);

        if(Input.GetMouseButtonDown(0))
        {
            Rigidbody2D bulletdeq = bulletqueue.Dequeue();
            bulletdeq.gameObject.SetActive(true );
            bulletdeq.transform.position = bulletposition.transform.position;
            bulletdeq.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
            bulletqueue.Enqueue(bulletdeq);
        }


    }
}
