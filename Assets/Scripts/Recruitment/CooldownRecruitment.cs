using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CooldownRecruitment : MonoBehaviour
{
    public int Cooldown = 3;
    public Text CooldownUI;
    public void Initialize()
    {
        StartCoroutine(initialize());
    }
    IEnumerator initialize()
    {
        int cooldown = Cooldown;
        while (cooldown >= 0)
        {
            CooldownUI.text = cooldown.ToString();
            cooldown--;
            yield return new WaitForSeconds(1);
        }
        gameObject.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
