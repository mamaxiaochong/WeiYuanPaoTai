using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapButtonClick : MonoBehaviour
{

  //  public KnowLedgePoint knowLedgePoint;
    public GameObject button;

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            BottomUIManager._Instance.currentScrollview.SetActive(true);
            BottomUIManager._Instance.currentButtonScrollview.SetActive(true);

            ScrollViewButtonClickManager._Instance.lastHightColor.SetActive(false);
            ScrollViewButtonClickManager._Instance.lastObj.SetActive(false);
            ExecuteEvents.Execute<IPointerClickHandler>(button, new PointerEventData(EventSystem.current),
                ExecuteEvents.pointerClickHandler);
            BottomUIManager._Instance.currentMap.SetActive(false);
            BottomUIManager._Instance.isRotate = false;
        });
    }
}
