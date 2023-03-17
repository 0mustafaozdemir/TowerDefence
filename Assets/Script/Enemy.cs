using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{

    [Header("Properties")]
    public int maxHP;
    public int hp;
    public int damage;
    public float speed;
    public int currentWayPoint = 0;
    public Image healBar;
    public static Enemy Instance;
    public GameObject explosionPrefab;
    public GameObject explosionWall;


    public List<Transform> wayPoints = new List<Transform>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        for (int i = 0; i < Level.Instance.wayPointList.Count; i++)
        {
            wayPoints.Add(Level.Instance.wayPointList[i]);
        }
        transform.LookAt(wayPoints[0].position);
    }
    private void Update()
    {
        MoveToWayPoint();

        if (hp <= 0)
        {
            
            explosionPrefab.transform.position = gameObject.transform.position;
            Instantiate(explosionPrefab, gameObject.transform.position,Quaternion.identity);
            Instantiate(explosionWall, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);

            GameManager.Instance.money += 25;
            StartCoroutine(waitForExplasion());
        }

    }

    //TO DO:
    public void MoveToWayPoint()
    {

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWayPoint].transform.position, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, wayPoints[currentWayPoint].transform.position) <= 0.01f)
        {
            currentWayPoint++;
            transform.LookAt(wayPoints[currentWayPoint].position);

        }
    }

    IEnumerator waitForExplasion()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(explosionPrefab);
        yield return new WaitForSeconds(1f);
        Destroy(explosionWall);
    }




}
