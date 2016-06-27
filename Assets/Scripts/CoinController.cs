using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rotate ();
	}

	void rotate()
	{
		gameObject.transform.Rotate (new Vector3 (0, rotationSpeed * Time.deltaTime, 0));
	}
}
