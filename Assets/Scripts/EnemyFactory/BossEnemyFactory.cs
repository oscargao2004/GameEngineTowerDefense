using UnityEngine;

public class BossEnemyFactory : EnemyFactory
{
    private EnemyData _enemyData;
    public override GameObject CreateEnemy()
    {
        return _enemyData.prefab;
    }

    public override void LoadData()
    {
        _enemyData = SetEnemyData("BossEnemy");
    }
}
