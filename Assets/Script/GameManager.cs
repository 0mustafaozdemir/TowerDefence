using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int money = 1200;
    public static GameManager Instance;
    public TextMeshProUGUI moneyText;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        moneyText.text = money.ToString();
    }
}
