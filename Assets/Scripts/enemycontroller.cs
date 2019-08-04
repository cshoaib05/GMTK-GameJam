using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{
    public enemy[] enemylist1;
    public List<Transform> spawnner;
    private int key = 0;
    public Dictionary<int, Queue<enemy>> objDict;
    int randobj;
    private void Awake()
    {
        objDict = new Dictionary<int, Queue<enemy>>();
    }
    void Start()
    {
        foreach(enemy go in enemylist1)
        {
            key++;
             Queue<enemy> enemyqueue = new Queue<enemy>();

            for (int i =0; i < 50; i++)
            {
               GameObject go1 =  Instantiate(go.enemyname, go.enemyname.transform.position, go.enemyname.transform.rotation);
                go1.SetActive(false);
                enemy enem = new enemy();
                enem.enemyname = go1;
                enem.lives = go.lives;
                enemyqueue.Enqueue(enem);
            }
            objDict.Add(key, enemyqueue);
        }

        spawnnerfun();
    }

    void FixedUpdate()
    {

        if (Uicontroller.wave==1)   {          if (Time.time % 5 > 0 && Time.time % 5 < 0.04) { spawnnerfun(); } }
        if (Uicontroller.wave == 2) {          if (Time.time % 5 > 0 && Time.time % 5 < 0.05) { spawnnerfun(); } }
        if (Uicontroller.wave == 3) {         if (Time.time % 5 > 0 && Time.time % 5 < 0.06) { spawnnerfun(); } }
        if (Uicontroller.wave == 4) {         if (Time.time % 5 > 0 && Time.time % 5 < 0.07) { spawnnerfun(); } }
        if (Uicontroller.wave == 5) {         if (Time.time % 5 > 0 && Time.time % 5 < 0.08) { spawnnerfun(); } }
        if (Uicontroller.wave == 6) {         if (Time.time % 5 > 0 && Time.time % 5 < 0.09) { spawnnerfun(); } }
        if (Uicontroller.wave == 7) {         if (Time.time % 5 > 0 && Time.time % 5 < 0.1) { spawnnerfun(); } }
    }

    public void spawnnerfun()
    {
        int randspawn = Random.Range(1, 16);

        if (Time.time<60f)
        {
          randobj = Random.Range(1, 2);
        }
        if (Time.time>60f && Time.time <120f)
        {
            randobj = Random.Range(1, 3);
        }
        if (Time.time>120f && Time.time <180f)
        {
            randobj = Random.Range(1, 4);
        }
        if (Time.time>180f && Time.time <240f)
        {
            randobj = Random.Range(1, 5);
        }
        if (Time.time>240f && Time.time <300f)
        {
            randobj = Random.Range(1,6);
        }




        enemy go = objDict[randobj].Dequeue();
        movement movement = go.enemyname.GetComponent<movement>();
        movement.life = go.lives;
        go.enemyname.transform.position = spawnner[randspawn].transform.position;
        go.enemyname.transform.rotation = spawnner[randspawn].transform.rotation;
        go.enemyname.SetActive(true);
        objDict[randobj].Enqueue(go);
    }
}
