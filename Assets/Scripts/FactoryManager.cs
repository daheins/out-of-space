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

    // View Stuff
    const float GoldenRatio = 1.61803398874989484820458683436F;
    const float DefaultFactorySize = 1000 / 100;
    const float StarterScale = .7F;

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

        // Model
        FactoryController factory = fObject.GetComponent<FactoryController>();
        factory.CanvasHUD = CanvasHUD;
        factory.EconomyObject = EconomyObject;
        factory.SetUpParams(factoryInfo);

        // View
        float invRatio = 1 / GoldenRatio;
        fObject.transform.SetParent(this.transform, false);

        float prevScale = StarterScale;
        Debug.Log(string.Format("making factory {0}", index));
        Debug.Log(string.Format("starting location {0}", fObject.transform.position));

        for (int loop = 0; loop < index; loop++) {
            float newScale = prevScale * invRatio;
            Vector3 vectorAdd = new Vector3(0, 0, 0);
            switch (loop % 4) {
                case 0:
                    vectorAdd = new Vector3(DefaultFactorySize * (prevScale / 2 + newScale / 2),
                                            DefaultFactorySize * (prevScale / 2 - newScale / 2), 0);
                    break;
                case 1:
                    vectorAdd = new Vector3(DefaultFactorySize * (prevScale / 2 - newScale / 2),
                                            -DefaultFactorySize * (prevScale / 2 + newScale / 2), 0);
                    break;
                case 2:
                    vectorAdd = new Vector3(-DefaultFactorySize * (prevScale / 2 + newScale / 2),
                                            -DefaultFactorySize * (prevScale / 2 - newScale / 2), 0);
                    break;
                case 3:
                    vectorAdd = new Vector3(-DefaultFactorySize * (prevScale / 2 - newScale / 2),
                                            DefaultFactorySize * (prevScale / 2 + newScale / 2), 0);
                    break;
            }
            Debug.Log(vectorAdd);
            fObject.transform.position += vectorAdd;
            prevScale = newScale;
        }
        fObject.transform.localScale = new Vector3(prevScale,
                                                   prevScale,
                                                   prevScale);
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
