using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scratch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float damage;
    GameObject player; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        player = GameObject.FindGameObjectWithTag("Player");
        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerControl>().health -= damage;
        }
    }
}
