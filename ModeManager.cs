using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModeManager : MonoBehaviour
{
    public GameObject storyModeButton;
    public GameObject arcadeModeButton;
    public GameObject wordbankModeButton;
    public GameObject leaderboardModeButton;
    public GameObject backButton;
    public GameObject LeaderBoardPanel;

    public void openStoryMode()
    {
        SceneManager.LoadScene("Intro-Scene");
    }
    public void openArcadeMode()
    {
        SceneManager.LoadScene("Demo Stage");
        // SceneManager.LoadScene(1);
    }

    public void openWordbank()
    {
        SceneManager.LoadScene("WordBank");
    }
    public void openLeaderboard()
    {
        LeaderBoardPanel.SetActive(true);
    }
    public void backMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Back()
    {
        LeaderBoardPanel.SetActive(false);
    }
}
