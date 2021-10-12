using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game2Controller : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private Toggle[] gameToggle;
    [SerializeField] private AudioClip[] clip;
    [SerializeField] private AudioSource[] audio;

    [Header("Button")]
    [SerializeField] private Button[] gameButton;
    [SerializeField] private Button[] menuButton;

    [Header("Panel")]
    [SerializeField] private GameObject panel;

    [Header("Object")]
    [SerializeField] private GameObject objCar;

    [SerializeField] private int speed;

    private void Awake()
    {
        SetButton();
    }

    private void Update()
    {
        Scene _scene = SceneManager.GetActiveScene();
        if (_scene == SceneManager.GetSceneByName("GamePlayGame2"))
            objCar.transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    private void SetButton()
    {
        Scene _scene = SceneManager.GetActiveScene();
        if(_scene == SceneManager.GetSceneByName("GamePlayGame2"))
        {
            gameToggle[0].onValueChanged.AddListener(CheckEngine);
            gameToggle[1].onValueChanged.AddListener(CheckSiren);

            gameButton[0].onClick.AddListener(BackToMainMenu);
            gameButton[1].onClick.AddListener(OpenPanel);
            gameButton[2].onClick.AddListener(ClosePanel);
        }
        else if(_scene == SceneManager.GetSceneByName("MenuGame2"))
        {
            menuButton[0].onClick.AddListener(PlayGame);
            menuButton[1].onClick.AddListener(ExitGame);
        }

    }

    #region GamePlay Script
    private void CheckEngine(bool value)
    {
        if (value == false)
        {
            gameToggle[0].GetComponent<Toggle>().isOn = false;
            audio[0].clip = clip[0];
            audio[0].Play();
        }
        else if (value == true)
        {
            gameToggle[0].GetComponent<Toggle>().isOn = true;
            audio[0].clip = clip[0];
            audio[0].Stop();
        }
    }

    private void CheckSiren(bool value)
    {
        if (value == false)
        {
            gameToggle[1].GetComponent<Toggle>().isOn = false;
            audio[1].clip = clip[1];
            audio[1].Play();
        }
        else if (value == true)
        {
            gameToggle[1].GetComponent<Toggle>().isOn = true;
            audio[1].clip = clip[1];
            audio[1].Stop();
        }
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene("MenuGame2");
    }

    private void ClosePanel()
    {
        panel.SetActive(false);
    }

    private void OpenPanel()
    {
        panel.SetActive(true);
    }
    #endregion

    #region Menu Script

    private void PlayGame()
    {
        SceneManager.LoadScene("GamePlayGame2");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    #endregion
}
