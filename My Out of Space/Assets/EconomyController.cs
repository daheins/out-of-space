using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EconomyController : MonoBehaviour {
    public long currencyBalance;
    public long income;
    public Text currencyBalanceText;
    public Text incomeText;

	// Use this for initialization
	void Start () {
        currencyBalance = 0;
        income = 1;
        currencyBalanceText.text = "Currency: " + currencyBalance.ToString();
        incomeText.text = "Income: " + income.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        currencyBalance = currencyBalance + income;
        currencyBalanceText.text = "Currency: " + currencyBalance.ToString();
        incomeText.text = "Income: " + income.ToString();
	}
}
