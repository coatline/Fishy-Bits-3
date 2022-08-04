using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoretext : MonoBehaviour {

    static Scoretext staticScore;

    Text scoreText;

    int points;

    public static int Points
    {
        get { return staticScore.points; }
        set
        {
            staticScore.points = value;
            staticScore.scoreText.text = "" + staticScore.points;

        }
    }

    void Awake()
    {
        staticScore = this;
        scoreText = GetComponent<Text>();
    }

}
