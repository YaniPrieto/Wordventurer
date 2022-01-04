using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Auth;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreMng;
    public Text scoreText;
    public int score, highScore;
    private int coinsValue = 100;
    private int enemyKillScore = 500;
    private int correctAnswer = 250;

    private int openDoorScore = 1000;

    [Header("Firebase")]
    public DependencyStatus dependencyStatus;

    public FirebaseAuth auth;

    public FirebaseUser User;

    public DatabaseReference DBreference;
    // Start is called before the first frame update
    void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
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
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeFirebase();
        StartCoroutine(GetUserProfile());
        score = PlayerPrefs.GetInt("CurrentScore", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

    }
    public void GetCoin()
    {
        score = score + coinsValue;
        PlayerPrefs.SetInt("CurrentScore", score);

    }
    public void enemyKillPoints()
    {
        score = score + enemyKillScore;
        PlayerPrefs.SetInt("CurrentScore", score);
    }
    public void OpenDoorPoints()
    {
        score = score + openDoorScore;
        PlayerPrefs.SetInt("CurrentScore", score);
    }
    public void BoxCorrect()
    {
        score = score + correctAnswer;
        PlayerPrefs.SetInt("CurrentScore", score);
    }
    public void StageDone()
    {
        if (score >= highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);

            int highscoreHolder = PlayerPrefs.GetInt("HighScore");
            StartCoroutine(UpdateHighScore(highscoreHolder));
        }
        PlayerPrefs.SetInt("CurrentScore", score);
    }
    public IEnumerator UpdateHighScore(int _highscore)
    {
        //Set the currently logged in user xp
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("HighScore").SetValueAsync(_highscore);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.LogWarning("Highscore is updated to the database");
            //Xp is now updated
        }
    }


}
