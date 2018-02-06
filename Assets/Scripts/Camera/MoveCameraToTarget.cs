using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraToTarget : MonoBehaviour
{
    public static event Action<TargetPoint,MoveCameraToTarget,Transform> MoveCameraActionEvent;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GetTargetPoint(hit);
            }
        }
    }

    private void GetTargetPoint(RaycastHit hit)
    {
        if (hit.collider != null && hit.transform.GetComponent<TargetPoint>() != null)
        {
            Debug.Log("我的射线碰撞到了TargetPoint");
            if (MoveCameraActionEvent != null)
            {
                MoveCameraActionEvent(hit.transform.GetComponent<TargetPoint>(),this,this.transform);
               Debug.Log("开始触发移动事件");
            }

        }
    }
}
