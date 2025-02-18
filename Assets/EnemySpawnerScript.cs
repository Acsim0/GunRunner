using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public bool visable = false;
    public GameObject[] Enemys;
    public List<GameObject> Enemies;
    void Start()
    {
        
            
    }

    // Update is called once per frame
    void Update()
    {
        if (visable == true)
        {
            if (Enemies.Count == 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnBecameVisible()
    {
        
        int amount = Random.Range(1, 4);
        for (int i = 0; i < amount; i++)
        {
            int Rand = Random.Range(0, Enemys.Length);
            Enemies.Add(Instantiate(Enemys[Rand], transform.position, Quaternion.identity));
        }
        visable = true;
    }
}
