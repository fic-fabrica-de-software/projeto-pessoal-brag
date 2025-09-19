using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    public bool isGameOver = false; // Indica se o jogo terminou

    private void Awake()
    {
        // Garante que apenas uma instância do GameManager exista
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        // Define o estado de game over
        isGameOver = true;

        // Exibe uma mensagem de game over (pode ser expandido para UI)
        Debug.Log("Game Over!");

        // Aqui você pode adicionar lógica para reiniciar o jogo ou voltar ao menu principal
    }

    public void RestartGame()
    {
        // Reinicia o jogo (recarrega a cena atual)
        isGameOver = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}