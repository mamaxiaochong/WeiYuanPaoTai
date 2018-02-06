using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BottomBtnColorManager : MonoBehaviour {

    // Use this for initialization

    public Image lastImage;
    public Sprite NormalSprite;
    public Sprite hightSprite;

    public Image[] Images=new Image[4];

    public static BottomBtnColorManager _Instance;
	void Start ()
	{
	    _Instance = this;
	}

    public void ShowHightColor(Image currImage)
    {
        if (currImage == null) return;
        if (lastImage != null)
        {
            lastImage.sprite = NormalSprite;
            lastImage.color = new Color(1, 1, 1, 1);
        }
        currImage.sprite = hightSprite;
        currImage.color = new Color(255, 255, 255, 255);
        lastImage = currImage;
    }

    public void BackNormalColor()
    {
        for (int i = 0; i < Images.Length; i++)
        {
            Images[i].sprite = NormalSprite;
        }
    }
}
