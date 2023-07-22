using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DragTutorialCircleHandler : MonoBehaviour
{
    [SerializeField] private Transform hand, pivot;
    [SerializeField] private bool willReverseRotate;
    private Quaternion handRotation;
    private void Start()
    {
        var rot = willReverseRotate ? Vector3.back : Vector3.forward;
        
        handRotation = hand.rotation;
        pivot.DORotate(rot * -60, 0.2f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental)
            .OnUpdate(ResetHandRotation);
    }

    private void ResetHandRotation()
    {
        hand.rotation = handRotation;
    }
}