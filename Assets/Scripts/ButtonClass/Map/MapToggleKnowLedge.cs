using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapToggleKnowLedge : MonoBehaviour
{
    public GameObject triggerObj;

    private void Start()
    {
        this.GetComponent<Toggle>().onValueChanged.AddListener((bool isChange) =>
        {
            // StartCoroutine(ShowKnowledge());
            ShowKnowledge();
        });
    }
    void ShowKnowledge()
    {
        BottomBtnColorManager._Instance.BackNormalColor();
        if (triggerObj == null) return;
        triggerObj.GetComponent<Button>().Select();
        ExecuteEvents.Execute<IPointerClickHandler>(triggerObj, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
    }
}
