using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public TileContainer tiles;
    public float delay;
    public float _delay;
    public GameObject basicEnemyPrefab;
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;

        if (delay < 0f)
        {
            Instantiate(basicEnemyPrefab, tiles.enemyTiles[0].transform);
            delay = _delay;
        }
	}
}
