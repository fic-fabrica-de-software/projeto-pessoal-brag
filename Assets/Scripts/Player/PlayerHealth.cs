using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health Settings")]
    [SerializeField] private int maxHealth = 100; // Vida máxima do jogador
    private int currentHealth;

    [Header("Damage Effects")]
    [SerializeField] private GameObject deathEffect; // Efeito visual ao morrer

    private void Start()
    {
        // Inicializa a vida do jogador com o valor máximo
        currentHealth = maxHealth;
    }

    // Método para aplicar dano ao jogador
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Verifica se a vida chegou a zero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método chamado quando o jogador morre
    private void Die()
    {
        // Instancia o efeito de morte, se configurado
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        // Notifica o GameManager que o jogo acabou
        GameManager.Instance.GameOver();

        // Destroi o objeto do jogador
        Destroy(gameObject);
    }

    // Método para curar o jogador
    public void Heal(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    // Método para obter a vida atual
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}