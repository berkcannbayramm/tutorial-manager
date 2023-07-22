using DG.Tweening;
using UnityEngine;

namespace Tutorial.Extensions
{
    public static class TutorialManagerExtensions
    {
        public static GameObject AddCreateAnim(this GameObject obj, float time = .3f, float delay = 0, bool canShow = true)
        {
            if(canShow) obj.SetActive(true);

            obj.transform.localScale = Vector3.zero;

            obj.transform.DOScale(Vector3.one, time).SetEase(Ease.OutBack).SetDelay(delay);

            return obj;

        }
        public static GameObject AddHideAnim(this GameObject obj, float time = .3f, float delay = 0)
        {
            obj.transform.DOScale(Vector3.zero, time).SetDelay(delay).SetEase(Ease.InBack).OnComplete(() => obj.SetActive(false));

            return obj;
        }
    }
}