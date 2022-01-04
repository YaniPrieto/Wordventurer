using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    void OnEnable()
    {
       // SceneManager.LoadScene();
        // final1
        SceneManager.LoadScene("Main Menu");
    }
}
