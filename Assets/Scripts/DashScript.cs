using System.Collections;
using UnityEngine;
 
public class PlayerDash : MonoBehaviour
{
    private bool canDash = true;
    public float dashingPower = 6f;
    private float dashingTime = 0.1f;
    private float dashingCooldown = 1f;
 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
 
    // To track the dash direction, which will be based on the seal's facing direction (transform.up)
    private Vector2 dashDirection;
 
    private void Update()
    {
        // Trigger dash with LeftShift if the player can dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
 
        // Get the facing direction of the seal (transform.up is the forward-facing direction)
        dashDirection = transform.up;  // This is the direction the seal is facing based on its rotation
    }
 
    private IEnumerator Dash()
    {
        canDash = false;
 
        // Store the original gravity
        float originalGravity = rb.gravityScale;
 
        // Temporarily turn off gravity for the dash
        rb.gravityScale = 0f;
 
        // Set the dash velocity based on the direction the seal is facing (transform.up)
        rb.linearVelocity = dashDirection * dashingPower;
 
        // Enable the trail effect during dash
        tr.emitting = true;
 
        // Wait for the dash duration
        yield return new WaitForSeconds(dashingTime);
 
        // Disable the trail effect after dash
        tr.emitting = false;
 
        // Restore gravity to the original state
        rb.gravityScale = originalGravity;
 
        // Wait for the cooldown before the next dash
        yield return new WaitForSeconds(dashingCooldown);
 
        canDash = true;
    }
}