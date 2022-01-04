using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public GameObject OptionsPanel;
    public GameObject HelpPanel;
    public GameObject AboutPanel;
    // Start is called before the first frame update
    void Start()
    {
        AboutPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CleanUI()
    {
        OptionsPanel.SetActive(false);
        HelpPanel.SetActive(false);
        AboutPanel.SetActive(false);
    }
    public void Logout()
    {
        SceneManager.LoadScene("Teacher Login");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Mode");
    }

    public void OptionsGame()
    {
        if (OptionsPanel.activeInHierarchy == false)
        {
            OptionsPanel.SetActive(true);
        }
        else if (OptionsPanel.activeInHierarchy == true)
        {

            OptionsPanel.SetActive(false);
        }
    }

    public void HelpGame()
    {
        if (HelpPanel.activeInHierarchy == false)
        {
            HelpPanel.SetActive(true);
        }
        else if (HelpPanel.activeInHierarchy == true)
        {

            HelpPanel.SetActive(false);
        }
    }

    public void AboutGame()
    {
        if (AboutPanel.activeInHierarchy == false)
        {
            AboutPanel.SetActive(true);
        }
        else if (AboutPanel.activeInHierarchy == true)
        {

            AboutPanel.SetActive(false);
        }
    }
}
