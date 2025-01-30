using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_WeaponObject : MonoBehaviour, F_IInteractable
{
    public F_SO_Weapon WeaponSO; // a reference to the  weapon scriptable object for this specific weapon game object
    public void Interact()//Method that is called when player interact with the weapon game object
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<F_PlayerWeapon>().LoadWeapon(WeaponSO);
        Destroy(gameObject);
    }

   
}
