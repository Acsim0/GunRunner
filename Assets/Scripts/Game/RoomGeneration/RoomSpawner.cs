using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 = need bottom
    // 2 = need top
    // 3 = need left
    // 4 = need right

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;
    public bool Approve = false;
    public GameObject Gras;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);

    }

    public void WaitSpawn()
    {
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    public void Spawn()
    {
        if (spawned == false)
        {
            if (Time.time > 2 && Approve == true)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
            }
            else if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
            }
            spawned = true;

            Instantiate(Gras, transform.position, Quaternion.identity);
        }
        
    }
    
   


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spawnpoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;

        } 
    }

    private void Update()
    {
        
    }
}
