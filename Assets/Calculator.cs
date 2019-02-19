using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour {

    public Text display;
    public Text processDisplay;

    float number0;
    float number1;
    float result;

    int pointcheck = 0;
    int numbercheck = 0;
    int calcheck = 0;

    bool percent = false;

    public AudioSource Audio;

    // Use this for initialization
    void Start () {
        Audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    string last_tapped = "";
    void UpdateProcessDisplay(string last)
    {
        this.last_tapped = last;

        string op = "";

        switch (calcheck)
        {
            case 1:
                op = "+";
                break;
            case 2:
                op = "-";
                break;
            case 3:
                op = "×";
                break;
            case 4:
                op = "÷";
                break;
        }

        //string eq = "";

        //if (eqcheck == 1)
        //    eq = "";
        //else if (eqcheck == 2)
            //eq = "%";

        string num1 = "";
        if (number1 != 0)
            num1 = number1.ToString();
        string num0 = "";
        if (number0 != 0)
            num0 = number0.ToString();

        string line = num1 + op + num0;
        processDisplay.text = line;
    }

    public void NumberClick (int number)
    {
        if (last_tapped == "=" || last_tapped == "%")
        {
            number1 = 0;
        }

        if (numbercheck == 0)
        {
            if (display.text == "0")
            {
                display.text = number.ToString();
                number0 = Single.Parse(display.text);
                Debug.Log(number0);
            }
            else
            {
                display.text += number.ToString();
                number0 = Single.Parse(display.text);
                Debug.Log(number0);
            }
        }

        if (numbercheck == 1)
        {
            display.text = number.ToString();
            number0 = Single.Parse(display.text);
            Debug.Log(number0);
            numbercheck = 0;
        }

        UpdateProcessDisplay(number.ToString());

        //if (processDisplay.text == "0")
        //    processDisplay.text = string.Empty;
        //processDisplay.text += number;
    }

    public void PointClick ()
    {
        pointcheck += 1;
        if (numbercheck == 0)
        {
            if (pointcheck == 1)
            {
                display.text += ".";
                number0 = Single.Parse(display.text);
                Debug.Log(number0);

                //processDisplay.text += display.text;
            }
        }

        if (numbercheck == 1)
        {
            display.text = "0.";
            number0 = Single.Parse(display.text);
            Debug.Log(number0);

            //processDisplay.text += display.text;
            numbercheck = 0;
        }

        UpdateProcessDisplay(".");
    }

    public void PlusMinusClick()
    {
        if (numbercheck == 0)
        {
            number0 = -number0;
            display.text = number0.ToString();
            Debug.Log(number0);

            //processDisplay.text += number0;
        }
        if (numbercheck == 1)
        {
            number1 = -number1;
            display.text = number1.ToString();
            Debug.Log(number1);

            //processDisplay.text += number1;
        }

        UpdateProcessDisplay("±");
    }

    private void CheckAddOperator(string neop)
    {
        //if (reset && neop != "=" && neop != "%" )
        //{
        //    processDisplay.text = "";
        //    reset = false;
        //}

        //string current = processDisplay.text;

        //string last = current.Substring(current.Length - 1, 1);
        //if (last.Equals("+") || last.Equals("-") || last.Equals("×") || last.Equals("÷") || last.Equals("%"))
        //{
        //    processDisplay.text = current.Substring(0, current.Length - 1) + neop;
        //}
        //else
            //processDisplay.text += neop;
    }

    public void AddClick ()
    {
        Calculate();
        calcheck = 1;
        Debug.Log("+");

        UpdateProcessDisplay("+");
        //CheckAddOperator("+");
    }

    public void SubstractClick()
    {
        Calculate();
        calcheck = 2;
        Debug.Log("-");

        UpdateProcessDisplay("-");
        //CheckAddOperator("-");
    }

    public void MultiplyClick()
    {
        Calculate();
        calcheck = 3;
        Debug.Log("×");

        UpdateProcessDisplay("×");
        //CheckAddOperator("×");
    }

    public void DivideClick()
    {
        Calculate();
        calcheck = 4;
        Debug.Log("÷");

        UpdateProcessDisplay("÷");
        //CheckAddOperator("÷");
    }

    public void PercentClick()
    {
        percent = true;
        Calculate();
        calcheck = 0;
        Debug.Log("%");

        last_tapped = "%";
        processDisplay.text += "%";

        //UpdateProcessDisplay("%");
        //CheckAddOperator("%");
    }

    public void EqualClick()
    {
        Calculate();
        calcheck = 0;
        percent = false;
        Debug.Log("=");

        last_tapped = "=";
        //UpdateProcessDisplay();
        //CheckAddOperator("=");

    }

    public void AllClearClick()
    {
        display.text = "0";
        //processDisplay.text = "";
        number0 = 0;
        number1 = 0;
        numbercheck = 0;
        pointcheck = 0;
        calcheck = 0;
        percent = false;

        UpdateProcessDisplay("a");
        Debug.Log("AC");
    }

    public void ClearClick()
    {
        display.text = "0";
        //processDisplay.text = "";
        number0 = 0;

        UpdateProcessDisplay("c");
        Debug.Log("C");
    }

    void Calculate()
    {
        if (numbercheck == 0)
        {
            numbercheck = 1;

            if (calcheck == 0)
            {
                number1 = number0;
                number0 = 0;
            }

            else
            {
                if (percent)
                {
                    number0 = number1 / 100 * number0;
                }

                if (calcheck == 1)
                {
                    number1 = number1 + number0;
                }

                if (calcheck == 2)
                {
                    number1 = number1 - number0;
                }

                if (calcheck == 3)
                {
                    number1 = number1 * number0;
                }

                if (calcheck == 4)
                {
                    number1 = number1 / number0;
                }

                display.text = number1.ToString();
                number0 = 0;
                pointcheck = 0;
                percent = false;
            }
        }
    }
}
