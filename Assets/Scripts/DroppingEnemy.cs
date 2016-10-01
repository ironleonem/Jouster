using UnityEngine;
using System.Collections;

public class DroppingEnemy : EnemyScript {

	public Rigidbody u_parentBody;

	void Start () {
		base.Start();
		if(u_parentBody == null){
			throw new UnassignedReferenceException("must have a u_parentBody");
		}
	}

	protected override void shoot(){
		base.shoot();
		u_parentBody.useGravity = true;
	}
}
