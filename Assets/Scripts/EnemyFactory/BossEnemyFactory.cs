using UnityEngine;

public class BossEnemyFactory : EnemyFactory
{
    private static EnemyData _enemyData;
    public override GameObject CreateEnemy()
    {
        GameObject newEnemy = _enemyData.prefab;
        Enemy e = newEnemy.GetComponent<Enemy>();
        e.speed = _enemyData.speed;
        e.maxHealth = _enemyData.maxHealth;
        return newEnemy;
    }

    public override void LoadData()
    {
        _enemyData = SetEnemyData("BossEnemy");
    }
}
