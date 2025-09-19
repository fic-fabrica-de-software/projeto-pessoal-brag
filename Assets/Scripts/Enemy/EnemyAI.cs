using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Enemy AI Settings")]
    [SerializeField] private float detectionRadius = 5f; // Raio de detecção do jogador
    [SerializeField] private float moveSpeed = 2f; // Velocidade de movimento do inimigo

    private Transform player; // Referência ao jogador
    private Rigidbody2D rb;

    private void Start()
    {
        // Encontra o jogador pela tag "Player"
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        // Obtém o Rigidbody2D do inimigo
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player == null) return;

        // Calcula a distância até o jogador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Se o jogador estiver dentro do raio de detecção, o inimigo se move em direção a ele
        if (distanceToPlayer <= detectionRadius)
        {
            MoveTowardsPlayer();
        }
        else
        {
            // Para o movimento quando o jogador está fora do raio de detecção
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calcula a direção do inimigo em relação ao jogador
        Vector2 direction = (player.position - transform.position).normalized;

        // Move o inimigo na direção do jogador
        rb.velocity = direction * moveSpeed;
    }

    private void OnDrawGizmosSelected()
    {
        // Desenha o raio de detecção no editor para facilitar o ajuste
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}