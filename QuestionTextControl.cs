using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestionTextControl : MonoBehaviour
{

    //Declaration
    public List<GameObject> questions = new List<GameObject>();

    public Transform[] spawn;
    // Start is called before the first frame update
    void Start()
    {
        Shuffle(questions);
        for (int n = 0; n < questions.Count; n++)
        {
            //First kay random Gen between 0 to the length of the questions list
            //Then random the array question then put it on questions n so shuffle
            // assigning of random question sa sign
            Instantiate(questions[n], spawn[n].position, Quaternion.identity);
            // var temp = questions[rand];
            // pressurePlate[n].gameObject.tag = ""
            // signs[n].text = questions[n];
        }

    }
    void Shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            T temp = inputList[i];
            int rand = Random.RandomRange(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;

        }

    }

}
