using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript2 : MonoBehaviour
{
    Transform player;
    ScreenScript screen;
    public bool Playerdetected;
    public GameObject MainCamera;
    public float Camerapostiony;
    public float Camerapostionx;
    float TriggerTime;
    public bool touched;

    // Start is called before the first frame update
    void Start()
    {
        screen = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenScript>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        touched = false;
        Playerdetected = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (Playerdetected)
        {
            if (Time.time - TriggerTime > 0.1)
            {
                
                Playerdetected = false;
            }
            if (Input.GetKeyDown(KeyCode.E) && touched == false )
            {
                touched = true;
                if ((player.transform.position.x < transform.position.x) && (player.transform.position.y < (transform.position.y + 0.5) && player.transform.position.y > (transform.position.y + -0.5)))
                {
                    
                    screen.NextRoom("Right");
                    Debug.Log("Detected Right");
                }
                else
                {
                    if ((player.transform.position.x > transform.position.x) && (player.transform.position.y < (transform.position.y + 0.5) && player.transform.position.y > (transform.position.y + -0.5)))
                    {

                        screen.NextRoom("Left");
                        Debug.Log("Detected Left");
                    }
                    else
                    {
                        if ((player.transform.position.y > transform.position.y) && (player.transform.position.x < (transform.position.x + 0.5) && player.transform.position.x > (transform.position.x + -0.5)))
                        {

                            screen.NextRoom("Down");
                            Debug.Log("Detected Down");
                        }
                        else
                        {
                            if ((player.transform.position.y < transform.position.y) && (player.transform.position.x < (transform.position.x + 0.5) && player.transform.position.x > (transform.position.x + -0.5)))
                            {

                                screen.NextRoom("Up");
                                Debug.Log("Detected Up");
                            }
                        }
                    }
                    
                }
                Invoke("release", 0.1f);
            }
        }
    }
    void release()
    {
        touched = false;
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
