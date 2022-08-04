using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    float speed;
    Rigidbody2D rigidbody2d;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Start () {
        speed = Random.Range(-.1f, -1);
        transform.position = new Vector3(Random.Range(-80, 80), Random.Range(-40, 30), 0);

        rigidbody2d.gravityScale = speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Bubble") && !collision.gameObject.CompareTag("Shrimp"))
        {

            speed = Random.Range(.01f, .1f);

            rigidbody2d.velocity = new Vector3(0, 0, 0);

            transform.position = new Vector3(Random.Range(-80, 80), Random.Range(-35, 10), 0);
        }
    }
}
