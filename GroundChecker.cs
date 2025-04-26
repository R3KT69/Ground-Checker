using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private bool isGrounded = false;
    private static Collider[] groundHits = new Collider[10];  // This array is for NonAlloc version of GroundCheckSphere (more fast), array size = accuracy

    public bool GroundCheckV2(Transform feetTransform, float sphereRadius, LayerMask groundMask)
    {
        Collider[] colliders = Physics.OverlapSphere(feetTransform.position, sphereRadius, groundMask);
        return colliders.Length > 0;
    }
    
    // Returns whether the player is grounded
    public bool IsGrounded()
    {
        return isGrounded;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Player is grounded.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Player left the ground.");
        }
    }

    // Gizmos for view in scene view
    private void OnDrawGizmos()
      {
          if (feetTransform == null) return;
          bool grounded = GroundCheckV1(feetTransform, sphereRadius, groundMask);
          Gizmos.color = grounded ? Color.green : Color.red;
          Gizmos.DrawWireSphere(feetTransform.position, sphereRadius);
      }
}
