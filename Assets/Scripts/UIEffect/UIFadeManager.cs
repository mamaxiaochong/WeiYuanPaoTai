using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UIFadeManager : MonoBehaviour
{
    public static UIFadeManager _Instance;
    private void Awake()
    {
        _Instance = this;
    }

    public void StartFdde(CanvasGroup canvasGroup)
    {
        if (canvasGroup.alpha > 0)
        {
            StartCoroutine(StartFadeOut(canvasGroup));
        }
        else
        {
            StartCoroutine(StartFadeIn(canvasGroup));
        }
    }
    private IEnumerator StartFadeIn(CanvasGroup canvasGroup)
    {
        canvasGroup.DOFade(1, 1).OnComplete(() =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        });

        yield return null;
    }
    private IEnumerator StartFadeOut(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.DOFade(0, 1);      
        yield return null;
    }
    public void StartRotate(Transform t)
    {
        if (t.localEulerAngles == Vector3.zero)
        {
            t.DOLocalRotate(new Vector3(0, 0, 45), 1);
        }
        else
        {
            t.DOLocalRotate(Vector3.zero, 1);
        }
    }
}
