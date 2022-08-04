
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject bubblePrefab;
    public GameObject shrimpPrefab;
    public GameObject sharkPrefab;

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
	

}
