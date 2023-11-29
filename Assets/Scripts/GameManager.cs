using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ���� ���÷���
    public TMP_Text displayText;

    // �����ڸ� ���� ����
    private List<string> operators = new List<string>();

    // �ǿ����ڸ� ���� ����
    private List<string> operands = new List<string>();

    // �����ڸ� �Է����� �� �ش� �����ڿ� ���� �ǿ����� ������ ���� ����
    private string lastOperand;
    private string lastOperator;

    // ��ư Ŭ�� �̺�Ʈ
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
