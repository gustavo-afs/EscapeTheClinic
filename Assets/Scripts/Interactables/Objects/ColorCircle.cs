using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCircle : InteractiveActions
{
    [SerializeField] Color[] circleColors = new Color[4];
    int colorIndex = 0;
    [SerializeField] int keyIndex;
    ColorController colorController;
    private void Start()
    {
        colorController = transform.GetComponentInParent<ColorController>();
    }
    private void OnMouseOver()
    {
        if (ValidatePlayerClick())
        {
            if (colorIndex == (circleColors.Length - 1))
            {
                colorIndex = 0;
            }
            else
            {
                colorIndex++;
            }
            Color newColor = circleColors[colorIndex];
            gameObject.GetComponent<SpriteRenderer>().color = newColor;
            colorController.UpdateCircleKeys(keyIndex, newColor);
            PlayAudio();
        }
    }
}
