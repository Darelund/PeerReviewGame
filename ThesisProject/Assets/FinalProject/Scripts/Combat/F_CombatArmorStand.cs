using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public interface F_IDamageable
{
    public int Health { get; set; }//keeps track of the IDamageables current health
    public int MaxHealth { get; set; }
    public F_HealthBar HealthBar { get; set; }
    public bool canTakeDamage { get; set; }//for the IDamageable to only take damage once when the sword collides with it we need to set a “cooldown” on how often the target can take damage
    public IEnumerator DamageCoolDown(int damageDelay); //a coroutine which resets canTakeDamage to true after a given amount of time in seconds
    public void TakeDamage(int damageAmount,int damageDelay);
    public void Death();
}
public class F_CombatArmorStand : MonoBehaviour, F_IDamageable
{
    [field: SerializeField] public int Health { get; set; }
    
    public bool canTakeDamage { get; set; } = true;
    public F_HealthBar HealthBar { get ; set ; }
    public int MaxHealth { get; set ; }

    private void Start()
    {
        HealthBar = GetComponentInChildren<F_HealthBar>();
        MaxHealth = Health;
    }

    public IEnumerator DamageCoolDown(int damageDelay)//this resets canTakeDamage allowing the armor stand to once again take damage
    {
        yield return new WaitForSeconds(damageDelay);
        canTakeDamage = true;
    }
    public void TakeDamage(int damageAmount, int damageDelay)//Logic behind taking damage
    {
        if (canTakeDamage && Health>0)//if the armor stand can take damage and still has health remaining
        {
            canTakeDamage = false;
            Health -= damageAmount;
            HealthBar.UpdateHealthBar((float)Health/MaxHealth);//updates the health bar depending on how much health is left
            StartCoroutine(DamageCoolDown(damageDelay));
        }
        if (Health <= 0)
        { Death();}
    }

    public void Death()
    {
       Destroy(gameObject);
    }
}
