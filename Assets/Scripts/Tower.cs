using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Tower : MonoBehaviour
{
    [Header("Tower Stats")] 
    [SerializeField] private float detectRange;
    [SerializeField] private float attackSpeed;
    public int cost {get; private set;}
    public int upgradeCost {get; private set;}
    
    [Header("Projectile Settings")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed;
    
    [Header("Upgraded Meshes")]
    [SerializeField] Mesh BaseModel;
    [SerializeField] Mesh Upgrade1Model;
    [SerializeField] Mesh Upgrade2Model;
    MeshFilter _meshFilter;
    
    private SphereCollider _sphereCollider;
    private GameObject _currentTarget;
    private int _upgradeLevel;

    private Queue<GameObject> _targetQueue = new Queue<GameObject>();

    private bool _dirty = false;

    void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius = detectRange*2;
    }

    void Update()
    {
        if (_dirty) _currentTarget = _targetQueue.Peek();
        _dirty = false;

        if (_currentTarget)
        {
            StartCoroutine(Shoot());
        }
        else
        {
            StopCoroutine(Shoot());
        }

    }
    
    public void Sell(){
        Destroy(gameObject);
        Debug.Log("Tower sold");
    }
    public void Recall(){
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

    IEnumerator Shoot()
    {
        Debug.Log("Bang");
        //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(attackSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        _targetQueue.Enqueue(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        _dirty = true;
        _targetQueue.Dequeue();
    }

    private void OnDrawGizmosSelected()
    {
        //remove center offset later
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, 0.5f, transform.position.z), detectRange);
    }
}
