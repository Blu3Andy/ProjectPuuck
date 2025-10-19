using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputMaster input;

    [SerializeField] private float speed;

    private Vector2 moveInput;
    private Vector3 movement;

    private Transform mainCamera;
    
    void Awake()
    {
        input = new InputMaster();

        mainCamera = Camera.main.transform;

        input.Player.Movement.started += OnWalkInput;
        input.Player.Movement.performed += OnWalkInput;
        input.Player.Movement.canceled += OnWalkInput;
    }

    void Update()
    {
        if (moveInput != Vector2.zero) Move();
    }

    private  void Move()
    {
        print(moveInput);
       

        Vector3 acutalForward = Vector3.Cross(mainCamera.right, transform.up);
        Vector3 actualRight = Vector3.Cross(transform.up, acutalForward);

        Vector3 direction = (acutalForward * movement.z + actualRight * movement.x).normalized;

        transform.position += speed * Time.deltaTime * direction;
    }

    private void OnWalkInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        movement = new Vector3(moveInput.x, 0, moveInput.y).normalized;
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
