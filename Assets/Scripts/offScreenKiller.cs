using UnityEngine;
using System.Collections;

public class offScreenKiller : MonoBehaviour {

	Transform endTrans;
	Transform gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManagerScript> ().transform;
		endTrans = transform.GetChild (0);
	}
	
	// Update is called once per frame
	void Update () {
		if(endTrans.position.x < gameManager.position.x - 10){
			Destroy(this.gameObject);
		}
	}
}
