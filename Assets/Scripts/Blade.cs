using UnityEngine;

public class Blade : MonoBehaviour
{
    bool isCutting = false;

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
