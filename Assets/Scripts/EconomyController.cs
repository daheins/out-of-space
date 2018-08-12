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

    public GameObject factoryParent;

    public float startingIncome;
    public float simulationSpeed; // test setting for global simulation speed

	// Use this for initialization
	void Start () {
        currencyBalance = 0;
        income = startingIncome;
        currencyBalanceText.text = "Currency: " + currencyBalance.ToString();
        incomeText.text = "Income: " + income.ToString();
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
        float totalIncome = startingIncome;
        FactoryManager factoryManager = factoryParent.GetComponent<FactoryManager>();
        foreach (GameObject factoryObject in factoryManager.allFactories()) {
            totalIncome += factoryObject.GetComponent<FactoryController>().Income();
        }
        income = totalIncome;
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
}

