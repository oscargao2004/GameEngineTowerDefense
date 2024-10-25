using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements.Experimental;

public class Player : Singleton
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
    //public static List<Tower> towerInventory;

    public Currency currency;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
