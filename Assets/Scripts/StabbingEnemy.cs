using UnityEngine;
using System.Collections;

public class StabbingEnemy : EnemyScript {

	public GameObject u_weapon;

	void Start () {
		base.Start();
		if(u_weapon == null){
			throw new UnassignedReferenceException("must have a u_weapon");
		}
	}

	protected override void shoot(){
		base.shoot();
		u_weapon.SetActive(true);
		//Instantiate(u_projectile, transform.position, Quaternion.identity);

	}
}
