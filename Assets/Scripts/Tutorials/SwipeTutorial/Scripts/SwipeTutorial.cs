using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Tutorial
{
    public class SwipeTutorial : MonoBehaviour
    {
        [SerializeField] private Transform hand, targetPos;

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
            hand.DOMove(targetPos.position, .7f).SetId(this).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }
}