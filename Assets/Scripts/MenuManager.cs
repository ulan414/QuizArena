using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class MenuManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public GameObject CreateButton;
    public GameObject JoinButton;

    public TMP_InputField Question;
    public TMP_InputField Answer1;
    public TMP_InputField Answer2;
    public TMP_InputField Answer3;
    public TMP_InputField Answer4;
    public GameObject DoneButton;


    public List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();
    public QuestionsSaver questionsSaver;
    public GameObject AddQuestionObject;

    public void CreateRoom()
    {
        questionsSaver.SaveQuestion(QnAList);
        RoomOptions roomOptions = new RoomOptions();
        PlayerPrefs.SetInt("creater", 1);
        PlayerPrefs.Save();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
        PlayerPrefs.SetInt("creater", 0);
        PlayerPrefs.Save();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Playground");
    }

    public void OpenQuestionbuilder(){
        //clear scene
        createInput.gameObject.SetActive(false);
        joinInput.gameObject.SetActive(false);
        CreateButton.SetActive(false);
        JoinButton.SetActive(false);
        AddQuestionObject.SetActive(true);
        DoneButton.SetActive(false);
    }
    public void AddQuestion(){
        string questionText = Question.text.Trim();

        if (string.IsNullOrEmpty(questionText))
        {
            Debug.Log("Question is empty. Please enter a question.");
            return;
        }
        string[] answers = new string[]
        {
            Answer1.text,
            Answer2.text,
            Answer3.text,
            Answer4.text
        };
        int correctAnswer = 1;
        QuestionsAndAnswers newQuestion = new QuestionsAndAnswers
        {
            question = questionText,
            Answers = answers,
            CorrectAnswer = correctAnswer
        };
        QnAList.Add(newQuestion);

        // Clear input fields after saving
        Question.text = "";
        Answer1.text = "";
        Answer2.text = "";
        Answer3.text = "";
        Answer4.text = "";

        Debug.Log("Question added successfully.");
        DoneButton.SetActive(true);
    }
}
