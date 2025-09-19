using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private HealthUI healthUI; // Referência ao script de UI de vida

    [Header("Player Reference")]
    [SerializeField] private PlayerHealth playerHealth; // Referência ao script de vida do jogador

    private void Start()
    {
        // Inicializa as referências da HUD
        if (healthUI != null && playerHealth != null)
        {
            healthUI.Initialize(playerHealth);
        }
    }
}