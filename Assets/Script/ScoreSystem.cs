using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text scoreText;
    public float scoreMultiplier;
    private bool shouldCount = true;
    private float score;
    public static int finalscore;
    void Update()
    {
        if (!shouldCount)
        {
            return;
        }

        score += Time.deltaTime * scoreMultiplier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public void StartTimer()
    {
        shouldCount = true;
    }

    public void EndTimer()
    {
        shouldCount = false;
        finalscore = (int)score;
        scoreText.text = string.Empty;
    }
}
