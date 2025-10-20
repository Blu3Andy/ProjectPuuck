using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputMaster input;
    private Rigidbody rb;
    private RagdollController ragDollController;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxWalkSpeed = 10f;
    [SerializeField] private float maxSprintSpeed = 15f;
    

    private Vector2 moveInput;
    private Vector3 movement;

    private Transform mainCamera;

    void Awake()
    {
        input = new InputMaster();
        rb = gameObject.GetComponent<Rigidbody>();
        ragDollController = gameObject.GetComponent<RagdollController>();

        mainCamera = Camera.main.transform;

        input.Player.Movement.started += OnWalkInput;
        input.Player.Movement.performed += OnWalkInput;
        input.Player.Movement.canceled += OnWalkInput;

        input.Player.Sprint.started += i => maxSpeed = maxSprintSpeed;
        input.Player.Sprint.performed += i => maxSpeed = maxSprintSpeed;
        input.Player.Sprint.canceled += i => maxSpeed = maxWalkSpeed;

        input.Player.Ragdoll.started += i => StartRagdoll();
    }
    
    void Start()
    {
        maxSpeed = maxWalkSpeed;
    }

    void Update()
    {
        if (moveInput != Vector2.zero) Move();

        //print(rb.velocity.magnitude);
    }

    private  void Move()
    {
        //print(moveInput);
       

        Vector3 acutalForward = Vector3.Cross(mainCamera.right, transform.up);
        Vector3 actualRight = Vector3.Cross(transform.up, acutalForward);

        Vector3 direction = (acutalForward * movement.z + actualRight * movement.x).normalized;

        //transform.position += speed * Time.deltaTime * direction;

         if(rb.velocity.magnitude <= maxSpeed) rb.AddForce(direction * speed, ForceMode.Force);
    }

    private void OnWalkInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        movement = new Vector3(moveInput.x, 0, moveInput.y).normalized;
    }

    private void StartRagdoll()
    {
        ragDollController.startRagdoll();

        if (rb.velocity.magnitude > maxWalkSpeed) rb.AddForce(rb.velocity, ForceMode.Impulse);
    }
    
    void OnEnable()
    {
        input.Player.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }
}
