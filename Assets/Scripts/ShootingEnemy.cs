using UnityEngine;
using System.Collections;

public class ShootingEnemy : EnemyScript {

	public GameObject u_projectile;

	void Start () {
		base.Start();
		if(u_projectile == null){
			throw new UnassignedReferenceException("must have a u_projectile");
		}
	}

	protected override void shoot(){
		base.shoot();
		Instantiate(u_projectile, transform.position, Quaternion.identity);

	}
}
