using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class F_PlayerLook : MonoBehaviour
{
    public int mouseSensitivity; // Sensitivity of the mouse movement

    public Transform playerCamera; // Reference to the player's camera transform

    float xRotation, yRotation; // Variables to store rotation values
    private float mouseX, mouseY; // Variables to store mouse X & Y-axis movement

 
    void Start()
    {
        // Locks the cursor to the center of the screen and hides it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Scaling mouse movement by deltaTime and sensitivity
        mouseX *= Time.deltaTime * mouseSensitivity;
        mouseY *= Time.deltaTime * mouseSensitivity;

        // Adjusting yRotation based on mouseX movement
        yRotation += mouseX;

        // Adjusting xRotation based on mouseY movement, and clamping it within a range
        //xRotation = mouseY;
        ////  xRotation = Mathf.Clamp(-xRotation, -35f, 40f);
        //// xRotation = Mathf.Clamp(mouseY * playerCamera.rotation.x, -35f, 40f);
        //var rotation = Quaternion.ToEulerAngles(playerCamera.localRotation);
        //rotation.x -= mouseY;
        //xRotation = Mathf.Clamp(rotation.x, -35f, 40f);
        //if (xRotation < -35 || xRotation > 40 ||mouseY == 0)
        //    xRotation = 0;

        //// Quaternion.EulerAngles(playerCamera.rotation.x, 0, 0);
        //// Quaternion.Euler()

        //Debug.Log($"X: {playerCamera.localRotation.x} Y: {playerCamera.localRotation.y} Z: {playerCamera.localRotation.z}");
        // Applying rotation to the player object (for left and right rotation)
         transform.rotation = Quaternion.Euler(0, yRotation, 0);
        //transform.Rotate(0, mouseX, 0);
        //Do we really need to add xRotation here? Why not just do this:
        //transform.rotation = Quaternion.Euler(0, yRotation, 0);

        // Applying rotation to the player's camera (Both vertical and horizontal rotation)
        //  playerCamera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
       // playerCamera.localRotation = Quaternion.Euler(xRotation, 0, 0); // Why did they choose to use rotation and not localRotation? What was the design choice behind it?
       // playerCamera.Rotate(xRotation, 0, 0, Space.Self);


        xRotation -= mouseY; // Reverse mouseY for natural behavior
        xRotation = Mathf.Clamp(xRotation, -35f, 40f); // Clamp the rotation

        // Get the current rotation in degrees
        Vector3 currentRotation = playerCamera.localEulerAngles;

        // Convert to a proper range for pitch (-180 to 180)
        if (currentRotation.x > 180f)
            currentRotation.x -= 360f;

        // Calculate the difference needed to clamp the pitch
        float deltaRotation = xRotation - currentRotation.x;

        // Apply the clamped rotation incrementally
        playerCamera.Rotate(deltaRotation, 0, 0);

    }

    // This method is invoked when the player moves the mouse
    private void OnLook(InputValue input)
    {
        // Getting mouse input values
        mouseX = input.Get<Vector2>().x;
        mouseY = input.Get<Vector2>().y;
    }
}