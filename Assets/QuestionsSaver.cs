using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsSaver : MonoBehaviour
{
    private static QuestionsSaver instance;
    public List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();

    public void SaveQuestion(List<QuestionsAndAnswers> List){
        QnAList = List;
    }

    private void Awake()
    {
        // Ensure only one instance of QuestionManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static QuestionsSaver Instance
    {
        get { return instance; }
    }
}
