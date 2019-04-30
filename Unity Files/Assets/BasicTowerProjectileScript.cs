using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTowerProjectileScript : MonoBehaviour {

    public GameObject targetTile;
    public float speed;
    public float lifetime;
    private float _lifetime;

    private void Start()
    {
        targetTile = this.transform.parent.gameObject.GetComponent<BasicTowerAI>().targetTile;
        _lifetime = lifetime;
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;

        this.transform.position = Vector3.MoveTowards(this.transform.position, targetTile.transform.position, speed);

        if (lifetime <= 0f)
        {
            Destroy(this.gameObject);
            lifetime = _lifetime;
        }
    }

}
