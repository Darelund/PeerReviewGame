using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class F_PlayerMeleeSwing : MonoBehaviour
{
    private Animator animator; //Animator to turn on animations
    private F_PlayerMovement playerMovement;
    public  F_PlayerWeapon currentWeapon;
    private bool canAttack = true;
    void Start()
    {
        playerMovement = GetComponent<F_PlayerMovement>(); // Getting the Rigidbody component attached to the character
        animator = GetComponent<Animator>(); // Getting the Animator component attached to the character
        currentWeapon = GetComponentInChildren<F_PlayerWeapon>();//Finds the F_PlayerWeapon component in any children of the base object
        currentWeapon.Collider.enabled = false;//disables the weapons collider 
    }
    private void OnAttack(InputValue input)
    {
        if (animator != null && playerMovement.movementVector == Vector3.zero && canAttack)
        {
            animator.SetTrigger("IsSwinging");
            StartCoroutine(DelayColliderActivation()); // We do this step to ensure that the target doesnt take damage if the sword is already colliding when swings is activated.
            canAttack = false;
            StartCoroutine(AttackCooldown());

        }
    }
    private IEnumerator AttackCooldown()//reset the players ability to attack depending on the weapons attack speed
    {
        yield return new WaitForSeconds(currentWeapon.attackSpeed);
        currentWeapon.Collider.enabled = false;
        canAttack = true;
    }
    private IEnumerator DelayColliderActivation()//Delays activating the weapons collider to prevent it from colliding with anything on the way up of the swing.
    {
        yield return new WaitForSeconds(0.5f);
        currentWeapon.Collider.enabled = true;
    }
}
