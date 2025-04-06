using UnityEngine;
using UnityEngine.UI;

public class Recruitment : CharacterAbs
{
    public Image Icon;
    public int GemPrice;
    public Button Recruit;
    public Text PowerUI;
    public Text GemUI;
    void Start()
    {
        PowerUI.text = $"POWER: {Power.ToString("N0")}" ;
        GemUI.text = GemPrice.ToString("N0");
        Recruit.onClick.AddListener(() => {
            recruit();
        });
    }
    void recruit()
    {
        GameManager.Instance.PurchaseGem(GemPrice,() => RecruitmentManager.Instance.AddArmyRecruitedPrefab(Icon.sprite,Level,_ClassType,_ArmyStatus, Power));
    }
}
