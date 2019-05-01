using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTowerProjectileScript : MonoBehaviour {

    public GameObject targetTile;
    public GameObject parent;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with " + collision.gameObject.name);

        if (collision.gameObject.GetComponent<EnemyStats>() != null && this.GetComponentInParent<TowerStats>() != null)
        {
            collision.gameObject.GetComponent<EnemyStats>().health -= this.GetComponentInParent<TowerStats>().attack;
        }
    }

}
