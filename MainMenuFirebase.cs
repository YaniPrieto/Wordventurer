using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Auth;

public class MainMenuFirebase : MonoBehaviour
{

    public Text Welcome;
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;

    public FirebaseAuth auth;

    public FirebaseUser User;

    public DatabaseReference DBreference;

    void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    public IEnumerator GetUserProfile()
    {
        Debug.Log("Trigger");
        User = auth.CurrentUser;
        yield return new WaitForSeconds(0);
        if (User != null)
        {
            string name = User.DisplayName;
            string email = User.Email;
            // The user's Id, unique to the Firebase project.
            // Do NOT use this value to authenticate with your backend server, if you
            // have one; use User.TokenAsync() instead.
            string uid = User.UserId;
            Welcome.text = "Welcome " + name;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InitializeFirebase();
        StartCoroutine(GetUserProfile());

    }

    // Update is called once per frame
    void Update()
    {


    }
}
