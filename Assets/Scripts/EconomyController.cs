using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System;

public class EconomyController : MonoBehaviour {
    private float currencyBalance;
    private float income;
    public Text currencyBalanceText;
    public Text incomeText;

    public GameObject factory1;
    public GameObject factory2;
    public GameObject factoryParent;

    public List<List<string>> parameters;

    public float startingIncome;
    public float simulationSpeed; // test setting for global simulation speed



	// Use this for initialization
	void Start () {
        currencyBalance = 0;
        income = startingIncome;
        currencyBalanceText.text = "Currency: " + currencyBalance.ToString();
        incomeText.text = "Income: " + income.ToString();
        Load("params.csv");
        SetupParams();
	}
	
	// Update is called once per frame
	void Update () {
        CalculateIncome();
        float increment = income * Time.deltaTime * simulationSpeed;
        currencyBalance = currencyBalance + increment;
        currencyBalanceText.text = "Currency: " + Mathf.Round(currencyBalance).ToString();
        incomeText.text = "Income: " + Mathf.Round(income).ToString();
	}

    void CalculateIncome() {

        float i1 = factory1.GetComponent<FactoryController>().Income();
        float i2 = factory2.GetComponent<FactoryController>().Income();
        income = startingIncome + i1 + i2;    
    }

    public bool SpendCurrency(float amount) {
        if (amount > currencyBalance) {
            return false; //you fail to spend
        }
        currencyBalance = currencyBalance - amount;
        return true;
    }


    public float CurrencyBalance()
    {
        return currencyBalance;
    }

    void SetupParams() {
        int index = 0;
        foreach (List<string> entry in parameters){
            FactoryController f = factoryParent.GetComponentsInChildren<FactoryController>()[index];



            f.SetUpParams(float.Parse(entry[0]),
                          float.Parse(entry[1]),
                          float.Parse(entry[2]),
                          float.Parse(entry[3]));

            index++;
        }

        
    }



    private bool Load(string fileName)
    {
        // Handle any problems that might arise when reading the text

        List<List<string>> tempList = new List<List<string>>();
        string line;
        // Create a new StreamReader, tell it which file to read and what encoding the file
        // was saved as
        StreamReader theReader = new StreamReader(fileName, Encoding.Default);
        // Immediately clean up the reader after this block of code is done.
        // You generally use the "using" statement for potentially memory-intensive objects
        // instead of relying on garbage collection.
        // (Do not confuse this with the using directive for namespace at the 
        // beginning of a class!)

        using (theReader)
        {
            // While there's lines left in the text file, do this:
            do
            {
                line = theReader.ReadLine();

                if (line != null)
                {
                    // Do whatever you need to do with the text line, it's a string now
                    // In this example, I split it into arguments based on comma
                    // deliniators, then send that array to DoStuff()
                    List<string> entries = new List<string>(line.Split(','));
                    if (entries.Count > 0)
                        tempList.Add(entries.GetRange(1,entries.Count-1));

                }
            }
            while (line != null);
            // Done reading, close the reader and return true to broadcast success    
            theReader.Close();
            parameters = tempList;
            return true;
        }

       
    }
}

