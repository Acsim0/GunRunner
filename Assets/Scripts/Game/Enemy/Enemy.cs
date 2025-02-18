using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float maxhealth = 100;
    public float health;
    public Transform target;
    public float damage;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    public GameObject coin;


    public Healthbar healthbar;
    public Transform Canvas;
    Animator animator;
    bool attack = false;
    public EnemySpawnerScript enemies;

    public void TakeDamage(float damage)
    {
        health -= damage;

        healthbar.SetHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }





    void Die()
    {
        float amount = Random.Range(maxhealth * 0.4f, maxhealth * 0.6f);
        for (int i = 0; i < amount; i++)
        {
            Instantiate(coin, new Vector3(transform.position.x + Random.Range(-2.0f,3.0f), transform.position.y + Random.Range(-2.0f, 3.0f), 0), Quaternion.identity);
        }
        enemies = GameObject.FindGameObjectWithTag("Enemyspawner").GetComponent<EnemySpawnerScript>();
        enemies.Enemies.Remove(gameObject);
        Destroy(gameObject);
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxhealth;
        animator = GetComponent<Animator>();
        healthbar.SetMaxHealth(maxhealth);
    }

    float timeUntilMelee;
    private void Update()
    {
        Canvas.transform.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
        if(attack == false)
        {
            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = transform.up * 0;
        }

        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        float distance = Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if (timeUntilMelee <= 0f) {
            if (distance <= 4f)
            {
                animator.SetTrigger("Attack");
                timeUntilMelee = 1.3f;
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }

        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

    }

    public void Attackwake()
    {
        attack = false;
    }
    public void Attacksleep()
    {
        attack = true;
    }

    private void FixedUpdate()
    {
        //Move Forwards
        
    }

    public float sinput = 5;
    private void RotateTowardsTarget()
    {
        if (attack == false)
        {
            rotateSpeed = sinput;
            Vector2 targetDirection = target.position - transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
        }
        else
        {
            rotateSpeed = 0;
        }
    }


    private void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    public GameObject player;
    

}