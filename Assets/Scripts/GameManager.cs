using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 계산기 디스플레이
    public TMP_Text displayText;

    // 연산자를 담을 변수
    private List<string> operators = new List<string>();

    // 피연산자를 담을 변수
    private List<string> operands = new List<string>();

    // 연산자를 입력했을 때 해당 연산자와 이전 피연산자 저장을 위한 변수
    private string lastOperand;
    private string lastOperator;

    // 버튼 클릭 이벤트
    public void OnClickButton(string buttonStr)
    {
        switch(buttonStr)
        {
            case "0":
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
                if (lastOperator != null && lastOperand != null)
                {
                    operands.Add(lastOperand);
                    operators.Add(lastOperator);

                    lastOperator = null;
                    lastOperand = null;

                    displayText.text = "0";
                }

                if (displayText.text == "0")
                {
                    displayText.text = buttonStr;
                }
                else
                {
                    displayText.text += buttonStr;
                }

                break;

            case ".":
                displayText.text += buttonStr;
                break;
            case "c":
                displayText.text = "0";
                break;

            case "+":
            case "-":
            case "*":
            case "/":
                lastOperand = displayText.text;
                lastOperator = buttonStr;
                break;
            case "=":
                operands.Add(displayText.text);

                while (operators.Count > 0)
                {
                    int multiplyIndex = operators.IndexOf("*");
                    int divideIndex = operands.IndexOf("/");
                    Debug.Log(multiplyIndex);
                    Debug.Log(divideIndex);
                }

                break;
        }
    }
}
