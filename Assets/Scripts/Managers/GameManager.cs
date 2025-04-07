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
            GameData.Gem -= gemPrice;
            if (GameData.Gem <= 0)
                GameData.Gem = 0;
                
            action?.Invoke();
            UIManager.Instance.UpdateListUIGem ();
        }
        else
        {
            
        }
    }
}
