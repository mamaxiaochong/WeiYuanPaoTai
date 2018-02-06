using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum ButtonType
{
    ShowModelInterface,
    ShowComplete
}
public class ButtonClick : MonoBehaviour
{
    private Button button = null;
    public ButtonType buttonType;
    public GameObject showObj;
    public Vector3 cameraTargetPoint;
    public Vector3 cameraTargetRotate;
    public GameObject lastHightColor;
    public GameObject lastObj;
    private void Start()
    {
        button = this.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() =>
            {
                if (cameraTargetPoint != Vector3.zero)
                {
                    ButtonClickManager.ShowObject(this, cameraTargetPoint, cameraTargetRotate, showObj);
                    ScrollViewButtonClickManager._Instance.lastObj = lastObj;
                    ScrollViewButtonClickManager._Instance.lastHightColor = lastHightColor;
                    lastObj.SetActive(true);
                    lastHightColor.SetActive(true);
                    lastHightColor.transform.parent.parent.localPosition = new Vector3(lastHightColor.transform.parent.parent.localPosition.x, 0, lastHightColor.transform.parent.parent.localPosition.z);
                }
            });
        }
    }
}
