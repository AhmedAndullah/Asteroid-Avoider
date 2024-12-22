using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            return;
        }

        playerHealth.crash();
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
