using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);

        rb.velocity = movement.normalized * speed;

        animator.SetFloat("Speed", movement.magnitude);
        
        // Define direção (opcional: use um parâmetro "Direction")
        if (moveX != 0 || moveY != 0)
        {
            // Ex: salva última direção para escolher animação certa
            if (Mathf.Abs(moveX) > Mathf.Abs(moveY))
            {
                animator.SetFloat("MoveX", moveX);
                animator.SetFloat("MoveY", 0);
            }
            else
            {
                animator.SetFloat("MoveY", moveY);
                animator.SetFloat("MoveX", 0);
            }
        }
    }
}