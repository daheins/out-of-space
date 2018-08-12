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
	     void OnMouseDown() {
        CanvasHUD.GetComponent<HUDScript>().ShowStatsForFactory(this);
        }

    public bool CanLevelUp() {
        if (factoryLevel >= maxLevel) {
            return false;
        }
        return CostToLevelUp() <= EconomyObject.GetComponent<EconomyController>().CurrencyBalance();
    }
	
    public void SetUpParams(FactoryInfo info) {
        factoryLevel = 0;
        maxLevel = 10;

        levelToIncomeMap = new Dictionary<int, float>();
        levelToLevelUpCostMap = new Dictionary<int, float>();

        for (var i = 0; i < maxLevel; i++){
            levelToLevelUpCostMap[i] = info.initialCost * (float)Math.Pow(info.coefficient, i);
            levelToIncomeMap[i] = info.initialIncome * i * info.initialProductivity;
        }
    }

    public float Income () {
        return levelToIncomeMap[factoryLevel];
    }

    public float CostToLevelUp () {
        return levelToLevelUpCostMap[factoryLevel];
    }

    public void LevelUpFactory () {
        EconomyObject.GetComponent<EconomyController>().SpendCurrency(levelToLevelUpCostMap[factoryLevel]);
        factoryLevel += 1;
        levelReadout.text = factoryLevel.ToString();
    }
}
