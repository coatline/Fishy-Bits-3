using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int level = 1;
    SpriteRenderer renderer;
    Vector2 mousePos;
    public float speed;
    Rigidbody2D rb;
    public Sprite[] fishySprites;
    public Sprite[] deathSprites;
    public Image bar;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var rot = Quaternion.FromToRotation(Vector3.right, mousePos - (Vector2)transform.position);

        //Debug.DrawLine(transform.position, mousePos);
        transform.rotation = rot;

        if (Vector3.Distance(mousePos, transform.position) > 0.2f)
            transform.position += transform.right * speed * Time.deltaTime;

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shark"))
        {
            // change sprite to dead sprite
            switch (level)
            {
                case 1:
                    renderer.sprite = deathSprites[0];
                    break;
                case 2:
                    renderer.sprite = deathSprites[1];
                    break;
            }

            enabled = false;
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = .02f;
            if (!enabled)
            {
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }

        //if certain mass, change the sprite (evolve)
        else if (collision.gameObject.CompareTag("Shrimp"))
        {
            transform.localScale += new Vector3(.1f, .1f, 0);
            rb.mass += .05f;
            speed -= rb.mass / 4;
            bar.fillAmount += .05f;
            if (rb.mass > 1f)
            {
                //level text
                level++;
                bar.fillAmount = 0;
                speed = 10;
                rb.mass = .01f;
                switch (level)
                {

                    case 1:
                        renderer.sprite = fishySprites[0];
                        break;
                    case 2:
                        renderer.sprite = fishySprites[1];
                        break;
                    case 3:
                        renderer.sprite = fishySprites[2];
                        break;
                    case 4:
                        renderer.sprite = fishySprites[3];
                        break;
                    case 5:
                        renderer.sprite = fishySprites[4];
                        break;
                }

                print(renderer.sprite);
                transform.localScale = new Vector3(8, 8, 0);
            }
        }
    }
}
