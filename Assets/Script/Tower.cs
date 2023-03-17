using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    private Transform target;
    public LayerMask mask;
    public GameObject rocketSight;
    public List<GameObject> rocketSightList = new List<GameObject>();
    [Range(1, 50f)]
    public int range;
    public Collider[] enemies;
    public int levelCount = 0;
    public List<GameObject> towerList = new List<GameObject>();
    public static Tower Instance;
    public GameObject canvas;
    public int levelÝnt;
    public GameObject spawnTransform;
    public GameObject bulletPrefab;
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
        rocketSight = rocketSightList[levelÝnt].gameObject;
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
            rocketSight.transform.LookAt(enemies[levelCount].transform.position);
            enemies[levelCount].gameObject.GetComponent<Enemy>().hp -= 1;
            enemies[levelCount].gameObject.GetComponent<Enemy>().healBar.fillAmount -= 0.01f;
            target = enemies[0].transform;
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, spawnTransform.transform.position, spawnTransform.transform.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();


        bullet.Seek(target);


    }

}
