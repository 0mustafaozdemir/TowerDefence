using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public Transform startPoint;
    public int enemyCount;
    public bool enemySpawnBool;
    public GameObject cameraPos;


    public void Start()
    {
        cameraPos.transform.DOMove(new Vector3(-12.41f, 26f, -32f), 4f);
    }

    private void Update()
    {
        if (enemySpawnBool == true)
        {
            StartCoroutine(EnemySpawns());
            enemySpawnBool = false;
        }

        LevelController();
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
    public static void LevelController()
    {


        if (RaycastController.lastObj != null && RaycastController.lastObj.GetComponent<Tower>().level›nt < 3)
        {
            for (int i = 0; i < RaycastController.lastObj.GetComponent<Tower>().level›nt; i++)
            {
                RaycastController.lastObj.GetComponent<Tower>().towerList[i].SetActive(false);
            }

            if (RaycastController.lastObj.GetComponent<Tower>().level›nt == 0)
            {
                RaycastController.lastObj.GetComponent<Tower>().towerList[0].SetActive(true);
            }
            if (RaycastController.lastObj.GetComponent<Tower>().level›nt == 1)
            {
                RaycastController.lastObj.GetComponent<Tower>().towerList[1].SetActive(true);
                RaycastController.lastObj.GetComponent<Tower>().range = 17;
            }

            if (RaycastController.lastObj.GetComponent<Tower>().level›nt == 2)
            {
                RaycastController.lastObj.GetComponent<Tower>().towerList[2].SetActive(true);
                RaycastController.lastObj.GetComponent<Tower>().range = 25;
            }
               

        }

    }
    IEnumerator EnemySpawns()
    {
        yield return new WaitForSeconds(2f);
        EnemySpawn();
        enemySpawnBool = true;
    }

}
