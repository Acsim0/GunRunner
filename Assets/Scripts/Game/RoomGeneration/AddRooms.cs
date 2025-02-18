using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class AddRooms : MonoBehaviour
{

    private RoomTemplates templates;
    private RoomSpawner spawner;


    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawnpoint").GetComponent<RoomSpawner>();
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
        Invoke("Reload", 2.1f);
        
    }
    public void Reload()
    {
        if (templates.rooms.Count <= 20 || templates.rooms.Count >= 40)
        {
            Debug.Log(templates.rooms.Count);
            spawner = GameObject.FindGameObjectWithTag("Spawnpoint").GetComponent<RoomSpawner>();
            spawner.spawned = false;
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        else
        {
            spawner.Approve = true;
            Debug.Log(templates.rooms.Count);
            SceneManager.UnloadSceneAsync("Loading");
        }
        
    }

    public void DestroyME()
    {
        if (templates.rooms.Count <= 20 || templates.rooms.Count >= 40)
        {
            Destroy(gameObject);
        }

    }
    private void SpawnNew()
    {
       
        spawner = GameObject.FindGameObjectWithTag("Spawnpoint").GetComponent<RoomSpawner>();
        spawner.spawned = false;
        spawner.WaitSpawn();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
