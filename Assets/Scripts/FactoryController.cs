using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryController : MonoBehaviour {

    public TextMesh levelReadout;

    private int factoryLevel;
    private Dictionary<int, int> levelToIncomeMap;

	// Use this for initialization
	void Start () {
        factoryLevel = 0;
        levelToIncomeMap = new Dictionary<int, int> ();
	}
	     void OnMouseDown() {         LevelUpFactory();     }

    public int Income () {
        return factoryLevel;
    }

    public void LevelUpFactory () {
        factoryLevel += 1;
        levelReadout.text = factoryLevel.ToString();
    }
}
