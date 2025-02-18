using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarCanvasScript : MonoBehaviour
{
    public Transform enemy;



    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float z = enemy.transform.rotation.z;
        transform.localRotation = Quaternion.Euler(0, 0, z);
    }
}
