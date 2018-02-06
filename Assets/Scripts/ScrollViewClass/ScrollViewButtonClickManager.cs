using UnityEngine;
using System.Collections;
using System.Globalization;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollViewButtonClickManager : MonoBehaviour
{
    public GameObject lastObj = null;
    public GameObject lastHightColor = null;
    private ScrollRect scrollect;
    public static ScrollViewButtonClickManager _Instance;
    private void Awake()
    {
        _Instance = this;
    }
    public void ShowKnowLedgePoint(KnowLedgePoint knowLedgePoint, Vector2 pos, GameObject hightColor)
    {
        if (knowLedgePoint.knowObj.activeSelf) return;
        if (lastObj != null && lastObj.activeSelf)
        {
            lastObj.SetActive(false);
        }
        if (lastHightColor != null)
        {
            lastHightColor.SetActive(false);
        }
        knowLedgePoint.knowObj.GetComponent<RectTransform>().anchoredPosition = pos;
        knowLedgePoint.knowObj.SetActive(true);
        hightColor.SetActive(true);
        scrollect = knowLedgePoint.knowObj.transform.parent.parent.GetComponent<ScrollRect>();
        scrollect.content = knowLedgePoint.knowObj.GetComponent<RectTransform>();
        lastObj = knowLedgePoint.knowObj;
        lastHightColor = hightColor;
    }
    public IEnumerator LoadTest(GameObject objButton)
    {
        yield return null;
        if (objButton == null) yield break;
        objButton.GetComponent<Button>().Select();
        ExecuteEvents.Execute<IPointerClickHandler>(objButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        Debug.Log("执行了");
        yield break;
    }
}
