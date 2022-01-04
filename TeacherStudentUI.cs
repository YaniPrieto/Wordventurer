using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeacherStudentUI : MonoBehaviour
{

    public void StudentButton() {

    SceneManager.LoadScene("Student Login");

    }
      public void TeacherButton() {

     SceneManager.LoadScene("Teacher Login");
        
    }
}
