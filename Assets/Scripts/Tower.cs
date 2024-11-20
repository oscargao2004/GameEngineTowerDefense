using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Vector3 = UnityEngine.Vector3;

public class Tower : MonoBehaviour
{
    [Header("Tower Stats")] 
    [SerializeField] private float detectRange;
    [SerializeField] private float attackSpeedInSeconds;
    public int cost {get; private set;}
    public int upgradeCost {get; private set;}
    
    [Header("Projectile Settings")]
    [SerializeField] GameObject projectilePrefab;

    [SerializeField] private float projectileDamage;
    
    [Header("Upgraded Meshes")]
    [SerializeField] Mesh BaseModel;
    [SerializeField] Mesh Upgrade1Model;
    [SerializeField] Mesh Upgrade2Model;
    MeshFilter _meshFilter;
    
    private SphereCollider _sphereCollider;
    private GameObject _currentTarget;
    private int _upgradeLevel;

    private Queue<GameObject> _targetQueue = new Queue<GameObject>();
    
    private ProjectileObjectPool _projectilePool;

    private bool _dirty = false;

    private float nextFireTime;

    void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius = detectRange*2;
        _projectilePool = GameObject.Find("ProjectilePool").GetComponent<ProjectileObjectPool>();
    }

    void Update()
    {
        if (_dirty && _targetQueue.Count > 0) _currentTarget = _targetQueue.Peek();
        _dirty = false;

        if (_currentTarget && Time.time > nextFireTime)
        {
            Shoot();
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

    void Shoot()
    {
        Debug.Log("Bang");
        //GameObject projectile = Instantiate(projectilePrefab, transform.position, 
            //Quaternion.LookRotation((_currentTarget.transform.position - transform.position).normalized, Vector3.up ));

        GameObject projectile = _projectilePool.GetObject();
        projectile.transform.position = transform.position;
        projectile.transform.rotation =
            Quaternion.LookRotation((_currentTarget.transform.position - transform.position).normalized, Vector3.up);
        projectile.GetComponent<Projectile>().SetDamage(projectileDamage);
        nextFireTime = Time.time + attackSpeedInSeconds;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _dirty = true;
            _targetQueue.Enqueue(other.gameObject);
            Debug.Log("Enemy added to targetQueue");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _dirty = true;
            _targetQueue.Dequeue();
            Debug.Log("Enemy removed from targetQueue");
        }
    }

    private void OnDrawGizmosSelected()
    {
        //remove center offset later
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, 0.5f, transform.position.z), detectRange);
    }
}
