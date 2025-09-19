using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Health Settings")]
    [SerializeField] private int maxHealth = 100; // Vida máxima do inimigo
    private int currentHealth;

    [Header("Death Effects")]
    [SerializeField] private GameObject deathEffect; // Efeito visual ao morrer

    private void Start()
    {
        // Inicializa a vida do inimigo com o valor máximo
        currentHealth = maxHealth;
    }

    // Método para aplicar dano ao inimigo
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Verifica se a vida chegou a zero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método chamado quando o inimigo morre
    private void Die()
    {
        // Instancia o efeito de morte, se configurado
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        // Destroi o objeto do inimigo
        Destroy(gameObject);
    }
}