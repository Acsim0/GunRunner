using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScript : MonoBehaviour
{
    Transform player;
    private string UD;
    public GameObject Door;
    public float py;
    int roomx = 0;
    int roomy = 0;
    float changex;
    float changey;
    float positionplayerx;
    float positionplayery;
    public bool boss = false;

    private Vector3 offset = new Vector3(0f, 0f, -10);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    void Start()
    {
        transform.position = new Vector3(0, 0, -10);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boss == true)
        {
            Vector3 targetposition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothTime);

        }
        

    }

    public void ChangeRoom()
    {
        
        float changex = (float)(1 * (17.93 * roomx));
        float changey = (float)(1 * (9.961 * roomy));
        transform.position = new Vector3(changex,changey,-10);

    }

    public void NextRoom(string URLD)
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        positionplayerx = player.transform.position.x;
        positionplayery = player.transform.position.y;
        if (URLD == "Shop")
        {
            transform.position = new Vector2(0, 250.65f);
        }
        if (URLD == "Boss")
        {
            boss = true;
            player.transform.position = new Vector2(-250, 0);
        }
        if (URLD == "Right")
        {
            positionplayerx = player.transform.position.x;
            positionplayery = player.transform.position.y;
            roomx += 1;
            player.transform.position = new Vector2(positionplayerx + 1, positionplayery);
            ChangeRoom();
        }
        if (URLD == "Back")
        {
            ChangeRoom();
        }
        if (URLD == "Left")
        {
            roomx += -1;
            player.transform.position = new Vector2(positionplayerx - 1, positionplayery);
            ChangeRoom();
        }
        if (URLD == "Up")
        {
            roomy += 1;
            player.transform.position = new Vector2(positionplayerx, positionplayery + 1);
            ChangeRoom();
        }
        if (URLD == "Down")
        {
            roomy += -1;
            player.transform.position = new Vector2(positionplayerx , positionplayery - 1);
            ChangeRoom();
        }
    }
}
