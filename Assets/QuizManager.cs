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

    int correctVar = 0;
    bool start = true;
    float timeElapsed = 0f;
    void Start(){
        if(QnA.Count > 0){
            InvokeRepeating("Correct", 10.0f, 10.0f);
            InvokeRepeating("GenerateFloor", 13.0f, 10.0f);
        }
    }
    void Update(){
    }
    public void Correct(){
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        DestroyFloor(correctVar);
        start = false;
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
            correctVar = i+1;
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
    public void DestroyFloor(int correctFloor){
        if(correctFloor != 1){
            options[0].SetActive(false);
        }
        if(correctFloor != 2){
            options[1].SetActive(false);
        }
        if(correctFloor != 3){
            options[2].SetActive(false);
        }
        if(correctFloor != 4){
            options[3].SetActive(false);
        }
    }
        public void GenerateFloor(){
            options[0].SetActive(true);
            options[1].SetActive(true);
            options[2].SetActive(true);
            options[3].SetActive(true);
    }
    
}