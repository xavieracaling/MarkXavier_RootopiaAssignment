using UnityEngine;
using UnityEngine.UI;

public class Recruitment : CharacterAbs
{
    public Image Icon;
    public int GemPrice;
    public Button Recruit;
    public Text PowerUI;
    public Text GemUI;
    public GameObject CooldownReq;
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
        GameManager.Instance.PurchaseGem(GemPrice,() => {
            CooldownReq.SetActive(true);
            CooldownRecruitment cooldownRecruitment = CooldownReq.GetComponent<CooldownRecruitment>();
            cooldownRecruitment.Initialize();
            RecruitmentManager.Instance.AddArmyRecruitedPrefab(Icon.sprite,Level,_ClassType,_ArmyStatus, Power);
        } );
    }
}
