using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour
{
    public GameObject normalEnemyPrefab;
    public GameObject minionEnemyPrefab;

    public float spawnInterval = 2f;

    void Start()
    {
        if (normalEnemyPrefab != null && minionEnemyPrefab != null)
        {
            Debug.Log("All enemy prefabs are assigned!");
            StartCoroutine(SpawnEnemies());
        }
        else
        {
            Debug.LogError("One or more enemy prefabs are not assigned!");
        }
    }

IEnumerator SpawnEnemies()
{
    while (true)
    {
        int randomEnemy = Random.Range(0, 2); // 0, 1, or 2
        GameObject selectedEnemyPrefab = null;

        switch (randomEnemy)
        {
            case 0:
                selectedEnemyPrefab = normalEnemyPrefab;
                break;
            case 1:
                selectedEnemyPrefab = minionEnemyPrefab;
                break;
        }

        // Random spawn position
        float randomX = Random.Range(-10f, 10f);
        Vector3 spawnPosition = new Vector3(randomX, 5f, 0f); // Spawn above screen
        GameObject newEnemy = Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);

        // Check if enemy was spawned correctly
        Debug.Log("Spawned enemy: " + newEnemy.name);

if (newEnemy != null)
{
    Enemy enemyScript = newEnemy.GetComponent<Enemy>();
    IFallBehavior fallBehavior = null;

    if (enemyScript is NormalEnemy)
    {
        fallBehavior = new NormalFall();
    }
    else if (enemyScript is MinionEnemy)
    {
        fallBehavior = new SlowFall();
    }

    if (fallBehavior != null)
    {
        enemyScript.SetFallBehavior(fallBehavior);
        Debug.Log("Set fall behavior for: " + newEnemy.name);
    }
}


        yield return new WaitForSeconds(spawnInterval); // Wait before spawning next enemy
    }
}
}