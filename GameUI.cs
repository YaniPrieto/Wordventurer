using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Database;
using Firebase.Auth;

public class GameUI : MonoBehaviour
{
    public string bgmStage, bgmStageEnd;
    public static GameUI gameUI;
    public ScoreManager scoreManage;
    public string sceneName;
    public TMP_Text gameOverScore, gameOverHigh, victoryScore, victoryHigh;

    public GameObject pausePanel, gameOverPanel, VictoryPanel, LoadingScreen, SettingsScreen;

    public Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        if (gameUI == null)
        {
            gameUI = this;
        }
        else if (gameUI != null)
        {
            Debug.Log("gameUI already exists, destroying object!");
            Destroy(this);
        }


    }
    void Start()
    {
        gameOverHigh.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        victoryHigh.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        FindObjectOfType<NewAudioManager>().Play(bgmStage);
    }
    public void UICleaner()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        VictoryPanel.SetActive(false);
        LoadingScreen.SetActive(false);
        SettingsScreen.SetActive(false);
    }
    IEnumerator LoadAsynchronously(string sceneName)
    {
        UICleaner();
        LoadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            Time.timeScale = 1;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Pause()
    {
        UICleaner();
        pausePanel.SetActive(true);
        Time.timeScale = 0;

    }
    public void GameOver()
    {
        gameOverScore.text = "Score: " + PlayerPrefs.GetInt("CurrentScore", 0).ToString();
        gameOverHigh.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        scoreManage.StageDone();
        gameOverPanel.SetActive(true);
        FindObjectOfType<NewAudioManager>().Pause(bgmStage);
        FindObjectOfType<NewAudioManager>().Play("GameOver");
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
    public void Restart()
    {
        UICleaner();
        PlayerPrefs.SetInt("CurrentScore", 0);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void Victory()
    {
        UICleaner();
        FindObjectOfType<NewAudioManager>().Pause(bgmStage);
        victoryScore.text = "Score: " + PlayerPrefs.GetInt("CurrentScore", 0).ToString();
        victoryHigh.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        scoreManage.StageDone();
        Time.timeScale = 0;
        VictoryPanel.SetActive(true);
        FindObjectOfType<NewAudioManager>().Play(bgmStageEnd);
    }
    public IEnumerator DelaySound()
    {
        yield return new WaitForSeconds(1.5f);

    }
    public void Settings()
    {
        UICleaner();

        SettingsScreen.SetActive(true);
    }
    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously(sceneName));
    }


}
