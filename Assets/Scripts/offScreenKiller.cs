using UnityEngine;
using System.Collections;

public class offScreenKiller : MonoBehaviour {

	Transform endTrans;
	Transform gameManager;

	private playStats stats;


	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManagerScript> ().transform;
		stats = gameManager.GetComponent<playStats>();
		endTrans = transform.GetChild (0);
	}

	// Update is called once per frame
	void Update () {
		if(endTrans.position.x < stats.despawnerLocation.position.x){//gameManager.position.x - 100){
			Destroy(this.gameObject);
		}
			
	}

	void OnTriggerExit(Collider col){
		Debug.Log("Exited "+col.gameObject.name);
	}

	void OnTriggerEnter(Collider col){
		Debug.Log("Entered "+col.gameObject.name);
	}
}
