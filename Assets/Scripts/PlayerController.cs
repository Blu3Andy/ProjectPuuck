using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputMaster input;
    private Rigidbody rb;
    private Animator animator;

   
    [SerializeField] private float speed;
    [SerializeField] private float maxWalkSpeed = 10f;
    [SerializeField] private float maxSprintSpeed = 15f;
    [SerializeField] private float boostRegulator = 0.5f;

    [SerializeField] private UnityEvent ragdollEvent;
    [SerializeField] private UnityEvent<bool> walkSetSFXEvent;
    [SerializeField] private UnityEvent <bool> SlideSetSFXEvent;
    private float maxSpeed;
    
    private Vector2 moveInput;
    private Vector3 movement;
    private Transform mainCamera;

    private string currentAnimation;

    void Awake()
    {
        input = new InputMaster();
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
    }
    
    void Start()
    {
        maxSpeed = maxWalkSpeed;
    }

    void Update()
    {
        
        if (moveInput != Vector2.zero)
        {
            Move();
            PlayAnimation("Run");
        }
        else
        {
            PlayAnimation("Idle");
        }    
    }



    private  void Move()
    {
        Vector3 acutalForward = Vector3.Cross(mainCamera.right, gameObject.transform.up);
        Vector3 actualRight = Vector3.Cross(gameObject.transform.up, acutalForward);

        Vector3 direction = (acutalForward * movement.z + actualRight * movement.x).normalized;

        //transform.position += speed * Time.deltaTime * direction;

        Quaternion targetRotation = Quaternion.LookRotation(direction, transform.up);

        Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * 3f);
        rb.MoveRotation(newRotation);

        if(rb.velocity.magnitude <= maxSpeed) rb.AddForce(direction * speed, ForceMode.Force);
    }

    public void OnWalkInput(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            moveInput = Vector2.zero;
            return;
        }
       
        moveInput = context.ReadValue<Vector2>();

        movement = new Vector3(moveInput.x, 0, moveInput.y).normalized;
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started) maxSpeed = maxSprintSpeed;
        if (context.canceled) maxSpeed = maxWalkSpeed;
    }

    public void StartRagdoll()
    {
        if (this.enabled == false) return;
        ragdollEvent.Invoke();
        if (rb.velocity.magnitude > maxWalkSpeed) rb.AddForce(rb.velocity * boostRegulator, ForceMode.Impulse);
        
    }

    public void SetCamera(Transform cam)
    {
        print(cam.transform.name);
        mainCamera = cam;
    }
    public void StopPlayer()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void EnablePlayer()
    {
        transform.position += new Vector3(0, 0.3f, 0);
    }

    private void PlayAnimation(string animation)
    {
        if (currentAnimation != animation) animator.CrossFade(animation, 0.3f);
        currentAnimation = animation;
    }

    void OnEnable()
    {
        input.Player.Enable();
        mainCamera = Camera.main.transform;

        walkSetSFXEvent.Invoke(true);
        SlideSetSFXEvent.Invoke(false);
    }

    void OnDisable()
    {
        input.Disable();

        walkSetSFXEvent.Invoke(false);
        SlideSetSFXEvent.Invoke(true);
        
    }

    public float GetSpeed()
    {
        return rb.velocity.magnitude;
    }
}
