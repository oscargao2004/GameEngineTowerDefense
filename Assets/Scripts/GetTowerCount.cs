using System;
using System.Collections.Generic;
using UnityEngine;

public class GetTowerCount : Singleton
{
    
    public static List<GameObject> towers = new List<GameObject>();

    public int towerCount;

    private void Update()
    {
        towerCount = towers.Count;
    }
}
