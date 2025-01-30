using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class F_PlayerMovementAnimation : MonoBehaviour
{
    private Animator animator; //Animator to turn on animations
    [SerializeField] private float movementSpeed; // Movement speed of the character


    void Start()
    {
      
        animator = GetComponent<Animator>(); // Getting the Animator component attached to the character
    }

    // This method is invoked when there is movement input
    private void OnMovement(InputValue input)
    {
        animator.SetBool("IsMoving", true);
    }
    private void OnMovementStop(InputValue input)
    {
       animator.SetBool("IsMoving", false);
    }
}
