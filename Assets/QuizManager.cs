using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionText;

    private void Start(){
    //generateQuestion();
    }

    void generateQuestion(){
        currentQuestion = Random.Range(0, QnA.Count);
        QuestionText.text = QnA[currentQuestion].question;
    }
    void SetAnswers(){
        for(int i = 0; i<options.Length; i++){
            options[i].GetComponent<AnswersSkript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1){
            options[i].GetComponent<AnswersSkript>().isCorrect = true;
            }
        }
    }
}
