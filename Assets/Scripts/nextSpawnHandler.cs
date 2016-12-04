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

	public GameObject[] arrayLevelBlocks;


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
//		Debug.Log(hasSpawned+". "+endTrans.position.x+" < "/*+stats.spawnerLocation.position.x+" = "+(endTrans.position.x < stats.spawnerLocation.position.x)*/);
//		Debug.Log(stats.spawnerLocation);
		if (!hasSpawned) {
			//float thisX = thisTrans.position.x;
			//float targX = targTrans.position.x;

			if(endTrans.position.x < stats.spawnerLocation.position.x)//if (thisX < targX) 
			{
				hasSpawned = true;
				DoSpawn ();
			}


		}
	}

	void DoSpawn()
	{
		//MOVE TO SPAWNER SCRIPT IN GAME MANAGER.
		gameManager.AddLevelBlock(endTrans);

//		int picker = Random.Range (0, arrayLevelBlocks.Length);
//		Instantiate (arrayLevelBlocks [picker], endTrans.position - new Vector3(2f,0,0), endTrans.rotation);
	}
}
