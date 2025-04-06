using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void Awake()
    {
        Instance = this;
    }

    public void PurchaseGem(int gemPrice, Action action)
    {
        if (GameData.Gem >= gemPrice)
        {
            action?.Invoke();
        }
        else
        {
            
        }
    }
}
