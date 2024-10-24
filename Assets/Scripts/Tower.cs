using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Mesh BaseModel;
    [SerializeField] Mesh Upgrade1Model;
    [SerializeField] Mesh Upgrade2Model;
    MeshFilter _meshFilter;
    public int cost {get; private set;}
    public int upgradeCost {get; private set;}

    [SerializeField][Range(0,2)] int _upgradeLevel;

    void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void Sell(){
        Destroy(gameObject);
        Debug.Log("Tower sold");
    }
    public void Recall(){
        Player.towerInventory.Add(this);
        Debug.Log("Tower recalled to inventory");

    }
    public void Upgrade(){
        _upgradeLevel++;
        switch (_upgradeLevel)
        {
            case 0:
                _meshFilter.mesh = BaseModel;
                break;
            case 1:
                _meshFilter.mesh = Upgrade1Model;
                break;
            case 2:
                _meshFilter.mesh = Upgrade2Model;
                break;
            default:
                Debug.LogError("_upgrade level out of bounds");
            break;

        }
        Debug.Log("Tower upgraded");

    }
}
