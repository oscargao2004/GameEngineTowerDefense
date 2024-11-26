using UnityEngine;

public abstract class Factory
{
    public abstract void LoadData();

    protected ScriptableObject SetData(string path)
    {
        var data = Resources.Load<ScriptableObject>($"ScriptableObjects/" + path);
        
        return data;
    }
}
