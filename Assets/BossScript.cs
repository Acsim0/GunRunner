using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    ScreenScript screen;
    public bool Playerdetected = false;
    float TriggerTime;
    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Playerdetected == true)
        {
            if (Time.time - TriggerTime > 0.1)
            {

                Playerdetected = false;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                screen.NextRoom("Boss");
                Playerdetected = false;
            }
            

        }
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Playerdetected = true;
            TriggerTime = Time.time;

        }
    }
}
