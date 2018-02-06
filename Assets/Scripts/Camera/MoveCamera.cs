using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;
public class MoveCamera : MonoBehaviour
{
    private float startTime = 0;
    [SerializeField]
    public float moveTime;
    [SerializeField]
    public float rotateTime;

    [SerializeField]
    public float tempTim = 0.5f;

    private float lengths;
    public event Action<GameObject> CameraMoveComplete;
    public static MoveCamera _Instance;
    void Awake()
    {
        _Instance = this;
    }
    public void StartMoveAndRotate(Vector3 targetPos, Vector3 targetRotate, GameObject obj = null)
    {
        if (targetRotate == Vector3.zero || targetPos == Vector3.zero) return;
        StartCoroutine(MoveToTarget(targetPos, obj, tempTim));
        StartCoroutine(RotateToTarget(targetRotate));
    }
    IEnumerator MoveToTarget(Vector3 targetPos, GameObject obj, float tempTime)
    {
        transform.DOLocalMoveY(transform.position.y + tempTime * 10, tempTime).OnComplete(() =>
          {
              transform.DOLocalMove(targetPos, moveTime).OnComplete(() =>
              {
                  if (CameraMoveComplete != null)
                  {
                      CameraMoveComplete(obj);
                  }
              });
          });
        yield return new WaitForEndOfFrame();
    }
    IEnumerator RotateToTarget(Vector3 targetRotate)
    {
        transform.DOLocalRotate(targetRotate, rotateTime, RotateMode.Fast);
        yield return new WaitForEndOfFrame();
    }
}
