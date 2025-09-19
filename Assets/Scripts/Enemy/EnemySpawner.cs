using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject enemyPrefab; // Prefab do inimigo a ser instanciado
    [SerializeField] private Transform[] spawnPoints; // Pontos de spawn dos inimigos
    [SerializeField] private float spawnInterval = 5f; // Intervalo entre os spawns

    private float spawnTimer;

    private void Update()
    {
        // Atualiza o temporizador
        spawnTimer += Time.deltaTime;

        // Verifica se é hora de spawnar um novo inimigo
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f; // Reseta o temporizador
        }
    }

    private void SpawnEnemy()
    {
        // Escolhe um ponto de spawn aleatório
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Instancia o inimigo no ponto de spawn
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private void OnDrawGizmos()
    {
        // Desenha os pontos de spawn no editor para facilitar o ajuste
        Gizmos.color = Color.green;
        foreach (Transform spawnPoint in spawnPoints)
        {
            Gizmos.DrawSphere(spawnPoint.position, 0.3f);
        }
    }
}