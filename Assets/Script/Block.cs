using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject turret;
    public static Block Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

}
