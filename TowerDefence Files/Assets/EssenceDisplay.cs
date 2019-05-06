using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EssenceDisplay : MonoBehaviour {

	public EssenceContainer essenceContainer;
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<TMP_Text>().text = "ESSENCE: " + essenceContainer.essence.ToString();
	}
}
