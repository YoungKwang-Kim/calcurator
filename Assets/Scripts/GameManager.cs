using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ���� ���÷���
    public TMP_Text displayText;

    // �����ڸ� ���� ����(��ȣ)
    private List<string> operators = new List<string>();

    // �ǿ����ڸ� ���� ����(����)
    private List<string> operands = new List<string>();

    // �����ڸ� �Է����� �� �ش� �����ڿ� ���� �ǿ����� ������ ���� ����
    private string lastOperand; // ������ �ǿ�����
    private string lastOperator; // ������ ������

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
                // ������ Ŭ���� �ǿ����ڿ� �����ڸ� �ǿ����� ����Ʈ�� ������ ����Ʈ�� ����
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
                operands.Clear();
                operators.Clear();
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
                    int divideIndex = operators.IndexOf("/");
                    int plusIndex = operators.IndexOf("+");
                    int minuseIndex = operators.IndexOf("-");

                    if (multiplyIndex >= 0)
                    {
                        DoCalcurate(multiplyIndex, OPR.MULTIPLY);
                    }
                    else if (divideIndex >= 0)
                    {
                        DoCalcurate(divideIndex, OPR.DIVIDE);
                    }
                    else if (plusIndex >= 0)
                    {
                        DoCalcurate(plusIndex, OPR.PLUS);
                    }
                    else if (minuseIndex >= 0)
                    {
                        DoCalcurate(minuseIndex, OPR.MINUS);
                    }
                }
                displayText.text = operands[0];
                operands.Clear();
                break;
        }
    }

    enum OPR { PLUS, MINUS, MULTIPLY, DIVIDE }

    private void DoCalcurate(int index, OPR opr)
    {
        float leftOperand = float.Parse(operands[index]);
        float rightOperand = float.Parse(operands[index + 1]);

        float result;

        switch (opr)
        {
            case OPR.PLUS:
                result = leftOperand + rightOperand;
                Debug.Log($"{leftOperand} + {rightOperand} : {result}");
                break;
            case OPR.MINUS:
                 result = leftOperand - rightOperand;
                Debug.Log($"{leftOperand} - {rightOperand} : {result}");
                break;
            case OPR.MULTIPLY:
                result = leftOperand * rightOperand;
                Debug.Log($"{leftOperand} * {rightOperand} : {result}");
                break;
            case OPR.DIVIDE:
                result = leftOperand / rightOperand;
                Debug.Log($"{leftOperand} / {rightOperand} : {result}");
                break;
            default:
                result = 0;
                break;
        }

        operands[index] = result.ToString();
        operands.RemoveAt(index + 1);
        operators.RemoveAt(index);
    }
}
