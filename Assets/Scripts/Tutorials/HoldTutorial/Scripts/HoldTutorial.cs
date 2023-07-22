using Common.Tutorial;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Tutorial
{
    public class HoldTutorial : MonoBehaviour
    {
        [SerializeField] private Image circleImg;
        [SerializeField] private Transform hand;

        private void OnDestroy()
        {
            DOTween.Kill(this);
        }
        private void OnDisable()
        {
            DOTween.Kill(this);
        }

        private void Start()
        {
            StartTutorial();
        }

        private void StartTutorial()
        {
            Sequence topToBottomSequence = DOTween.Sequence().SetId(this);

            Tween pointDown = circleImg.DOColor(new Color32(0, 0, 0, 255), .5f);
            Tween pointUp = circleImg.DOColor(new Color32(0, 0, 0, 0), .5f);

            Tween handDown = hand.DOScale(1f, .5f);
            Tween handUp = hand.DOScale(1.25f, .5f);

            topToBottomSequence.Append(handDown);
            topToBottomSequence.Append(pointDown);
            topToBottomSequence.AppendInterval(.5f);
            topToBottomSequence.Append(handUp);
            topToBottomSequence.Join(pointUp);
            topToBottomSequence.SetLoops(-1, LoopType.Restart);
            topToBottomSequence.Play();
        }
    }
}

