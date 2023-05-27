using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour
{
    public float doubleTapTimeThreshold = 0.3f;  // Maximum time between taps to count as a double tap
    public float doubleTapDistanceThreshold = 0.5f;  // Maximum distance between taps to count as a double tap
    public float dashDistance = 5f;  // Distance to dash
    public float dashSpeed = 10f;  // Speed of the dash
    public float dashCooldown = 3f;  // Cooldown time for the dash
    private float lastTapTime;  // Time of the last tap
    private Vector3 lastTapPosition;  // Position of the last tap
    private bool canDash = true;  // Flag to track if the dash is available

    private Vector3 dashStartPosition;
    private Vector3 dashTargetPosition;
    private float dashStartTime;
    private bool isDashing = false;

    void Update()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            float timeSinceLastTap = Time.time - lastTapTime;
            Vector3 currentTapPosition = Input.GetButton("Vertical") ? Vector3.zero : Vector3.one; // Replace with your desired position

            float distanceSinceLastTap = Vector3.Distance(currentTapPosition, lastTapPosition);

            if (timeSinceLastTap <= doubleTapTimeThreshold && distanceSinceLastTap <= doubleTapDistanceThreshold)
            {
                // Double tap detected
                if (canDash)
                {
                    // Perform the dash action
                    Dash();
                }
            }
            else
            {
                // Not a double tap, update the last tap variables
                lastTapTime = Time.time;
                lastTapPosition = currentTapPosition;
            }
        }

        if (isDashing)
        {
            // Perform the dash movement
            float dashElapsedTime = Time.time - dashStartTime;
            float dashProgress = Mathf.Clamp01(dashElapsedTime * dashSpeed / dashDistance);
            transform.position = Vector3.Lerp(dashStartPosition, dashTargetPosition, dashProgress);

            // Check if dash is complete
            if (dashProgress >= 1f)
            {
                isDashing = false;
                Debug.Log("Dash complete!");

                // Disable dashing and start cooldown
                canDash = false;
                Invoke("ResetDash", dashCooldown);
            }
        }
    }

    void Dash()
    {
        // Calculate the dash direction based on the current input
        Vector3 dashDirection = Vector3.right * Input.GetAxis("Horizontal") + Vector3.forward * Input.GetAxis("Vertical");
        dashDirection = dashDirection.normalized;

        // Calculate the dash destination position
        dashStartPosition = transform.position;
        dashTargetPosition = dashStartPosition + dashDirection * dashDistance;

        // Start the dash
        isDashing = true;
        dashStartTime = Time.time;
    }

    void ResetDash()
    {
        // Enable dashing after the cooldown
        canDash = true;
    }
}
