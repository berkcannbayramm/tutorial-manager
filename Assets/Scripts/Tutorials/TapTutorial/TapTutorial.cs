using DG.Tweening;
using UnityEngine;

public class TapTutorial : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform hand;

    Camera _mainCam;

    private void OnEnable()
    {
        StartTapTutorial();
    }

    private void OnDestroy()
    {
        DOTween.Kill(this);
    }
    public void SetPosition(Transform targetPosition)
    {
        _mainCam = Camera.main;

        transform.position = _mainCam.WorldToScreenPoint(targetPosition.position);
    }
    private void StartTapTutorial()
    {
        hand.DOScale(Vector3.one * .8f, .2f).SetId(this).SetLoops(-1, LoopType.Yoyo);
    }
}