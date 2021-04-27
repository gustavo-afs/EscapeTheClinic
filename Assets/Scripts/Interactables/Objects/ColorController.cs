using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] Color[] circleKeys = new Color[4];

    public void UpdateCircleKeys(int keyIndex, Color colorIndex)
    {
        circleKeys[keyIndex] = colorIndex;

        if (circleKeys[0].ToString() == "RGBA(0.082, 0.380, 0.090, 1.000)" & circleKeys[1].ToString() == "RGBA(0.082, 0.408, 0.635, 1.000)" & circleKeys[2].ToString() == "RGBA(0.639, 0.082, 0.082, 1.000)" & circleKeys[3].ToString() == "RGBA(0.427, 0.078, 0.627, 1.000)")
        {
            Debug.Log("Got it");
        }
        else
        {
            Debug.Log("no");
        }
    
    }

}
