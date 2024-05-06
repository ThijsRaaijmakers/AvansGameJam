using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float pointsPerSecond = 1f; // Points gained per second for each invisible object
    
    private float currentPoints = 0f; // Current points earned
    
    void Update()
    {
        // Loop through all GameObjects tagged as "Invisible"
        GameObject[] invisibleObjects = GameObject.FindGameObjectsWithTag("Hit");
        
        // Calculate points based on the number of invisible objects
        float pointsToAdd = invisibleObjects.Length * pointsPerSecond * Time.deltaTime;
        
        // Add points to the current total
        currentPoints += pointsToAdd;
        
        // You can do something with the points here, like displaying them on UI or using them in gameplay
        Debug.Log("Current Points: " + currentPoints);
    }
}
