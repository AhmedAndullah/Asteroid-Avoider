using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text gameOverText;
    public AsteroidSpawner ap;
    public ScoreSystem ss;
    public GameObject gamelauncher;

    public void crash()
    {
        gamelauncher.SetActive(true);
        ap.enabled = false;
        ss.EndTimer();
        displayScore();
        gameObject.SetActive(false);
    }

    public void displayScore()
    {
        gameOverText.text = "your score is " + ScoreSystem.finalscore;
    }
}
