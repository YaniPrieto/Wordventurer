
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;


    //Screen object variables
    public GameObject loginUI;
    public GameObject registerUI;
    public GameObject MainMenuUI;
    public GameObject userDataUI;
    public GameObject scoreBoardUI;
    public GameObject wordBankUI;
    public GameObject Canvas;
    public GameObject firebase;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }
    public void ClearScreen()
    {
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        MainMenuUI.SetActive(false);
        userDataUI.SetActive(false);
        scoreBoardUI.SetActive(false);
        Canvas.SetActive(true);
    }

    //Functions to change the login screen UI
    public void LoginScreen() //Back button
    {
        ClearScreen();
        loginUI.SetActive(true);
    }
    public void RegisterScreen() // Regester button
    {
        ClearScreen();
        registerUI.SetActive(true);
    }
    public void MainMenuScreen()
    {
        ClearScreen();
        MainMenuUI.SetActive(true);
    }
    public void UserDataScreen()
    {
        ClearScreen();
        userDataUI.SetActive(true);

    }
    public void ScoreBoardScreen()
    {
        ClearScreen();
        scoreBoardUI.SetActive(true);

    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void BackAuth()
    {
        SceneManager.LoadScene("DecideAuth");
    }
    public void WordBank()
    {
        ClearScreen();
        Canvas.SetActive(false);
        wordBankUI.SetActive(true);
    }
    public void GameMenu()
    {
        // DontDestroyOnLoad(firebase);
        SceneManager.LoadScene("Main Menu");
    }

}

