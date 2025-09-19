using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private float speed = 10f; // Velocidade do projétil
    [SerializeField] private int damage = 10;  // Dano causado pelo projétil
    [SerializeField] private float lifetime = 3f; // Tempo de vida do projétil

    private Rigidbody2D rb;

    private void Start()
    {
        // Obtém o Rigidbody2D e aplica movimento ao projétil
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        // Destroi o projétil após o tempo de vida
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o projétil colidiu com um inimigo
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); // Aplica dano ao inimigo
            }

            Destroy(gameObject); // Destroi o projétil após a colisão
        }
        else if (!collision.CompareTag("Player")) // Evita destruir ao colidir com o jogador
        {
            Destroy(gameObject); // Destroi o projétil ao colidir com qualquer outra coisa
        }
    }
}