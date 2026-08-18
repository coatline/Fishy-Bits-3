using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int level = 1;
    SpriteRenderer sr;
    Vector2 mousePos;
    public float speed;
    Rigidbody2D rb;
    public Sprite[] fishySprites;
    public Sprite[] deathSprites;
    public Image bar;
    public GameObject diedText;

    bool died;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        if (fishySprites.Length > 0)
            sr.sprite = fishySprites[0];
    }

    void Update()
    {
        if (died)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(0);
            return;
        }

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var rot = Quaternion.FromToRotation(Vector3.right, mousePos - (Vector2)transform.position);

        transform.rotation = rot;

        if (Vector3.Distance(mousePos, transform.position) > 0.2f)
            transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shark"))
        {
            // change sprite to dead sprite
            if (level <= deathSprites.Length)
                sr.sprite = deathSprites[level - 1];
            else
                sr.sprite = deathSprites[deathSprites.Length - 1];

            died = true;
            rb.linearVelocity = new Vector2(0, 0);
            rb.gravityScale = .02f;
            diedText.SetActive(true);
        }

        //if certain mass, change the sprite (evolve)
        else if (collision.gameObject.CompareTag("Shrimp"))
        {
            transform.localScale += new Vector3(.1f, .1f, 0);
            rb.mass += .1f;
            speed -= rb.mass / 4;
            bar.fillAmount += .1f;
            if (rb.mass > 1f)
            {
                //level text
                level++;
                bar.fillAmount = 0;
                speed = 10;
                rb.mass = .01f;

                if (level <= fishySprites.Length)
                    sr.sprite = fishySprites[level - 1];
                else
                {
                    transform.localScale *= 1.1f;
                    Camera.main.orthographicSize += 0.2f;
                }
            }
        }
    }
}
