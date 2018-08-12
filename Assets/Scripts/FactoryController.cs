using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryController : MonoBehaviour {

    public TextMesh levelReadout;
    public GameObject CanvasHUD;
    public GameObject EconomyObject;

    private int factoryLevel;
    private Dictionary<int, int> levelToIncomeMap;

	// Use this for initialization
	void Start () {
        factoryLevel = 0;
        levelToIncomeMap = new Dictionary<int, int> ();
	}
	     void OnMouseDown() {
        CanvasHUD.GetComponent<HUDScript>().ShowStatsForFactory(this);     }

    public bool CanLevelUp() {
        return CostToLevelUp() <= EconomyObject.GetComponent<EconomyController>().CurrencyBalance();
    }

    public int Income () {
        return factoryLevel;
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
