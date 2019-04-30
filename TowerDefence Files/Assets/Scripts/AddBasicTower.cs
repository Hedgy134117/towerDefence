using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBasicTower : MonoBehaviour {

    public GameObject towerSelection;
    public GameObject[] towerTiles;
    public GameObject basicTowerPrefab;
    private GameObject basicTower;

	// Use this for initialization
	void Start () {
        towerTiles = GameObject.FindGameObjectsWithTag("towerTile");
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            AddTower();
        }
    }

    // Update is called once per frame
    public void AddTower () {
        foreach (var tile in towerTiles)
        {
            if (tile.GetComponent<addTower>().thisTile == true)
            {
                basicTower = Instantiate(basicTowerPrefab);
                basicTower.transform.position = tile.transform.position;
                basicTower.transform.parent = tile.transform;
                towerSelection.SetActive(false);
                tile.GetComponent<addTower>().thisTile = false;
            }
        }
	}
}
