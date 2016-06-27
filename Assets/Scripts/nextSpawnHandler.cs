using UnityEngine;
using System.Collections;

public class nextSpawnHandler : MonoBehaviour {

	[SerializeField] private GameManagerScript gameManager;
	private bool hasSpawned = false;
	private Transform thisTrans;
	private Transform targTrans;

	//Finds the EndPoint transform

	private Transform endTrans;

	public GameObject[] arrayLevelBlocks;


	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManagerScript> ();
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
			float thisX = thisTrans.position.x;
			float targX = targTrans.position.x;

			if (thisX < targX) 
			{
				hasSpawned = true;
				DoSpawn ();
			}


		}
	}

	void DoSpawn()
	{
		int picker = Random.Range (0, arrayLevelBlocks.Length);
		Instantiate (arrayLevelBlocks [picker], endTrans.position, endTrans.rotation);
	}
}
