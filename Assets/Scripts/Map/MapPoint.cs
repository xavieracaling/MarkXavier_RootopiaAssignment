using UnityEngine;
using UnityEngine.UI;

public class MapPoint : MonoBehaviour
{
    Button button;
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => UIManager.Instance.OpenMission(Desription));
    }
    public string Desription;
}
