using UnityEngine;

public class HandlePlayerJumping : MonoBehaviour
{
    //script attachted to player and handles the jumping of the player
    
    static bool isgrounded;
   
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     
        isgrounded = HandleFeet.isGrounded;

        if (Input.GetKey(KeyCode.Space) && isgrounded)
        {
            if (HandlePlayerMovement.stamina >= 50f)
            {
                HandlePlayerMovement.stamina = HandlePlayerMovement.stamina - 50f;
            }
            else
            {
                HandlePlayerMovement.stamina = 0f;
            }
                rb.AddForce(Vector3.up * 150, ForceMode.Impulse);
            HandleFeet.isGrounded = false;
            isgrounded= false;
        }
    }

}
