using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorController : InteractiveActions
{
    [SerializeField] Animator keyGlass;
    [SerializeField] Text screenText;
    [SerializeField] GameObject[] circleKeys = new GameObject[4];
    Color[] colorKeys;
    

    private void Start()
    {
       colorKeys = new Color[circleKeys.Length];

       for (int i = 0; i < circleKeys.Length; i++)
        {
            colorKeys[i] = circleKeys[i].gameObject.GetComponent<SpriteRenderer>().color;
        }
    }

    public void UpdateCircleKeys(int keyIndex, Color colorIndex)
    {
        colorKeys[keyIndex] = colorIndex;

        if (colorKeys[0].ToString() == "RGBA(0.427, 0.078, 0.627, 1.000)" & 
            colorKeys[1].ToString() == "RGBA(0.082, 0.380, 0.090, 1.000)" & 
            colorKeys[2].ToString() == "RGBA(0.082, 0.408, 0.635, 1.000)" & 
            colorKeys[3].ToString() == "RGBA(0.639, 0.082, 0.082, 1.000)")
        {
            screenText.text = "Thank you Dr., now your Key is available at your Desk";            
            foreach(GameObject circle in circleKeys)
            {
                circle.SetActive(false);
            }
            keyGlass.Play("KeyGlass");
            PlayAudio();
        }    
    }

}
