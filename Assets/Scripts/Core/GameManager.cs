using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    public bool isGameOver = false; 


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
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