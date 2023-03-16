using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<Transform> wayPointList = new List<Transform>();
    public static Level Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance= this;
        }
       
    }


}
