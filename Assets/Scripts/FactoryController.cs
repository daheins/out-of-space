using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryController : MonoBehaviour {

    private int factoryLevel;
    private Dictionary<int, int> levelToIncomeMap;

	// Use this for initialization
	void Start () {
        factoryLevel = 0;
        levelToIncomeMap = new Dictionary<int, int> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int Income () {
        return 1;
        return levelToIncomeMap[factoryLevel];
    }

    public void LevelUpFactory () {
        factoryLevel += 1;
    }
}
