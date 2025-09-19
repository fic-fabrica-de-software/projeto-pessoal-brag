using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] private WeaponData weaponData; // Dados da arma (ScriptableObject)
    [SerializeField] private Transform firePoint; // Ponto de origem do tiro

    private float fireCooldown;

    private void Update()
    {
        // Atualiza o cooldown do tiro
        fireCooldown -= Time.deltaTime;

        // Verifica se o botão esquerdo do mouse foi pressionado e se o cooldown terminou
        if (Input.GetMouseButton(0) && fireCooldown <= 0f)
        {
            Fire();
            fireCooldown = weaponData.fireRate; // Reseta o cooldown com base na taxa de tiro
        }
    }

    private void Fire()
    {
        // Instancia o projétil no ponto de origem
        GameObject projectile = Instantiate(weaponData.projectilePrefab, firePoint.position, firePoint.rotation);

        // Define a velocidade do projétil
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * weaponData.projectileSpeed;
        }
    }
}