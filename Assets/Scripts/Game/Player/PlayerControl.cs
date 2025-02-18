using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;
    ScreenScript screen;
    float pushed;
    bool Shop;
    public float health;
    public bool locked = false;
    float Dash;
    public int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        Shop = false;
        rb = GetComponent<Rigidbody2D>();
        screen = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenScript>();

    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (locked == false)
            {
                locked = true;
                Dash = Time.time;
            }
            
            
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (Shop == false)
            {
                screen.NextRoom("Shop");
                Shop = true;

            }
            else
            {
                if (Shop == true)
                {
                    screen.NextRoom("Back");
                    Shop = false;

                }
            }
        }
        
        if (locked == false)
        {
            speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
            speedY = Input.GetAxisRaw("Vertical") * movSpeed;
            rb.velocity = new Vector2(speedX, speedY);
        }
        else
        {
            
            rb.velocity = new Vector2(speedX * 8, speedY * 8);
            if (Time.time >= 0.2 + Dash)
            {
                locked = false;
            }

        }
        


        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;

       

    }
}
