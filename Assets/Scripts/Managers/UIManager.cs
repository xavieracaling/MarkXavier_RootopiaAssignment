using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;
public class UIManager : MonoBehaviour
{
    public List<Text> ListUIGem = new List<Text>();
    public static UIManager Instance;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateListUIGem ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateListUIGem ()
    {
        foreach (var item in ListUIGem)
        {
            item.text = GameData.Gem.ToString("N0");
        }
    }
}
