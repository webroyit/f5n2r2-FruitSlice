using UnityEngine;

public class Blade : MonoBehaviour
{
    bool isCutting = false;

    // Access the Rigidbody2D component on Unity
    // Make sure to add Rigidbody2D component on the Blade object
    // Also set the Body Type in Rigidbody2D component to Kinematic to prevent it from falling
    Rigidbody2D rb;

    // Access the Carmera on Unity
    Camera cam;

    void Start()
    {
        // Get the reference to Camera
        cam = Camera.main;

        // Get the reference to Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Listen for press down on the left click of the mouse
        if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        } 
        // Listen for release of the left click of the mouse
        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if(isCutting)
        {
            // Move the pointer
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        // This is in screen coordinates
        // ScreenToWorldPoint to make the corrdinates the same as
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void StartCutting()
    {
        isCutting = true;
    }

    void StopCutting()
    {
        isCutting = false;
    }
}
