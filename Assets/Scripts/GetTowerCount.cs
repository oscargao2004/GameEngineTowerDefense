using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetTowerCount : Singleton
{
    public static List<GameObject> towers = new List<GameObject>();

    public int towerCount = 0;

    private void Update()
    {
        towerCount = towers.Count;
    }
}
