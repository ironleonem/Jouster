using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;

	//private bool spawned = false;

	void OnEnable(){
		spawn();

	}
	
	public void spawn(){
		Instantiate(enemy, transform.position, Quaternion.AngleAxis(-90, Vector3.up));
		Destroy(this);
	}
}
