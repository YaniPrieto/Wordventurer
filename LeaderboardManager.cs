using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using System.Linq;

public class LeaderboardManager : MonoBehaviour
{

    public Text Welcome;
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;

    public FirebaseAuth auth;

    public FirebaseUser User;

    public DatabaseReference DBreference;
    public GameObject pointElement;
    public Transform scoreboardContent;


    void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    private IEnumerator GetUserProfile()
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
            Debug.LogWarning("Welcome: " + name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeFirebase();
        StartCoroutine(GetUserProfile());
        StartCoroutine(LoadScoreboardData());


    }

    // Update is called once per frame
    // public void LeaderboardButton()
    // {
    //     StartCoroutine(LoadScoreboardData());
    // }
    void Update()
    {


    }
    private IEnumerator LoadScoreboardData()
    {
        //Get all the users data ordered by kills amount
        var DBTask = DBreference.Child("users").OrderByChild("HighScore").GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            //Destroy any existing scoreboard elements
            foreach (Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }

            //Loop through every users UID
            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {


                int highscore = int.Parse(childSnapshot.Child("HighScore").Value.ToString());
                string username = childSnapshot.Child("username").Value.ToString();

                //Instantiate new scoreboard elements
                GameObject scoreboardElement = Instantiate(pointElement, scoreboardContent);
                scoreboardElement.GetComponent<PointElement>().NewPointElement(username, highscore);
            }
            //Go to scoreboard screen
        }
    }
}
