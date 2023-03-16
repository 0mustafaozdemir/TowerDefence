using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public LayerMask mask;
    public GameObject rocketSight;
    [Range(1, 50f)]
    public int range;
    public Collider[] enemies;
    public int levelCount = 0;
    public List<GameObject> towerList = new List<GameObject>();
    public static Tower Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    private void Update()
    {
        enemies = Physics.OverlapSphere(transform.position, range, mask);
        LookAt();       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void LookAt()
    {
        if (enemies.Length > 0)
        {
            rocketSight.transform.LookAt(enemies[levelCount-1].transform.position);
        }
    }

    

}
