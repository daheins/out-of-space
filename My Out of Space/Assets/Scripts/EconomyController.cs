using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyController : MonoBehaviour {
    public float currencyBalance;
    public float income;
    public Text currencyBalanceText;
    public Text incomeText;

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
        float increment = income * Time.deltaTime * simulationSpeed;
        currencyBalance = currencyBalance + increment;
        currencyBalanceText.text = "Currency: " + Mathf.Round(currencyBalance).ToString();
        incomeText.text = "Income: " + Mathf.Round(income).ToString();
	}
}
