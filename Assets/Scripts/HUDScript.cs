using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

    public GameObject factoryUIPanel;
    public GameObject levelUpButton;
    public Text incomeText;
    public Text levelUpText;

    private FactoryController selectedFactory;

	private void Start() {
        factoryUIPanel.SetActive(false);
	}

	private void Update() {
        CheckCanLevelUp();
	}

	void CheckCanLevelUp() {
        if (selectedFactory) {
            levelUpButton.GetComponent<Button>().interactable = selectedFactory.CanLevelUp();
        }
    }

    public void ShowStatsForFactory(FactoryController factory) {
        factoryUIPanel.SetActive(true);

        float income = factory.Income();
        float levelUpCost = factory.CostToLevelUp();

        incomeText.text = "Income: " + Mathf.Round(income).ToString();
        levelUpText.text = "Cost to Level: " + levelUpCost.ToString();

        selectedFactory = factory;

        CheckCanLevelUp();
    }

    public void DidTapLevelUp() {
        selectedFactory.LevelUpFactory();
        ShowStatsForFactory(selectedFactory);
    }
}
