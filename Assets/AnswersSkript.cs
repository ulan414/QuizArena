using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersSkript : MonoBehaviour

{
public bool isCorrect = false;

public void Answer(){
    if(isCorrect){
        Debug.Log("Correct");
    }else{
        Debug.Log("wrong");
    }
}
}
