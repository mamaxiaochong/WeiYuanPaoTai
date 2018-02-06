using UnityEngine;
using System.Collections;

public class LoadStartStageUI : MonoBehaviour
{

    public GameObject nextInterface = null;

	void Update () {
	    if (Input.GetMouseButtonDown(0))
	    {
	        if (nextInterface != null)
	        {
               // Debug.Log(nextInterface.GetComponent<CanvasGroup>().alpha);
	            FindObjectOfType<UIFadeManager>().StartFdde(nextInterface.GetComponent<CanvasGroup>());
                this.gameObject.SetActive(false);
            }
	    }
	}
}
