using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDropWorld : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image circleImg;
    [SerializeField] private Transform hand, targetPos;

    private Camera _mainCam;
    private void OnDestroy()
    {
        DOTween.Kill(this);
    }
    private void OnEnable()
    {
        //_mainCam = Camera.main;

        StartTutorial();
    }

    public void SetPosition(Transform basePosition, Transform targetPosition)
    {
        _mainCam = Camera.main;

        circleImg.transform.position = _mainCam.WorldToScreenPoint(basePosition.position);
        
        targetPos.position = _mainCam.WorldToScreenPoint(targetPosition.position);

    }

    private void StartTutorial()
    {
        /*Vector3 startPos = _mainCam.WorldToScreenPoint(_basePosition.position);
        Vector3 endPos = _mainCam.WorldToScreenPoint(_targetPosition.position);

        circleImg.transform.position = startPos;

        targetPos.position = endPos;*/

        Sequence topToBottomSequence = DOTween.Sequence().SetId(this);

        Tween pointDown = circleImg.DOColor(new Color32(0, 0, 0, 255), .5f);
        Tween pointUp = circleImg.DOColor(new Color32(0, 0, 0, 0), .5f);

        Tween moveTargetPos = circleImg.transform.DOLocalMove(targetPos.localPosition, .7f);

        Tween handDown = hand.DOScale(1f, .5f);
        Tween handUp = hand.DOScale(1.25f, .5f);

        topToBottomSequence.Append(handDown);
        topToBottomSequence.Join(pointDown);
        topToBottomSequence.Append(moveTargetPos);
        topToBottomSequence.AppendInterval(.5f);
        topToBottomSequence.Append(handUp);
        topToBottomSequence.Join(pointUp);
        topToBottomSequence.SetLoops(-1, LoopType.Restart);
        topToBottomSequence.Play();
    }
}