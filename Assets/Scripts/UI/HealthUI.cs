using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Slider healthSlider; // Barra de vida
    [SerializeField] private Text healthText; // Texto para exibir a vida atual

    [Header("Player Reference")]
    [SerializeField] private PlayerHealth playerHealth; // Referência ao script de vida do jogador

    private void Start()
    {
        // Inicializa a barra de vida com os valores do jogador
        if (playerHealth != null)
        {
            healthSlider.maxValue = playerHealth.GetMaxHealth();
            healthSlider.value = playerHealth.GetCurrentHealth();
            UpdateHealthText();
        }
    }

    private void Update()
    {
        // Atualiza a barra de vida e o texto com os valores atuais
        if (playerHealth != null)
        {
            healthSlider.value = playerHealth.GetCurrentHealth();
            UpdateHealthText();
        }
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = $"{playerHealth.GetCurrentHealth()} / {playerHealth.GetMaxHealth()}";
        }
    }
}