using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float u_triggerDistance = 0;
	public GameObject u_projectile;

	private bool i_hasShot = false;
	private Transform i_player;
		
	// Use this for initialization
	void Start () {
		if(u_projectile == null){
			throw new UnassignedReferenceException("must have a u_projectile");
		}

		i_player = GameObject.FindGameObjectWithTag("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!i_hasShot){
			if(transform.position.x - i_player.position.x < u_triggerDistance){
				shoot();
			}
		}
	}

	void shoot(){
		Instantiate(u_projectile, transform.position, Quaternion.identity);
		i_hasShot = true;
	}
}
