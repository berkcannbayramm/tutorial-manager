using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DragDropGUI : MonoBehaviour
{
    [SerializeField] private Image circleImg;
    [SerializeField] private Transform hand, targetPos;

    private void OnDestroy()
    {
        DOTween.Kill(this);
    }
    private void OnDisable()
    {
        DOTween.Kill(this);
    }

    private void OnEnable()
    {
        StartTutorial();
    }

    public void SetPosition(Transform handPosition, Transform targetPosition )
    {
        circleImg.transform.position = handPosition.position;
        targetPos.position = targetPosition.position;
    }

    private void StartTutorial()
    {
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