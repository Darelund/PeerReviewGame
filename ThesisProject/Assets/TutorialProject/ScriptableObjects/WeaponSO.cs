using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "ScriptableObject/Weapon")]
public class WeaponSO : ScriptableObject
{
    public string Name;
    public int AttackSpeed;
    public float AttackPower;
    public Mesh Mesh;
}
