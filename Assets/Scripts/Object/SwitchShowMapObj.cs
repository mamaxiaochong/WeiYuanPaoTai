using UnityEngine;
using System.Collections;

public class SwitchShowMapObj : MonoBehaviour
{
    [SerializeField]
    public int currentLoadObjCount = 0;
    [SerializeField]
    public int objCount = 3;
    public Transform freeCameraTran;
    public GameObject lastShowObj;
    void Start()
    {
        ButtonClickManager.ShowModelInterfaceAction += ButtonClickManager_ShowModelAction;
    }
    private void ButtonClickManager_ShowModelAction(ButtonClick buttonClick, GameObject obj, Vector3 targetPos, Vector3 targetRotate)
    {
        if (lastShowObj != null)
        {
            lastShowObj.SetActive(false);
        }
        obj.SetActive(true);
        lastShowObj = obj;
        UIFadeManager._Instance.StartFdde(this.GetComponent<CanvasGroup>());
        MoveCamera._Instance.tempTim = 0;
        MoveCamera._Instance.StartMoveAndRotate(targetPos, targetRotate, obj);
    }
}
