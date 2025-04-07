using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitmentManager : MonoBehaviour
{
    public ArmyRecruited ArmyRecruitedPrefab;
    public Transform Content;
    public static RecruitmentManager Instance;
    public List<ArmyRecruited>ListArmyRecruited = new List<ArmyRecruited>();
    public Text TotalPowerUI;
    public int ITotalPower;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ITotalPower = 0;
    }
    public void AddArmyRecruitedPrefab(Sprite icon, int level, Class _class, ArmyStatus armyStatus, int power)
    {
        ITotalPower += power;
        TotalPowerUI.text = ITotalPower.ToString();
        ArmyRecruited armyRecruited = Instantiate(ArmyRecruitedPrefab,Content);
        armyRecruited.SetDataArmy(icon,level,_class,armyStatus);
        ListArmyRecruited.Add(armyRecruited);
    }
    
}
