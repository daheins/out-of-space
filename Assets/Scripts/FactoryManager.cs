using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FactoryManager : MonoBehaviour {

    public GameObject factoryPrefab;
    public GameObject CanvasHUD;
    public GameObject EconomyObject;

    const float GoldenRatio = 1.61803398874989484820458683436F;

    void Start () {
        for (int i = 0; i < 10; i++) {
            CreateFactory(i);
        }
	}

    void CreateFactory(int factoryIndex) {
        GameObject fObject = Instantiate(factoryPrefab);
        fObject.transform.SetParent(this.transform);
        fObject.transform.position += new Vector3(factoryIndex * 2, 0, 0);
        float scale = (float)Math.Pow(1 / GoldenRatio, factoryIndex);
        fObject.transform.localScale = new Vector3(scale,
                                                   scale,
                                                   scale);
        FactoryController factory = fObject.GetComponent<FactoryController>();
        factory.CanvasHUD = CanvasHUD;
        factory.EconomyObject = EconomyObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
