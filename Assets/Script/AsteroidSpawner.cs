using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject nextSceneButton; // Assign the button in the inspector

    public GameObject[] asteroidPrefabs;
    public float secondsbetweenAsteroids = 1.0f;
    public Vector2 forceRange;
    public Camera cam;
     float timer;
     public GameObject LevelComplete;
     public float levelCompleteTime = 5f; // Time to trigger Level Complete

     void Start()
     {
         timer = 0; // Initialize timer
     }

     void Update()
     {
         timer += Time.deltaTime; // Increment timer

         if (timer >= levelCompleteTime)
         {
             LevelComplete.SetActive(true);
             // Disable this script or stop spawning asteroids if needed
             this.enabled = false;
         }
         else if (timer < levelCompleteTime && timer % secondsbetweenAsteroids < Time.deltaTime)
         {
             spawnAsteroid();
         }
     }


    public void spawnAsteroid()
    {
        int side = Random.Range(0, 4);
        Vector2 spawnPoints = Vector2.zero;
        Vector2 direction = Vector2.zero;
        
        switch (side)
        {
            case 0 :
                spawnPoints.x = 0;
                spawnPoints.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1 :
                spawnPoints.x = 1;
                spawnPoints.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 2:
                spawnPoints.y = 0;
                spawnPoints.x = Random.value;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
            case 3:
                spawnPoints.y = 1;
                spawnPoints.x = Random.value;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
        }

        Vector3 worldSpawnPoint = cam.ViewportToWorldPoint(spawnPoints);
        worldSpawnPoint.z = 0;
        Debug.Log(spawnPoints);
        GameObject selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
        GameObject asteroidInstance =
            Instantiate(selectedAsteroid, worldSpawnPoint, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }
    void ShowNextSceneButton()
    {
        if (nextSceneButton != null)
        {
            nextSceneButton.SetActive(true);
        }
    }
}
