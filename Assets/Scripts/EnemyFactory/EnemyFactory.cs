using UnityEngine;

public abstract class EnemyFactory
{
    public abstract GameObject CreateEnemy();

    public abstract void LoadData();

    protected EnemyData SetEnemyData(string filename)
    {
        EnemyData enemyData = Resources.Load<EnemyData>($"ScriptableObjects/Enemies/" + filename);
        
        return enemyData;
    }
}
