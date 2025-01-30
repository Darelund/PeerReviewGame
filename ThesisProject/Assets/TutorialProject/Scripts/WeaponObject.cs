using UnityEngine;

public class WeaponObject : MonoBehaviour, IInteractable
{
    [SerializeField] private WeaponSO weapon;
    public void Interact()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Weapon>().LoadWeapon(weapon);
        Destroy(gameObject);
    }
}
