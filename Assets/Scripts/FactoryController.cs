using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FactoryController : MonoBehaviour {

    public TextMesh levelReadout;
    public GameObject CanvasHUD;
    public GameObject EconomyObject;

    private int maxLevel;
    private int factoryLevel;
    private Dictionary<int, float> levelToIncomeMap;
    private Dictionary<int, float> levelToLevelUpCostMap;

	// Use this for initialization
	void Start () {
        factoryLevel = 0;
        maxLevel = 10;

	}
	     void OnMouseDown() {
        CanvasHUD.GetComponent<HUDScript>().ShowStatsForFactory(this);
        }

    public bool CanLevelUp() {
        return CostToLevelUp() <= EconomyObject.GetComponent<EconomyController>().CurrencyBalance();
    }
	
    public void SetUpParams(float initialCost,
                            float coefficient,
                            float initialIncome, 
                            float initialProductivity) {

        levelToIncomeMap = new Dictionary<int, float>();
        levelToLevelUpCostMap = new Dictionary<int, float>();

        for (var i = 0; i <= maxLevel; i++){
            levelToIncomeMap[i] = initialIncome * i * initialProductivity;
            levelToLevelUpCostMap[i] = initialCost * (float)Math.Pow(coefficient, i);
        }
        Debug.Log(levelToIncomeMap[0]);
    }
 

    public float Income () {
        return levelToIncomeMap[factoryLevel];
    }

    public int CostToLevelUp () {
        return 1;
        //return levelToIncomeMap[factoryLevel];
    }

    public void LevelUpFactory () {
        factoryLevel += 1;
        levelReadout.text = factoryLevel.ToString();
    }
}
