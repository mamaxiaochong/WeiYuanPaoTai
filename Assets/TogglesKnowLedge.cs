using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TogglesKnowLedge : MonoBehaviour
{
    public KnowLedgePoint knowLedge;
    private void Start()
    {
       // knowLedge = this.GetComponent<KnowLedgePoint>();
        this.GetComponent<Toggle>().onValueChanged.AddListener((bool onorfalse) =>
        {
            if (onorfalse)
            {
               // FindObjectOfType<ScrollViewButtonClickManager>().ShowKnowLedgePoint(knowLedge);
              //  ScrollViewButtonClickManager._Instance.ShowKnowLedgePoint(knowLedge);
               // Debug.Log(onorfalse+":"+this.GetComponent<Toggle>().name);
            }
        });
    }
}
