using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

	private float u_xVelocity;
	private float u_yVelocity;
	private Rigidbody i_rigidBody;
	private playStats playStats; 

	RequireComponent Rigidbody;
	// Use this for initialization
	void Start () {

		playStats = GameObject.FindObjectOfType<playStats>();

		u_xVelocity = playStats.u_xVelocity;
		u_yVelocity = playStats.u_yVelocity;

		i_rigidBody = GetComponent<Rigidbody>();
		i_rigidBody.velocity = new Vector3(u_xVelocity, u_yVelocity, 0);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			col.gameObject.GetComponent<PlayerController>().damagePlayer();
		}
		Debug.Log("Collided with "+col.tag);
		Destroy(gameObject);
	}
}
