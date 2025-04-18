using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;
public class UIManager : MonoBehaviour
{
    public List<Text> ListUIGem = new List<Text>();
    public static UIManager Instance;
    public GameObject ArmyDashboard;
    public GameObject RecruitmentDashboard;
    public GameObject Map;
    public Vector2 ArmyDashboardOriginal;
    public Vector2 RecruitmentDashboardOriginal;
    public Vector2 MapOriginal;
    public CanvasGroup BlockingBG;
    public List<CanvasGroup> ListDarkSpiritCG = new List<CanvasGroup>();
    public CanvasGroup BGMissionCG;
    public CanvasGroup MissionCG;
    public Text MissionDescUI;
    void Awake()
    {
        Instance = this;
        ArmyDashboardOriginal = ArmyDashboard.transform.localPosition;
        RecruitmentDashboardOriginal = RecruitmentDashboard.transform.localPosition;
        MapOriginal = Map.transform.localPosition;
    }
    void Start()
    {
        UpdateListUIGem ();
        foreach (var item in ListDarkSpiritCG)
        {
            item.DOFade(0f,0.8f).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenMission(string description = "")
    {
        BGMissionCG.alpha = 0;
        MissionCG.alpha = 0;

        BGMissionCG.DOKill();
        MissionCG.DOKill();

        BGMissionCG.blocksRaycasts = true;
        MissionCG.blocksRaycasts = true;

        BGMissionCG.DOFade(1,0.35f).SetEase(Ease.OutFlash);
        MissionCG.DOFade(1,0.35f).SetEase(Ease.OutFlash).SetDelay(0.1f);
        
        MissionDescUI.text = description;
    }
    public void CloseMission()
    {
        BGMissionCG.DOKill();
        MissionCG.DOKill();

        
        BGMissionCG.DOFade(0,0.35f).SetEase(Ease.OutFlash).SetDelay(0.1f).OnComplete(() => {MissionCG.blocksRaycasts = false; BGMissionCG.blocksRaycasts = false;} );
        MissionCG.DOFade(0,0.35f).SetEase(Ease.OutFlash);
        
    }
    public void UpdateListUIGem ()
    {
        foreach (var item in ListUIGem)
        {
            item.text = GameData.Gem.ToString("N0");
        }
    }
    public void OpenArmyDashboard()
    {
        OpenBlockBG();

        ArmyDashboard.transform.DOKill();
        CanvasGroup canvasGroup = ArmyDashboard.GetComponent<CanvasGroup>();
        canvasGroup.DOKill();

        canvasGroup.alpha = 0; 
        ArmyDashboard.transform.localPosition = new Vector2(0,-1013);
        ArmyDashboard.SetActive(true);
        canvasGroup.DOFade(1,0.35f).SetEase(Ease.OutFlash);
        ArmyDashboard.transform.DOLocalMoveY(ArmyDashboardOriginal.y,0.45f).SetEase(Ease.OutFlash);

    }
    public void CloseArmyDashboard()
    {
        CloseBlockBG();
        ArmyDashboard.transform.DOKill();

        CanvasGroup canvasGroup = ArmyDashboard.GetComponent<CanvasGroup>();
        canvasGroup.DOKill();

        ArmyDashboard.transform.DOLocalMoveY(-1013,0.4f).SetEase(Ease.OutFlash).OnComplete(() => ArmyDashboard.SetActive(false));
        canvasGroup.DOFade(0,0.3f).SetEase(Ease.OutFlash);
    }
    public void OpenRecruitment()
    {
        OpenBlockBG();

        RecruitmentDashboard.transform.DOKill();
        CanvasGroup canvasGroup = RecruitmentDashboard.GetComponent<CanvasGroup>();
        canvasGroup.DOKill();
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 0; 
        RecruitmentDashboard.transform.localPosition = new Vector2(0,-1013);
        canvasGroup.DOFade(1,0.35f).SetEase(Ease.OutFlash);
        RecruitmentDashboard.transform.DOLocalMoveY(RecruitmentDashboardOriginal.y,0.45f).SetEase(Ease.OutFlash);

    }
    public void CloseRecruitment()
    {
        CloseBlockBG();
        RecruitmentDashboard.transform.DOKill();

        CanvasGroup canvasGroup = RecruitmentDashboard.GetComponent<CanvasGroup>();
        canvasGroup.DOKill();

        RecruitmentDashboard.transform.DOLocalMoveY(-1013,0.4f).SetEase(Ease.OutFlash).OnComplete(() =>{canvasGroup.blocksRaycasts = false;} );
        canvasGroup.DOFade(0,0.3f).SetEase(Ease.OutFlash);
    }
    public void OpenMap()
    {
        OpenBlockBG();

        Map.transform.DOKill();
        CanvasGroup canvasGroup = Map.GetComponent<CanvasGroup>();
        canvasGroup.DOKill();
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 0; 
        Map.transform.localPosition = new Vector2(-146,-1013);
        canvasGroup.DOFade(1,0.35f).SetEase(Ease.OutFlash);
        Map.transform.DOLocalMoveY(MapOriginal.y,0.45f).SetEase(Ease.OutFlash);

    }
    public void CloseMap()
    {
        CloseMission();
        CloseBlockBG();
        Map.transform.DOKill();

        CanvasGroup canvasGroup = Map.GetComponent<CanvasGroup>();
        canvasGroup.DOKill();

        Map.transform.DOLocalMoveY(-1013,0.4f).SetEase(Ease.OutFlash).OnComplete(() => canvasGroup.blocksRaycasts = false);
        canvasGroup.DOFade(0,0.3f).SetEase(Ease.OutFlash);
    }
    public void OpenBlockBG()
    {
        BlockingBG.alpha = 0;
        BlockingBG.gameObject.SetActive(true);
        BlockingBG.DOKill();
        BlockingBG.DOFade(0.92f,0.6f).SetEase(Ease.OutFlash);
    }
    public void CloseBlockBG()
    {
        BlockingBG.DOKill();
        BlockingBG.DOFade(0,0.4f).SetEase(Ease.OutFlash).OnComplete(() => BlockingBG.gameObject.SetActive(false));;
    }
}
