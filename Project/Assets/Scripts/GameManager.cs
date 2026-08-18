
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject bubblePrefab;
    public GameObject shrimpPrefab;
    public GameObject sharkPrefab;
    float sharkTimer;
    float shrimpTimer;

    void Start () {

        for(int i = 0; i < 100; i++)
        {
            Instantiate(shrimpPrefab);
        }

		for(int i = 0; i < 70; i++)
        {
            Instantiate(bubblePrefab);
        }

        for (int i = 0; i < 1; i++)
        {
            Instantiate(sharkPrefab);
        }
    }

    private void Update()
    {
        if (sharkTimer > 20)
        {
            Instantiate(sharkPrefab);
            sharkTimer = 0;
        }
        else
            sharkTimer += Time.deltaTime;

        if (shrimpTimer > 0.25f)
        {
            Instantiate(shrimpPrefab);
            shrimpTimer = 0;
        }
        else
            shrimpTimer += Time.deltaTime;
    }

}
