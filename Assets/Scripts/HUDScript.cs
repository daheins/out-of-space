using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

    public GameObject factoryUIPanel;
    public Text incomeText;
    public Text levelUpText;

    private FactoryController selectedFactory;

	private void Start() {
        factoryUIPanel.SetActive(false);
	}

    public void ShowStatsForFactory(FactoryController factory) {
        factoryUIPanel.SetActive(true);

        int income = factory.Income();
        int levelUpCost = factory.CostToLevelUp();

        incomeText.text = "Income: " + Mathf.Round(income).ToString();
        levelUpText.text = "Cost to Level: " + levelUpCost.ToString();

        selectedFactory = factory;
    }

    public void DidTapLevelUpButton() {
        selectedFactory.LevelUpFactory();
        ShowStatsForFactory(selectedFactory);
    }
}
