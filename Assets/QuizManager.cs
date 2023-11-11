using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI Question;
    public TextMeshProUGUI Answer1;
    public TextMeshProUGUI Answer2;
    public TextMeshProUGUI Answer3;
    public TextMeshProUGUI Answer4;


    void Start(){
        if(QnA.Count > 0){
    InvokeRepeating("Correct", 0.0f, 10.0f);
        }
    }

    public void Correct(){
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers(){
        for(int i = 0; i<options.Length; i++){
            options[i].GetComponent<AnswersSkript>().isCorrect = false;
            //options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            if(i==0){
                Answer1.text = "A)" + QnA[currentQuestion].Answers[i];
            }
            if(i==1){
                Answer2.text = "B)" + QnA[currentQuestion].Answers[i];
            }
            if(i==2){
                Answer3.text = "C)" + QnA[currentQuestion].Answers[i];
            }
            if(i==3){
                Answer4.text = "D)" + QnA[currentQuestion].Answers[i];
            }

            if(QnA[currentQuestion].CorrectAnswer == i+1){
            options[i].GetComponent<AnswersSkript>().isCorrect = true;
            }
        }
    }

    void generateQuestion(){
        if(QnA.Count > 0){
        currentQuestion = Random.Range(0, QnA.Count);

        Question.text = QnA[currentQuestion].question;
        SetAnswers();
        }else{
            Debug.Log("Quiz ended");
        }

    }
    
}