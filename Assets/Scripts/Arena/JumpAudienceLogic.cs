using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAudienceLogic : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 0.5f;
    public bool isGrounded;
    private Rigidbody rb;
    private bool startJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    	jump = new Vector3(0.0f, 1.0f, 0.0f);
    }
    void OnCollisionStay()
    {
        isGrounded = true;
        startJumping = false;
    }

    void Update()
    {
        if (startJumping && isGrounded)
        {
            
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    
    public void StartMemberJumping()
    {
        startJumping = true;
    }
}
