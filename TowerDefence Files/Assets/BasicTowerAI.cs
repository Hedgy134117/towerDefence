using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTowerAI : MonoBehaviour {

    public Rect area;
    public TileContainer tiles;
    public GameObject areaDisplayPrefab;
    private GameObject areaDisplay;
    public GameObject targetTile;
    public GameObject projectilePrefab;

    public float shootingDelay;
    private float _shootingDelay;

    private void Start()
    {
        tiles = GameObject.Find("Grid").GetComponent<TileContainer>();

        areaDisplay = Instantiate(areaDisplayPrefab);
        areaDisplay.transform.position = this.transform.position;
        areaDisplay.transform.parent = this.transform;

        _shootingDelay = shootingDelay;
    }

    private void Update()
    {
        // for every tile that can have an enemy
        foreach (var tile in tiles.enemyTiles)
        {
            // the tower's X radius (-2,0 to 2,0)
            for (float x = this.transform.position.x - 2f; x < this.transform.position.x + 3f; x++)
            {
                // the tower's Y radius (0, -2 to 0, 2)
                for (float y = this.transform.position.y - 2f; y < this.transform.position.y + 3f; y++)
                {
                    // if the tile is within the range and the tile has an enemy
                    if (tile.transform.position == new Vector3(x, y) && tile.GetComponent<hasEnemy>().hasChild == true)
                    {
                        // focus on only one enemy
                        targetTile = tile;
                        break;
                    }
                }
            }
        }

        if (targetTile != null)
        {
            shootingDelay -= Time.deltaTime;

            if(shootingDelay <= 0f)
            {
                Instantiate(projectilePrefab, this.GetComponent<Transform>());
                Debug.DrawLine(this.transform.position, targetTile.transform.position);

                shootingDelay = _shootingDelay;
            }
            
        }
    }

    private void OnMouseEnter()
    {
        areaDisplay.SetActive(true);
    }

    private void OnMouseExit()
    {
        areaDisplay.SetActive(false);
    }
}
