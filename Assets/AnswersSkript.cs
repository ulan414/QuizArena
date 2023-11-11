
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersSkript : MonoBehaviour

{
public bool isCorrect = false;
public QuizManager quizManager;

public void Answer(){
    if(isCorrect){
        Debug.Log("Correct");
        quizManager.Correct();
    }else{
        Debug.Log("wrong");
        quizManager.Correct();
    }
}
}