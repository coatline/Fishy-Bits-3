using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public float speed;
    bool playerDead;
    GameObject player;
    SpriteRenderer sr;
    float chaseTimer;
    bool chasing;
    Vector3 patrolTarget;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(Random.Range(Random.Range(60, 70), Random.Range(-70, -60)), 0, 0);
        player = GameObject.FindGameObjectWithTag("Player");
        patrolTarget = transform.position;
        chasing = true;
        chaseTimer = Random.Range(4f, 8f);
    }

    void Update()
    {
        if (player == null)
            return;

        chaseTimer -= Time.deltaTime;

        if (chaseTimer <= 0)
        {
            chasing = !chasing;
            chaseTimer = chasing ? Random.Range(4f, 8f) : Random.Range(3f, 6f);

            if (!chasing)
                patrolTarget = transform.position;
        }

        if (chasing)
        {
            if (player.transform.position.x < transform.position.x)
                sr.flipX = true;
            else
                sr.flipX = false;

            if (!playerDead)
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
            else
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * -speed);
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (Vector3.Distance(transform.position, patrolTarget) < 1f)
        {
            patrolTarget = transform.position + new Vector3(Random.Range(-20f, 20f), Random.Range(-10f, 10f), 0f);
        }

        sr.flipX = patrolTarget.x < transform.position.x;
        transform.position = Vector3.MoveTowards(transform.position, patrolTarget, Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDead = true;
        }
    }
}