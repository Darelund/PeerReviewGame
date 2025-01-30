using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_PlayerWeapon : MonoBehaviour
{
    
    private int attackPower; //how much damage your weapon does
    public int attackSpeed { get; private set; } // how often can you swing your weapon
    public MeshCollider Collider { get; private set; } //reference to the collider component
    public F_SO_Weapon startingWeapon; //reference to the starting weapon SO
    public void Start()
    {
        Collider = GetComponent<MeshCollider>();
        LoadWeapon(startingWeapon);//Loads in all data for the weapon the player starts with
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<F_IDamageable>() != null)
        {
            other.GetComponent<F_IDamageable>().TakeDamage(attackPower,attackSpeed); //if the other collider is a IDamageable call for it's TakeDamage Method
        }
    }

    public void LoadWeapon(F_SO_Weapon WeaponSO)//update your weapon with the data of the weapon SO
    {
        GetComponent<MeshFilter>().mesh = WeaponSO.Mesh;
        Collider.sharedMesh  = WeaponSO.Mesh;
        attackSpeed = WeaponSO.AttackSpeed;
        attackPower = WeaponSO.AttackPower;
    }
}
