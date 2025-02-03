using System.Collections;
using UnityEngine;

public class CombatArmorStand : MonoBehaviour, IDamageable
{
    [field: SerializeField] public float Health { get; set; }
    public float MaxHealth { get; set; }
    public bool canTakeDamage { get; set; } = true;



    private void Start()
    {
        MaxHealth = Health;
    }

    public IEnumerator DamageCoolDown(float damageDelay)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageDelay);
        canTakeDamage = true;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damageAmount, float damageDelay)
    {
        if(!canTakeDamage) return; 

        Health -= damageAmount;
        GetComponentInChildren<Healthbar>().UpdateHealthBar(Health / MaxHealth);
        Debug.Log($"Health left: {Health}");
        if(Health <= 0)
        {
            Death();
            return;
        }
        StartCoroutine(DamageCoolDown(damageDelay));
    }
}
public interface IDamageable
{
    public float Health { get; set; }
    public float MaxHealth { get; set; }
   // public HealthBar HealthBar { get; set; }
    public bool canTakeDamage { get; set; }
    public IEnumerator DamageCoolDown(float damageDelay); //a coroutine which resets canTakeDamage to true after a given amount of time in seconds
    public void TakeDamage(float damageAmount, float damageDelay);
    public void Death();
}
