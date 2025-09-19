using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapons/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Weapon Settings")]
    public GameObject projectilePrefab; // Prefab do projétil
    public float fireRate = 0.5f; // Tempo entre os tiros
    public float projectileSpeed = 10f; // Velocidade do projétil
    public int damage = 10; // Dano causado pelo projétil
}