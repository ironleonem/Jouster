using UnityEngine;
using System.Collections;

public class blockMovingLogic : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float realMoveSpeed = moveSpeed * Time.deltaTime;
	
		gameObject.transform.position -= new Vector3 (realMoveSpeed, 0, 0);
	}
}
