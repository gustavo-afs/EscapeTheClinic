using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [SerializeField] Image vignetteImage;
    [SerializeField] float totalTime;
    [SerializeField] float transparencyMin; 
    [SerializeField] float beatTimeMin = 1;
    Color colorTransparent;
    Color colorOpaque;
    float countDown;
    float beatTime;

    private void Start()
    {
        countDown = totalTime;
        colorTransparent = vignetteImage.color;
        colorTransparent.a = transparencyMin;
        colorOpaque = vignetteImage.color;
        colorOpaque.a = 1f;
    }
    void Update()
    {
        //
        colorOpaque.a = (totalTime * transparencyMin / countDown);
        beatTime = (totalTime/ countDown * beatTimeMin);
        //


        //float test = countDown - Time.deltaTime;
        //Debug.Log("test: " + test + "countdown: " + countDown + " Clamp: " + (Mathf.Max(test - countDown, 0f)));
        if (countDown > 0)
        {
            countDown = Mathf.Max(countDown - Time.deltaTime,0f);
            Debug.Log("Time Remaining:" + countDown);
            vignetteImage.color = Color.Lerp(colorTransparent, colorOpaque, Mathf.PingPong(Time.time * beatTime, 1f));
        }
        else
        {
            Debug.Log("you loose!");
            Time.timeScale = 0f;
        }



    }
}
