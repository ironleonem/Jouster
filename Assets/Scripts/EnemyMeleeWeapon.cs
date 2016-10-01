using UnityEngine;
using System.Collections;

public class EnemyMeleeWeapon : MonoBehaviour {


	public float u_reach;
	public float u_thrustSpeed;
	private Rigidbody i_rigidBody;
	private Vector3 i_initialPos;


	RequireComponent Rigidbody;
	// Use this for initialization
	void Start () {
		i_rigidBody = GetComponent<Rigidbody>();
		i_rigidBody.useGravity = false;
		i_initialPos = transform.position;
		i_rigidBody.velocity = transform.forward * u_thrustSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Vector3.Distance(transform.position,i_initialPos) >= u_reach){
			i_rigidBody.velocity = new Vector3(0,0,0);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			col.gameObject.GetComponent<PlayerController>().damagePlayer();
		}
		Debug.Log("Collided with "+col.tag);
		//Destroy(gameObject);
	}
}
