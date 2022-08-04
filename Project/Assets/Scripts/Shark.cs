using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour {

    bool playerDead;
    GameObject player;
    SpriteRenderer sr;
    //Rigidbody2D rb;

	void Start () {
        sr = GetComponent<SpriteRenderer>();
        //rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(Random.Range(Random.Range(60, 70), Random.Range(-70, -60)), 0, 0);
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	void Update () {
        //Vector3 targetDir = player.transform.position - transform.position;

        //Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 1 * Time.deltaTime, 0.0f);

        //transform.LookAt(player.transform.position);
        if(player.transform.position.x < transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if (!playerDead)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, 1f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, -1f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDead = true;
        }
    }
}
