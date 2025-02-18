using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{

    public Transform shootingPoint;
    public GameObject bulletPrefab;

    public bool fireContinously;

    float lastbulletshot;

    public float Bulletdelay = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireContinously = Input.GetMouseButton(0);

        if (Input.GetMouseButtonDown(0) || fireContinously )
        {
            if (Time.time - lastbulletshot > Bulletdelay)
            {
                Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);

                lastbulletshot = Time.time;
            }
            
        }
        

    }

   
}
