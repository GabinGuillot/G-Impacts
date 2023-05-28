using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour
{
    public float doubleTapTimeThreshold = 0.3f;  // Temps entre chaque clic pour que ce soit un double clic
    public float doubleTapDistanceThreshold = 0.5f; 
    public float dashDistance = 5f;  // Distance du dash
    public float dashSpeed = 10f;  // Vitesse du dash
    public float dashCooldown = 3f;  // Cooldown entre chaque dash
    private float lastTapTime;  
    private Vector3 lastTapPosition; 
    private bool canDash = true;  // Check si le dash est up

    private Vector3 dashStartPosition;
    private Vector3 dashTargetPosition;
    private float dashStartTime;
    private bool isDashing = false;

    void Update()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            float timeSinceLastTap = Time.time - lastTapTime;
            Vector3 currentTapPosition = Input.GetButton("Vertical") ? Vector3.zero : Vector3.one;

            float distanceSinceLastTap = Vector3.Distance(currentTapPosition, lastTapPosition);

            if (timeSinceLastTap <= doubleTapTimeThreshold && distanceSinceLastTap <= doubleTapDistanceThreshold)
            {
                
                if (canDash)
                {
                    Dash();
                }
            }
            else
            {
                lastTapTime = Time.time;
                lastTapPosition = currentTapPosition;
            }
        }

        if (isDashing)
        {
            float dashElapsedTime = Time.time - dashStartTime;
            float dashProgress = Mathf.Clamp01(dashElapsedTime * dashSpeed / dashDistance);
            transform.position = Vector3.Lerp(dashStartPosition, dashTargetPosition, dashProgress);
            if (dashProgress >= 1f)
            {
                isDashing = false;
                Debug.Log("Dash complete!");
                canDash = false;
                Invoke("ResetDash", dashCooldown);
            }
        }
    }

    void Dash()
    {
        Vector3 dashDirection = Vector3.right * Input.GetAxis("Horizontal") + Vector3.forward * Input.GetAxis("Vertical");
        dashDirection = dashDirection.normalized;
        
        dashStartPosition = transform.position;
        dashTargetPosition = dashStartPosition + dashDirection * dashDistance;
        
        isDashing = true;
        dashStartTime = Time.time;
    }

    void ResetDash()
    {
        canDash = true;
    }
}
