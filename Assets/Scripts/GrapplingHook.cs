using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private float grappleLength; // Maximum reach of the hook shot
    [SerializeField] private float stretchTo; // The desired fixed length of the joint once connected
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer rope;
    [SerializeField] private float ropeMissVisibleDuration = 0.3f; // Time (seconds) the rope is visible if it misses

    private Vector3 grapplePoint;
    private DistanceJoint2D joint;
    private bool isGrappling = false; // Is the joint active/hooked?
    private Coroutine hideCoroutine = null; // Reference to the coroutine that hides the rope

    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
        if (joint == null)
        {
            Debug.LogError("DistanceJoint2D component not found on this GameObject!", this);
            // Optionally add the component if it's missing
            // joint = gameObject.AddComponent<DistanceJoint2D>();
        }
        joint.enabled = false;
        rope.enabled = false;
        // Ensure the joint doesn't auto-configure distance, we will set it manually
        joint.autoConfigureDistance = false;
    }

    void Update()
    {
        // --- Start Firing / Attempt Grapple ---
        if (Input.GetMouseButtonDown(0))
        {
            // If there's a coroutine to hide the previous rope, stop it
            if (hideCoroutine != null)
            {
                StopCoroutine(hideCoroutine);
                hideCoroutine = null;
            }
            // Reset state if firing again quickly (even if already grappling, rare but possible)
            if (isGrappling)
            {
                joint.enabled = false;
                isGrappling = false;
            }


            // Calculate direction and origin
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            Vector3 currentPosition = transform.position; // Save position at the moment of firing
            Vector2 direction = (mouseWorldPos - currentPosition).normalized;

            // Cast Raycast
            RaycastHit2D hit = Physics2D.Raycast(
                origin: currentPosition,
                direction: direction,
                distance: grappleLength,
                layerMask: grappleLayer
            );

            Vector3 ropeEndPoint; // End point for the visual rope

            // Check if we hit something
            if (hit.collider != null)
            {
                // --- Successful Grapple ---
                grapplePoint = hit.point;
                ropeEndPoint = grapplePoint; // Rope ends at the collision point

                // Configure and activate the Joint
                joint.connectedAnchor = grapplePoint;
                // *** CHANGE HERE: Use stretchTo for the joint distance ***
                joint.distance = stretchTo;
                // *********************************************************
                joint.enabled = true;
                isGrappling = true; // Mark that we are grappling

                // Debug.Log("Hook CONNECTED!"); // For testing
            }
            else
            {
                // --- Failed Grapple ---
                ropeEndPoint = currentPosition + (Vector3)direction * grappleLength; // Rope goes to max length
                isGrappling = false; // Not grappling
                joint.enabled = false; // Ensure the joint is disabled

                // Start the coroutine to hide the rope after a delay
                hideCoroutine = StartCoroutine(HideRopeAfterDelay(ropeMissVisibleDuration));

                // Debug.Log("Hook FAILED!"); // For testing
            }

            // --- Always Show Rope When Firing ---
            rope.SetPosition(0, ropeEndPoint);      // End point (anchor or end of miss)
            rope.SetPosition(1, currentPosition);   // Start point (player at the moment of firing)
            rope.enabled = true;                    // Make the rope visible
        }

        // --- Release Hook ---
        if (Input.GetMouseButtonUp(0))
        {
            // Stop the hide coroutine if active (important if released before miss timer ends)
            if (hideCoroutine != null)
            {
                StopCoroutine(hideCoroutine);
                hideCoroutine = null;
            }

            // Deactivate the joint if it was active
            if (isGrappling)
            {
                joint.enabled = false;
                isGrappling = false;
            }
            // Always hide the rope on release
            rope.enabled = false;
        }

        // --- Update Rope Position (if visible) ---
        if (rope.enabled)
        {
            // The end of the rope connected to the player always follows the player
            rope.SetPosition(1, transform.position);

            // Optional: If grappling, ensure the anchor point doesn't visually drift
            // This helps keep the visual rope anchored correctly even if the physics simulation
            // slightly moves the effective anchor point internally.
            if (isGrappling)
            {
                rope.SetPosition(0, grapplePoint);
            }
        }
    }

    // Coroutine to hide the rope after a delay (only used on grapple miss)
    IEnumerator HideRopeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Double-check: Hide only if NOT grappling and the rope is still enabled
        // (We might have released the button in the meantime, which already hides it)
        if (!isGrappling && rope.enabled)
        {
            rope.enabled = false;
            // Debug.Log("Hiding missed rope (coroutine)"); // For testing
        }
        hideCoroutine = null; // Mark that the coroutine has finished
    }
}