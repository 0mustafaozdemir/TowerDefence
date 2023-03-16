using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taret : Tower
{
  
    public void updateButton()
    {
        RaycastController.InstantitaeTower[RaycastController.rayHitCount].gameObject.GetComponent<Tower>().levelCount++;
    }

    public void NewTower()
    {

        string textInfo = "Taret -" + RaycastController.rayHitCount;

    }
}
