using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    [SerializeField] private float moveSpeed = 5f; // Velocidade de movimento do jogador

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        // Obtém o Rigidbody2D do jogador
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Captura a entrada do teclado (WASD ou setas)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normaliza o vetor de movimento para evitar movimento mais rápido na diagonal
        movement = movement.normalized;
    }

    private void FixedUpdate()
    {
        // Move o jogador usando o Rigidbody2D
        rb.velocity = movement * moveSpeed;
    }
}