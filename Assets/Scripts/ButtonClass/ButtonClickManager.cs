using System;
using UnityEngine;
using System.Collections;

public class ButtonClickManager : MonoBehaviour
{
    public static event Action<ButtonClick, GameObject, Vector3, Vector3> ShowModelInterfaceAction;
    public static void ShowObject(ButtonClick buttonClick, Vector3 targetPos, Vector3 targetRoate, GameObject showObj = null)
    {
        switch (buttonClick.buttonType)
        {
            case ButtonType.ShowModelInterface:
                if (showObj != null && ShowModelInterfaceAction != null)
                {
                    ShowModelInterfaceAction(buttonClick, showObj, targetPos, targetRoate);
                }
                break;
            case ButtonType.ShowComplete:
                break;
            default:
                break;
        }
    }
}
