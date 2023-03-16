using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public Transform startPoint;
    public int enemyCount;
    

    public void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            EnemySpawn();
        }
    }

    public void EnemySpawn()
    {
        Instantiate(enemy, startPoint.position, Quaternion.identity);
    }
    public void LevelUp()
    {
        Tower.Instance.levelCount++;
        LevelController();
    }
    public void LevelController()
    {
        Tower.Instance.towerList[Tower.Instance.levelCount].SetActive(true);
        Tower.Instance.towerList[Tower.Instance.levelCount-1].SetActive(false);
        Tower.Instance.towerList[Tower.Instance.levelCount + 1].SetActive(false);
    }

    
}
