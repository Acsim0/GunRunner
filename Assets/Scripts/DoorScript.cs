using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    ScreenScript screen;
    private bool Playerdetected;
    public GameObject MainCamera;
    public float Camerapostiony;
    public float Camerapostionx;

    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenScript>();



        Playerdetected = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Playerdetected)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Camerapostionx += 30;
                screen.NextRoom("Right");

            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Playerdetected = true;

        }



    }
}