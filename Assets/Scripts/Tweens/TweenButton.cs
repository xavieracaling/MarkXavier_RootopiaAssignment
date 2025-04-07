using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class TweenButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float CooldownEnter = 0.25f;
    public float CooldownExit= 0.25f;
    public Ease Ease = Ease.InOutSine;
    public Transform ImageT;
    public Vector2 OriginalTransformVector;
    public Vector2 NewTransformVector;
    public Vector2 OriginalImageTransformVector;
    public Vector2 NewImageTransformVector;
    public float Multiplier = 1.5f;
   

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(NewTransformVector,CooldownEnter).SetEase(Ease);
        if (ImageT != null)
        {
            ImageT.DOKill();
            ImageT.DOScale(NewImageTransformVector,CooldownEnter * 0.4f).SetEase(Ease).OnComplete( () => ImageT.DOScale(OriginalImageTransformVector,CooldownExit) );
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(OriginalTransformVector,CooldownExit ).SetEase(Ease);
        if (ImageT != null)
        {
            ImageT.DOKill();
            ImageT.DOScale(OriginalImageTransformVector,CooldownEnter  * 1.3f).SetEase(Ease);
        }
    }

    void Start()
    {
        OriginalTransformVector = transform.localScale ;
        NewTransformVector = transform.localScale * Multiplier;
        if (ImageT != null)
        {
            OriginalImageTransformVector = ImageT.localScale ;
            NewImageTransformVector = ImageT.localScale * Multiplier;
        }
    }

    void Update()
    {
        
    }
}
