using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private GameObject projectilePrefab; // Prefab do projétil
    [SerializeField] private Transform firePoint; // Ponto de origem do tiro
    [SerializeField] private float fireRate = 0.5f; // Tempo entre os tiros

    private float fireCooldown;

    private void Update()
    {
        // Atualiza o cooldown do tiro
        fireCooldown -= Time.deltaTime;

        // Verifica se o botão esquerdo do mouse foi pressionado e se o cooldown terminou
        if (Input.GetMouseButton(0) && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate; // Reseta o cooldown
        }
    }

    private void Shoot()
    {
        // Calcula a direção do tiro com base na posição do mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - firePoint.position).normalized;

        // Instancia o projétil no ponto de origem
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Define a direção do projétil
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * rb.GetComponent<Projectile>().speed;
        }
    }
}