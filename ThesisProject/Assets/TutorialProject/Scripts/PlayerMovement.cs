using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movemnt Stuff")]
    [SerializeField] private Rigidbody rb;
    private Vector3 inputVec;
    private Vector3 movementVec;
    [SerializeField] private bool isGrounded = true;


    [Header("Animation")]
    [SerializeField] private Animator animator;


    [SerializeField] private float walkSpeed = 6;
    [SerializeField] private float sprintSpeed = 12f;
    [SerializeField] private float crouchingSpeed = 1f;
    [SerializeField] private float airSpeed = 3f;
    [SerializeField] private bool isSprinting = false;
    [SerializeField] private bool isCrouching = false;
    private float Speed
    {
        get
        {
            if(!isGrounded)
                return airSpeed;
            else if (isSprinting)
                 return sprintSpeed;
            else if(isCrouching)
                return crouchingSpeed;
            return walkSpeed;
        }
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }




    private void Update()
    {
        //Translate will do orientation for you, so I choose that instead
        transform.Translate(inputVec * Time.deltaTime * Speed);
    }


    //I didn't wanna do as the tutorial did, why even use rigidbody then?
    private void FixedUpdate()
    {
        //movementVec = inputVec.x * transform.right + inputVec.z * transform.forward;
        //var newMove = (movementVec * Time.fixedDeltaTime * walkSpeed);
        //rb.linearVelocity = new Vector3(newMove.x, rb.linearVelocity.y, newMove.z);
    }


    public void OnMovement(CallbackContext value)
    {
        if(value.performed)
        {
            var input = value.ReadValue<Vector2>();
            inputVec = new Vector3(input.x, 0, input.y);
            animator.SetBool("IsMoving", true);
        }
        else if (value.canceled)
        {
            inputVec = Vector3.zero;
            animator.SetBool("IsMoving", false);
        }
    }


    public void Jump(CallbackContext value)
    {
        if (value.started && isGrounded)
        {
            float jumpSpeed = 4;
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    public void OnCrouch(CallbackContext value)
    {
        if(value.started)
        {
            isCrouching = true;

        }
        else if(value.canceled)
        {
            isCrouching = false;
        }
    }
    public void OnSprint(CallbackContext value)
    {
        if (value.started)
        {
            isSprinting = true;

        }
        else if (value.canceled)
        {
            isSprinting = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
