using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text scoreText;
    private int meters;

    private const float MAX_COUNT_DELAY = 0.3f;
    private float countDelay;


    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

        countDelay = MAX_COUNT_DELAY;
    }

    private void Update()
    {
        countDelay -= Time.deltaTime;
        if (countDelay < 0)
        {
            countDelay = MAX_COUNT_DELAY;
            meters++;
        }

        scoreText.text = meters + "m";
    }
}
