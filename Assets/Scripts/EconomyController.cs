using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyController : MonoBehaviour {
    private float currencyBalance;
    private float income;
    public Text currencyBalanceText;
    public Text incomeText;

    public GameObject factory1;
    public GameObject factory2;

    public float simulationSpeed; // test setting for global simulation speed

	// Use this for initialization
	void Start () {
        currencyBalance = 0;
        income = 1;
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
        int i1 = factory1.GetComponent<FactoryController>().Income();
        int i2 = factory2.GetComponent<FactoryController>().Income();
        income = i1 + i2;
                
    }

    public bool SpendCurrency(float amount) {
        if (amount > currencyBalance) {
            return false; //you fail to spend
        }
        currencyBalance = currencyBalance - amount;
        return true;
    }
}
