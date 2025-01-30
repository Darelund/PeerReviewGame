using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_weapon", menuName = "Weapon")] //creates a new file from this script
public class F_SO_Weapon : ScriptableObject
{
    public string Name;// the weapons name
    public Mesh Mesh;//the weapons model
    public int AttackSpeed;//how fast the player can attack with this weapon
    public int AttackPower;//how much damage the weapon deals
}
