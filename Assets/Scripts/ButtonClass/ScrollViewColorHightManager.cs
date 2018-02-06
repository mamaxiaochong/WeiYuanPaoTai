using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollViewColorHightManager : MonoBehaviour
{
    public Image lastImage;
    public Sprite NormalSprite;
    public Sprite hightSprite;

    public static ScrollViewColorHightManager _Instance;

    private void Awake()
    {
        _Instance = this;

    }

    public void ShowHightLightColor(Image currImage)
    {
        if (currImage==null) return;
        if (lastImage != null)
        {
            lastImage.sprite = NormalSprite;
            lastImage.color=new Color(1,1,1,1);
        }
        currImage.sprite = hightSprite;
        currImage.color=new Color(255,255,255,255);
        lastImage = currImage;
    }
}
