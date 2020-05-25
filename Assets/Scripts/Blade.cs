using UnityEngine;

public class Blade : MonoBehaviour
{
    // Note: Drag and drop BladeTrail prefab to this
    public GameObject bladeTrailPrefab;

    bool isCutting = false;

    Vector2 previosPosition;

    GameObject currentBladeTrail;

    // Access the Rigidbody2D component on Unity
    // Make sure to add Rigidbody2D component on the Blade object
    // Also set the Body Type in Rigidbody2D component to Kinematic to prevent it from falling
    Rigidbody2D rb;

    // Access the Carmera on Unity
    Camera cam;

    CircleCollider2D circleCollider;

    void Start()
    {
        // Get the reference to Camera
        cam = Camera.main;

        // Get the reference to Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Get the reference to CircleCollider2D
        circleCollider = GetComponent<CircleCollider2D>();
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
        // ScreenToWorldPoint to make the corrdinates the same as mouse position
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        // Get the distance travel over time
        float velocity = (newPosition - previosPosition).magnitude;
    }

    void StartCutting()
    {
        isCutting = true;

        // Add BladeTrail prefab to a parent Blade object
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);

        circleCollider.enabled = true;
    }

    void StopCutting()
    {
        isCutting = false;

        // Stop the showing of BladeTrail prefab
        currentBladeTrail.transform.SetParent(null);

        // Remove BladeTrail prefab from the parent Blade object in 2 second
        Destroy(currentBladeTrail, 2f);

        circleCollider.enabled = false;
    }
}
