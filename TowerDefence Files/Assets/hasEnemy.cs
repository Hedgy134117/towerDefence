using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasEnemy : MonoBehaviour {

    public bool hasChild = false;

    private void Update()
    {
        if (this.GetComponentInChildren<BasicEnemyAI>() == true)
        {
            hasChild = true;
        }
        else
        {
            hasChild = false;
        }
    }
}
