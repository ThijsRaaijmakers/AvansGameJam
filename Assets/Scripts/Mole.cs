using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour
{
    // Range for randomization
    public Vector2 showDurationRange = new Vector2(1f, 3f); // Range for show duration
    public Vector2 delayBetweenRange = new Vector2(0.5f, 1.5f); // Range for delay between hiding and showing again

    private bool clicked = false;

    private void Start()
    {
        // Start the coroutine
        StartCoroutine(ShowHideObject());
    }

       void Update()
    {
        // Check for mouse button click
        if (Input.GetMouseButtonDown(0)) // Change 0 to 1 if you want to detect right-clicks
        {
            // Get the mouse position in world coordinates
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            // Raycast to detect if the click hits a collider
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            // If the click hits a collider
            if (hit.collider != null)
            {
                // Check if the collider belongs to a sprite
                if (hit.collider.CompareTag("Mole")) // Replace "SpriteTag" with the tag of your sprite
                {
                    // Disable the sprite renderer to make it disappear
                    hit.collider.GetComponent<SpriteRenderer>().enabled = false;
                    
                    // Optionally, you can also destroy the GameObject
                    // Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    IEnumerator ShowHideObject()
    {
        while (true)
        {
            // Randomize durations
            float showDuration = Random.Range(showDurationRange.x, showDurationRange.y);
            float delayBetween = Random.Range(delayBetweenRange.x, delayBetweenRange.y);

            // Wait for random delay before showing
            yield return new WaitForSeconds(delayBetween);

            // Show the object
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

            // Reset click status
            clicked = false;

            // Wait for click
            while (!clicked)
            {
                yield return null;
            }

            // Reset click status
            clicked = false;

            // Delay before showing again
            yield return null;
        }
    }

    private void OnMouseDown()
    {
        clicked = true;
    }
}
