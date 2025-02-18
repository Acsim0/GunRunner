using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateshootingpoint : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    ScreenScript screen;
    Transform player;
    void Start()
    {
        screen = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenScript>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}
