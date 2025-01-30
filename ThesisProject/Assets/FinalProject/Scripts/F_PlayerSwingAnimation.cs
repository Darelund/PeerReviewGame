using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class F_PlayerSwingAnimation : MonoBehaviour
{
    private Animator animator; //Animator to turn on animations
    private F_PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<F_PlayerMovement>(); // Getting the Rigidbody component attached to the character
        animator = GetComponent<Animator>(); // Getting the Animator component attached to the character
    }
    private void OnAttack(InputValue input)
    {
        if (animator!=null&& playerMovement.movementVector == Vector3.zero && !animator.GetCurrentAnimatorStateInfo(0).IsName("Swing"))
       {
           animator.SetTrigger("IsSwinging");
       }
    }
}
