using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerSwingAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] public bool canAttack = true;

    public void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
        currentWeapon = GetComponentInChildren<Weapon>();
       // currentWeapon.meshCollider.enabled = false;
    }
    private void Update()
    {
    }

    public void OnAttack(CallbackContext context)
    {
        if(context.started)
        {
           if ( /* playerMovement.movementVector == Vector3.zero && */ canAttack)
            {
                animator.SetTrigger("IsSwinging");
               // StartCoroutine(DelayColliderActivation()); // We do this step to ensure that the target doesnt take damage if the sword is already colliding when swings is activated.
                canAttack = false;
                GetComponentInChildren<CooldownBar>(true).gameObject.SetActive(true);
                GetComponentInChildren<CooldownBar>().StartCooldown(currentWeapon.AttackSpeed);
                StartCoroutine(AttackCooldown());
            }
        }
    }
    //private IEnumerator DelayColliderActivation()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    currentWeapon.meshCollider.enabled = true;
    //}
    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(currentWeapon.AttackSpeed);
        GetComponentInChildren<CooldownBar>().StopCooldown();
        //   currentWeapon.meshCollider.enabled = false;
        GetComponentInChildren<CooldownBar>().gameObject.SetActive(false);

        canAttack = true;
    }
}
