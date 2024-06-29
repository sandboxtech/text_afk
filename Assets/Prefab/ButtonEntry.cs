
using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEntry : MonoBehaviour
{
    public Image image;
    public Button button;
    public Text text;

    private bool visible = true;

    public void Visible(bool visible)
    {
        this.visible = visible;
        if (visible)
        {
            image.color = Color.white;
            float v = 204f / 255;
            text.color = new Color(v, v, v);
        }
        else
        {
            image.color = Color.grey;
            text.color = Color.grey;
        }
    }
    public bool Visible()
    {
        return visible;
    }
}
