using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addTower : MonoBehaviour {

    public GameObject selectionCanvas;
    public bool thisTile = false;

    private void Start()
    {
        selectionCanvas = Resources.FindObjectsOfTypeAll<TowerSelectionCanvasIdentifier>()[0].gameObject;
    }

    private void OnMouseDown()
    {
        if (selectionCanvas.activeInHierarchy == false)
        {
            thisTile = true;
            selectionCanvas.SetActive(true);
        }
    }
}
