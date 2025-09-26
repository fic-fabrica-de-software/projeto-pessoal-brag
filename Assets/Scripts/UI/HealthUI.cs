using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Slider healthSlider; 
    [SerializeField] private Text healthText; 

    [Header("Player Reference")]
    [SerializeField] private PlayerHealth playerHealth; 

    private void Start()
    {
        if (playerHealth != null) {
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