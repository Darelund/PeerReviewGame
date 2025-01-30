using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon properties")]
    [SerializeField] private float AttackPower;
    [SerializeField] public float AttackSpeed;
    [SerializeField] private WeaponSO weaponSO;
    //[HideInInspector]public MeshCollider meshCollider;

    private void Awake()
    {
       // meshCollider = GetComponent<MeshCollider>();
        LoadWeapon(weaponSO);
    }
    public void LoadWeapon(WeaponSO weaponSO)
    {
        //Mesh stuff
        GetComponent<MeshFilter>().mesh = weaponSO.Mesh; //Changing visual mesh
        GetComponent<MeshCollider>().sharedMesh = weaponSO.Mesh; //Changing collider mesh
        gameObject.name = weaponSO.Name;

        AttackPower = weaponSO.AttackPower;
        AttackSpeed = weaponSO.AttackSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamageable damage))
        {
            damage.TakeDamage(AttackPower, AttackSpeed);
        }
    }
}
