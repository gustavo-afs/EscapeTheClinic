using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : InteractiveActions
{
    [SerializeField] Image vignetteImage;
    [SerializeField] float totalTime;
    [SerializeField] float transparencyMin;
    [SerializeField] float beatTimeMin = 1;
    [SerializeField] GameObject menuPanel;
    public GameObject resumeButton;

    Color colorTransparent;
    Color colorOpaque;
    float countDown;
    float beatTime;
    bool lost = false;

    private void Start()
    {
        countDown = totalTime;
        colorTransparent = vignetteImage.color;
        colorTransparent.a = transparencyMin;
        colorOpaque = vignetteImage.color;
        colorOpaque.a = 1f;
        menuPanel.SetActive(false);
    }
    void Update()
    {
        Debug.Log(Time.timeScale);
        //Pause Menu Request
        if (!lost)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                PauseRequest(true);
            }

            colorOpaque.a = (totalTime * transparencyMin / countDown);
            beatTime = (totalTime / countDown * beatTimeMin);

            if (countDown > 0)
            {
                countDown = Mathf.Max(countDown - Time.deltaTime, 0f);
                Debug.Log("Countdown Timer: " + countDown);
                vignetteImage.color = Color.Lerp(colorTransparent, colorOpaque, Mathf.PingPong(Time.time * beatTime, 1f));
            }
            else
            {
                lost = true;
                PauseRequest(true);
                resumeButton.SetActive(false);
                SendUIMessage("You Lose!");
            }
        }
    }

    public void PauseRequest(bool toPause)
    {

        if (toPause)
        {
            Time.timeScale = 0f;
            menuPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            menuPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void RestartGame()
    {
        PauseRequest(false);
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
