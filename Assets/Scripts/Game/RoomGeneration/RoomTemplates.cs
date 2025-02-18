using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    private RoomTemplates templates;
    private RoomSpawner spawner;
    private AddRooms AddR;

    void Start()
       
    {
        SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive);
        spawner = GameObject.FindGameObjectWithTag("Spawnpoint").GetComponent<RoomSpawner>();
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        AddR = GameObject.FindGameObjectWithTag("Room").GetComponent<AddRooms>();
    }


        // Update is called once per frame
        void Update()
    {
        if(waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        } else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
