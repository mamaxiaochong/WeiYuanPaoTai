using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class BottomUIManager : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private const string yiyaScrollViewName = "WYPT_yiya";
    private const string eryaScrollViewName = "WYPTEY_erya";
    private const string xianDaiScrollViewName = "WYTP-XD";
    public GameObject yiyaScrollView;
    public GameObject eryaScrollView;
    public GameObject xianDaiScrollView;

    public Vector3 cameraStartPos = Vector3.zero;
    public Vector3 cameraStartRotate = Vector3.zero;

    public GameObject yiyaButtonScrollview;
    public GameObject eryaButtonScrollview;
    public GameObject sanyaButtonScrollview;
    public static BottomUIManager _Instance;
    public GameObject yiyaButton;
    public GameObject eryaButton;
    public GameObject xiandaiButton;
    public GameObject map_black;
    public GameObject mapUI;
    public GameObject startUI;
    public GameObject knowLedgeCanvas;
    public GameObject buttonCanvas;
    public GameObject mapCanvas;
    public GameObject currentMap;
    public GameObject yiyaMap;
    public GameObject eryaMap;
    public GameObject sanyaMap;
    public GameObject currentButtonScrollview;
    public GameObject currentScrollview;
    public Transform t;
    public bool isRotate = false;
    void Start()
    {
        _Instance = this;
        canvasGroup = this.GetComponent<CanvasGroup>();
        MoveCamera._Instance.CameraMoveComplete += MoveCamera_CameraMoveComplete;
    }
    private void MoveCamera_CameraMoveComplete(GameObject obj)
    {
        t.localEulerAngles = Vector3.zero;
        switch (obj.name.ToString())
        {
            case yiyaScrollViewName:
                yiyaScrollView.SetActive(true);
                eryaScrollView.SetActive(false);
                xianDaiScrollView.SetActive(false);
                //左边按钮滚动列表
                yiyaButtonScrollview.SetActive(true);
                eryaButtonScrollview.SetActive(false);
                sanyaButtonScrollview.SetActive(false);

                currentButtonScrollview = yiyaButtonScrollview;
                currentScrollview = yiyaScrollView;
                ScrollViewButtonClickManager._Instance.StartCoroutine("LoadTest", yiyaButton);
                map_black.SetActive(false);
                mapUI.SetActive(true);
                currentMap = yiyaMap.transform.parent.parent.gameObject;
                yiyaMap.SetActive(true);
                eryaMap.SetActive(false);
                sanyaMap.SetActive(false);

                UIFadeManager._Instance.StartFdde(knowLedgeCanvas.GetComponent<CanvasGroup>());
                UIFadeManager._Instance.StartFdde(buttonCanvas.GetComponent<CanvasGroup>());
                UIFadeManager._Instance.StartFdde(mapCanvas.GetComponent<CanvasGroup>());
                break;
            case eryaScrollViewName:
                yiyaScrollView.SetActive(false);
                eryaScrollView.SetActive(true);
                xianDaiScrollView.SetActive(false);
                //左边按钮滚动列表
                yiyaButtonScrollview.gameObject.SetActive(false);
                eryaButtonScrollview.gameObject.SetActive(true);
                sanyaButtonScrollview.SetActive(false);

                currentButtonScrollview = eryaButtonScrollview;
                currentScrollview = eryaScrollView;
                ScrollViewButtonClickManager._Instance.StartCoroutine("LoadTest", eryaButton);
                map_black.SetActive(false);
                mapUI.SetActive(true);
                currentMap = eryaMap.transform.parent.parent.gameObject;
                eryaMap.SetActive(true);
                yiyaMap.SetActive(false);
                sanyaMap.SetActive(false);

                UIFadeManager._Instance.StartFdde(knowLedgeCanvas.GetComponent<CanvasGroup>());
                UIFadeManager._Instance.StartFdde(buttonCanvas.GetComponent<CanvasGroup>());
                UIFadeManager._Instance.StartFdde(mapCanvas.GetComponent<CanvasGroup>());
                break;
            case xianDaiScrollViewName:
                yiyaScrollView.SetActive(false);
                eryaScrollView.SetActive(false);
                xianDaiScrollView.SetActive(true);
                yiyaButtonScrollview.gameObject.SetActive(false);
                eryaButtonScrollview.gameObject.SetActive(false);
                sanyaButtonScrollview.SetActive(true);

                currentScrollview = xianDaiScrollView;
                currentButtonScrollview = sanyaButtonScrollview;
                ScrollViewButtonClickManager._Instance.StartCoroutine("LoadTest", xiandaiButton);
                map_black.SetActive(false);
                mapUI.SetActive(true);
                currentMap = sanyaMap.transform.parent.parent.gameObject;
                sanyaMap.SetActive(true);
                yiyaMap.SetActive(false);
                eryaMap.SetActive(false);

                UIFadeManager._Instance.StartFdde(knowLedgeCanvas.GetComponent<CanvasGroup>());
                UIFadeManager._Instance.StartFdde(buttonCanvas.GetComponent<CanvasGroup>());
                UIFadeManager._Instance.StartFdde(mapCanvas.GetComponent<CanvasGroup>());
                break;
            default:
                break;
        }
    }
    public void ShowMapInterface()
    {
        if (isRotate == false)
        {
            UIFadeManager._Instance.StartRotate(t);
            currentScrollview.SetActive(false);
            currentButtonScrollview.SetActive(false);
            if (currentMap != null)
            {
                currentMap.SetActive(true);
            }
            isRotate = true;
            return;
        }
        else
        {
            t.DOLocalRotate(Vector3.zero, 1);
            currentScrollview.SetActive(true);
            currentButtonScrollview.SetActive(true);
            if (currentMap != null)
            {
                currentMap.SetActive(false);
            }
            isRotate = false;
        }
    }
    public void GoBackHomePage()
    {
        isRotate = false;
        currentScrollview.SetActive(false);
        currentButtonScrollview.SetActive(false);
        UIFadeManager._Instance.StartRotate(t);

        MoveCamera._Instance.tempTim = 0;
        UIFadeManager._Instance.StartFdde(knowLedgeCanvas.GetComponent<CanvasGroup>());
        UIFadeManager._Instance.StartFdde(buttonCanvas.GetComponent<CanvasGroup>());
        UIFadeManager._Instance.StartFdde(startUI.GetComponent<CanvasGroup>());
        UIFadeManager._Instance.StartFdde(mapCanvas.GetComponent<CanvasGroup>());

        MoveCamera._Instance.StartMoveAndRotate(cameraStartPos, cameraStartRotate);
        ScrollViewButtonClickManager._Instance.lastObj.gameObject.SetActive(false);
        ScrollViewButtonClickManager._Instance.lastHightColor.gameObject.SetActive(false);
    }
    public void OpenURL()
    {
        Application.OpenURL("http://m.ypzz.cn:8010/YaBo/ShowHall/Fram360?url=wyUrl&id=17&title=%E5%A8%81%E8%BF%9C%E7%82%AE%E5%8F%B0");
    }
    public void BackScrollview()
    {
        isRotate = false;
        currentScrollview.SetActive(true);
        currentButtonScrollview.SetActive(true);
        UIFadeManager._Instance.StartRotate(t);
        currentMap.SetActive(false);
    }
}
