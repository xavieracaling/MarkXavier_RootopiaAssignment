using UnityEngine;
using UnityEngine.UI;

public class ArmyRecruited : MonoBehaviour
{
    public Image Icon;
    public Text LevelUI;
    public Text ClassUI;
    public Text StatusUI;
    public void SetDataArmy(Sprite icon, int level, Class _class, ArmyStatus armyStatus)
    {
        Icon.sprite = icon;
        LevelUI.text = level.ToString();
        ClassUI.text = _class.ToString();
        StatusUI.text = armyStatus.ToString();
    }
}
