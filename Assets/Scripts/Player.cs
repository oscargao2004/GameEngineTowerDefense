using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : Singleton<Player>
{
    public struct Currency
    {
        public int maxCurrency;
        public int value {get;private set;}
        public void Substract(int amount){
            value -= amount;
        }
        public void Add(int amount){
            value += amount;
        }
    }
    public static List<Tower> towerInventory;


    public Currency currency;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
