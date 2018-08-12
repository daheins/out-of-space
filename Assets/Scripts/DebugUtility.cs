using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUtility : MonoBehaviour {

    private int ZoomLevel = 0;

    public GameObject factoryParent;

    public void DidTapZoomIn () {
        ZoomLevel++;
        float scaleFactor = 1.4F;
        factoryParent.transform.localScale = new Vector3(factoryParent.transform.localScale.x * scaleFactor,
                                                         factoryParent.transform.localScale.y * scaleFactor,
                                                         factoryParent.transform.localScale.z * scaleFactor);
	}

    public void DidTapZoomOut() {
        ZoomLevel--;
        float scaleFactor = .7F;
        factoryParent.transform.localScale = new Vector3(factoryParent.transform.localScale.x * scaleFactor,
                                                         factoryParent.transform.localScale.y * scaleFactor,
                                                         factoryParent.transform.localScale.z * scaleFactor);
    }
}
