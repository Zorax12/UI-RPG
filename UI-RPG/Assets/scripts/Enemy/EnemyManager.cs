using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Enemy[] enemyPrefabs;
    [SerializeField] private Transform enemyParent;

    [SerializeField] private TMP_Text enemyNameText;
    [SerializeField] private TMP_Text enemyHpText;

    private Enemy currentEnemy;

    public Enemy CurrentEnemy
    {
        get { return currentEnemy; }
    }

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if (currentEnemy != null)
        {
            Destroy(currentEnemy.gameObject);
        }

        if (enemyPrefabs == null || enemyPrefabs.Length == 0)
        {
            Debug.LogError("No enemy prefabs assigned to EnemyManager.");
            return;
        }

        Enemy prefabToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        currentEnemy = Instantiate(prefabToSpawn, enemyParent);
        UpdateEnemyUI();
    }

    public void UpdateEnemyUI()
    {
        if (currentEnemy == null)
        {
            enemyNameText.text = "";
            enemyHpText.text = "";
            return;
        }

        enemyNameText.text = currentEnemy.CharName;
        enemyHpText.text = "HP: " + currentEnemy.health.ToString("F0");
    }

    public void DamageCurrentEnemy(Character attacker)
    {
        if (currentEnemy == null)
            return;

        attacker.Attack(currentEnemy);
        UpdateEnemyUI();
    }

    public bool IsCurrentEnemyDead()
    {
        return currentEnemy != null && currentEnemy.health <= 0;
    }
}
