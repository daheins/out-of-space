using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class FactoryManager : MonoBehaviour {

    public GameObject factoryPrefab;
    public GameObject CanvasHUD;
    public GameObject EconomyObject;

    private List<GameObject> factoryList;

    const float GoldenRatio = 1.61803398874989484820458683436F;

    void Start () {
        List<FactoryInfo> factories = LoadFactoryData();
        int factoryIndex = 0;
        List<GameObject> factoryObjects = new List<GameObject>();
        foreach (FactoryInfo info in factories) {
            factoryObjects.Add(CreateFactory(info, factoryIndex));
            factoryIndex++;
        }
        factoryList = factoryObjects;
	}

    public List<GameObject> allFactories() {
        return factoryList;
    }

    GameObject CreateFactory(FactoryInfo factoryInfo, int index) {
        GameObject fObject = Instantiate(factoryPrefab);
        fObject.transform.SetParent(this.transform);
        fObject.transform.position += new Vector3(index * 2, 0, 0);
        float scale = (float)Math.Pow(1 / GoldenRatio, index);
        fObject.transform.localScale = new Vector3(scale,
                                                   scale,
                                                   scale);
        FactoryController factory = fObject.GetComponent<FactoryController>();
        factory.CanvasHUD = CanvasHUD;
        factory.EconomyObject = EconomyObject;
        factory.SetUpParams(factoryInfo);
        return fObject;
    }
	
    List<FactoryInfo> LoadFactoryData() {
        List<FactoryInfo> factoryInfoList = new List<FactoryInfo>();
        StreamReader theReader = new StreamReader("Factory.csv", Encoding.Default);
        string line;
        do
        {
            line = theReader.ReadLine();

            if (line != null)
            {
                List<string> entries = new List<string>(line.Split(','));
                FactoryInfo info = new FactoryInfo();
                info.name = entries[0];
                info.initialCost = float.Parse(entries[1]);
                info.coefficient = float.Parse(entries[2]);
                info.initialIncome = float.Parse(entries[3]);
                info.initialProductivity = float.Parse(entries[4]);
                factoryInfoList.Add(info);
            }
        } while (line != null);

        theReader.Close();
        return factoryInfoList;
    }
}

public class FactoryInfo : object {
    public String name;
    public float initialCost;
    public float coefficient;
    public float initialIncome;
    public float initialProductivity;
}
