﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour {

    public float movementSpeed;
    public float _movementSpeed;
    public int currentTile = 0;
    public GameObject[] tiles;
    public EssenceContainer essenceContainer;
    

    private void Start()
    {
        tiles = GameObject.Find("Grid").GetComponent<TileContainer>().enemyTiles;
        essenceContainer = GameObject.Find("EssenceText").GetComponent<EssenceContainer>();
    }

    // Update is called once per frame
    void Update() {
        if (this.gameObject.GetComponent<EnemyStats>().health <= 0)
        {
            essenceContainer.essence += this.gameObject.GetComponent<EnemyStats>().essence;
            Destroy(this.gameObject);
        }

        movementSpeed -= Time.deltaTime;

        if (movementSpeed < 0f)
        {
            if (this.transform.parent == tiles[tiles.Length-1].transform)
            {
                Destroy(this.gameObject);
            }
            else
            {
                this.transform.parent = tiles[currentTile].transform;
                this.transform.localPosition = new Vector2(0f, 0f);
            }

            currentTile += 1;
            movementSpeed = _movementSpeed;
        }
	}
}
