using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    public GameObject minePrefab; 
    public float secondsBetweenMines = 1.5f; 
    public Camera cam; 

    private float timer;

    void Start()
    {
        timer = secondsBetweenMines;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnMine();
            timer = Mathf.Max(secondsBetweenMines, 0.1f); 
        }
    }

    private void SpawnMine()
    {
        Debug.Log("SpawnMine called");

        int side = Random.Range(0, 4); 
        Vector2 spawnPoint = Vector2.zero;

        switch (side)
        {
            case 0: spawnPoint = new Vector2(-0.2f, Random.Range(0f, 1f)); break; 
            case 1: spawnPoint = new Vector2(1.2f, Random.Range(0f, 1f)); break; 
            case 2: spawnPoint = new Vector2(Random.Range(0f, 1f), 1.2f); break; 
            case 3: spawnPoint = new Vector2(Random.Range(0f, 1f), -0.2f); break; 
        }

        Vector3 worldSpawnPoint = cam.ViewportToWorldPoint(new Vector3(spawnPoint.x, spawnPoint.y, 0));
        worldSpawnPoint.z = 0;

        Debug.Log($"Spawning mine at {worldSpawnPoint}");

        if (minePrefab != null)
        {
            Instantiate(minePrefab, worldSpawnPoint, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Mine Prefab is not assigned!");
        }
    }

}