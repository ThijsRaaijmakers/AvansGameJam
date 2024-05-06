using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public double pointsPerSecond = 0.1; // Points gained per second for each invisible object
    
    private double currentPoints = 0; // Current points earned
    public TMP_Text text;
    
    void Update()
    {
        // Loop through all GameObjects tagged as "Invisible"
        GameObject[] invisibleObjects = GameObject.FindGameObjectsWithTag("Hit");
        
        // Calculate points based on the number of invisible objects
        double pointsToAdd = invisibleObjects.Length * pointsPerSecond * Time.deltaTime;
        
        // Add points to the current total
        currentPoints += pointsToAdd;
        
        // You can do something with the points here, like displaying them on UI or using them in gameplay
        Debug.Log("Current Points: " + currentPoints);
        text.text = currentPoints.ToString("F2");
    }
}
