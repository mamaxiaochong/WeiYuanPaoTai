using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollViewButtonClick : MonoBehaviour
{
    private Button button;
    private Image currentImage;
    public KnowLedgePoint knowLedgePoint;
    public int index = 1;
    [HideInInspector]
    public Vector2 startPos;
    private GameObject hightColor;
    void Start()
    {
        if (knowLedgePoint.knowObj != null)
        {
            startPos = knowLedgePoint.knowObj.GetComponent<RectTransform>().anchoredPosition;
        }
        hightColor = this.transform.GetChild(0).gameObject;
        button = this.GetComponent<Button>();
        currentImage = this.GetComponent<Image>();
        if (button != null)
        {
            button.onClick.AddListener(() =>
            {
                ScrollViewButtonClickManager._Instance.ShowKnowLedgePoint(knowLedgePoint, startPos,hightColor);
                if (index == 3)
                {
                    MoveCamera._Instance.tempTim = 0.5f;
                }
                else
                {
                    MoveCamera._Instance.tempTim = 0;
                }
                MoveCamera._Instance.StartMoveAndRotate(knowLedgePoint.targetPointPos,knowLedgePoint.targetRotation,null);
            });
        }
    }
}
