using UnityEngine;
using System.Collections;

public class nextSpawnHandler : MonoBehaviour {

	[SerializeField] private GameManagerScript gameManager;
	private bool hasSpawned = false;
	private Transform thisTrans;
	private Transform targTrans;

	//Finds the EndPoint transform

	private Transform endTrans;
	private playStats stats;

	//public GameObject[] arrayLevelBlocks;


	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManagerScript> ();
		stats = gameManager.GetComponent<playStats>();
		thisTrans = gameObject.GetComponent<Transform> ();
		targTrans = gameManager.GetComponent<Transform> ();
		endTrans = transform.GetChild (0);

	}
	
	// Update is called once per frame
	void Update () {
		checkSpawn ();
	}

	void checkSpawn()
	{
		if (!hasSpawned) {

			if(endTrans.position.x < stats.spawnerLocation.position.x)//if (thisX < targX) 
			{
				hasSpawned = true;
				DoSpawn ();
			}


		}
	}

	void DoSpawn()
	{
		gameManager.AddLevelBlock(endTrans);
	}
}
