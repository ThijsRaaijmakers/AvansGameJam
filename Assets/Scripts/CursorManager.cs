using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorTexture;
    private AudioSource audioSource;
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0)) // 0 for left mouse button, 1 for right mouse button
        {
            // Play the sound
            audioSource.Play();
        }
    }
}
