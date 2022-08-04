using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shrimp : MonoBehaviour
{
    Shrimp me;
    Rigidbody2D rb;

    void Start()
    {
        me = this;
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(Random.Range(-70, 70), Random.Range(-30, 30), 0);
    }

    void Update()
    {
        //var fruit_salad_yummy_yummy = "not too shabby dawg";

        var player = GameObject.FindGameObjectWithTag("Player");

        var distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 6)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -3f * Time.deltaTime);
        }
        else if (distance > 70 && rb.IsSleeping())
        {
            transform.position = new Vector3(Random.Range(-70, 70), Random.Range(-30, 30), 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Scoretext.Points++;
            transform.position = new Vector3(Random.Range(-70, 70), Random.Range(-30, 30), 0);
        }
        else if (collision.gameObject.tag == "Shark")
        {
            transform.position = new Vector3(Random.Range(-70, 70), Random.Range(-30, 30), 0);
        }

    }
}
