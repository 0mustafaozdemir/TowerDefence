using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [Header("Properties")]
    public int maxHP;
    public int hp;
    public int damage;
    public float speed;
    public int currentWayPoint = 0;

    public List<Transform> wayPoints = new List<Transform>();
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



}
