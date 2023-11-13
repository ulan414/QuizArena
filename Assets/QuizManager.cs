using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using StarterAssets;
public class QuizManager : MonoBehaviour
{
    private List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion = -1;

    public TextMeshProUGUI Question;
    public TextMeshProUGUI Answer1;
    public TextMeshProUGUI Answer2;
    public TextMeshProUGUI Answer3;
    public TextMeshProUGUI Answer4;

    int correctVar = 0;

    public float correctInterval = 10.0f;
    public float generateFloorInterval = 3.0f;
    private float correctTimeLeft;
    private float generateFloorTimeLeft;

    public TextMeshProUGUI timerText;
    bool changer = true;
    public Color normalColor = Color.white;
    public Color warningColor = Color.red;

    public bool startTheGame = false;
    bool start = false;
    bool endOfQuiz = false;
    public GameObject StarterButton;

    public TextMeshProUGUI Current;
    void Start()
    {
        QnA = QuestionsSaver.Instance.QnAList;
        correctTimeLeft = correctInterval;
        generateFloorTimeLeft = generateFloorInterval;
        Debug.Log(PlayerPrefs.GetInt("creater"));
    }
    public void StartGame(){
        startTheGame = true;
        Correct();
        StarterButton.SetActive(false);
        Current.text = "1/" + QnA.Count;
    }
void Update()
    {
        if (currentQuestion < QnA.Count && startTheGame)
        {
            // Update timeLeft for Correct method
            if(changer){
                correctTimeLeft -= Time.deltaTime;
            }
            if (correctTimeLeft <= 0 && changer)
            {
                Correct();
                correctTimeLeft = correctInterval;
                changer = false;
            }

            // Update timeLeft for GenerateFloor method
            if(!changer){
                generateFloorTimeLeft -= Time.deltaTime;
            }
            if (generateFloorTimeLeft <= 0)
            {
                GenerateFloor();
                generateFloorTimeLeft = generateFloorInterval;
                changer = true;
            }
            if(correctTimeLeft <= 3f){
                timerText.color = warningColor;
            }else{
                timerText.color = normalColor;
            }
        }
        if(currentQuestion > QnA.Count - 1 && !endOfQuiz){
            //end
            generateFloorTimeLeft -= Time.deltaTime;
            if(generateFloorTimeLeft <= 0f){
                End();//show results
                endOfQuiz = true;
            }
        }
        if (startTheGame && !endOfQuiz){
            ShowTimer();
        }
    }

    public void Correct(){
        currentQuestion += 1;
        if(start){
            DestroyFloor(correctVar);
        }
        if(currentQuestion < QnA.Count)
            generateQuestion();
        start = true;
    }

    void SetAnswers(){
        Current.text = (currentQuestion + 1) + "/" + QnA.Count;
        for(int i = 0; i < options.Length; i++){
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

            Debug.Log(QnA[currentQuestion].CorrectAnswer);
            if(QnA[currentQuestion].CorrectAnswer == i+1){
                correctVar = i+1;
                Debug.Log(correctVar);
            }
        }
    }

    void generateQuestion(){
        Question.text = QnA[currentQuestion].question;
        Debug.Log("current:" + currentQuestion);
        Debug.Log("size:" + QnA.Count);
        SetAnswers();
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
    void ShowTimer(){
        if(changer)
            timerText.text = correctTimeLeft.ToString("F2");
        else
            timerText.text = generateFloorTimeLeft.ToString("F2");
    }
    void End(){
        GenerateFloor();
        //clear wall
        Question.text = "";
        Answer1.text = "";
        Answer2.text = "";
        Answer3.text = "";
        Answer4.text = "";
        timerText.text = "";
        //show points
        GameObject playerArmature = GameObject.Find("PlayerArmature Variant(Clone)");
        if (playerArmature != null)
        {
            ThirdPersonController thirdPersonController = playerArmature.GetComponent<ThirdPersonController>();
            thirdPersonController.WinnerInterface();
        }
    }
}