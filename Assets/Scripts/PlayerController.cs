using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody thisRigid;
	private Transform thisTrans;
	private Vector3 startPos;
	[SerializeField] private float thisThrust;
	public playStats statHolder;
	public GameObject thisLance;

	bool lanceState = false;
	public float lanceCost;

	// Use this for initialization
	void Start () {
		thisRigid = gameObject.GetComponent<Rigidbody> ();
		thisTrans = gameObject.GetComponent<Transform> ();
		startPos = thisTrans.position;

	}
	
	// Update is called once per frame
	void Update () {
		//StandardizePosition ();
		CheckingJump();
		checkDeath ();
		CheckingAttack ();

	}

	private void StandardizePosition() {
		float curY = thisTrans.position.y;
		thisTrans.position = new Vector3 (startPos.x, curY, startPos.z);
	}

	private void CheckingJump(){
		if (Input.GetKeyDown ("space")) {
			float playerEnergy = statHolder.getEnergy();
			if (playerEnergy > 10) 
			{
				thisRigid.AddForce (Vector3.up * thisThrust);
				statHolder.setEnergy (-10);
			}

		}
	}

	private void CheckingAttack()
	{
		if (Input.GetKey ("a")) {
			float currentEnergy = statHolder.getEnergy ();
			if (currentEnergy > 0) {
				lanceState = true;
				float change = (-1 * lanceCost * Time.deltaTime);
				statHolder.setEnergy (change);
			} 
			else 
			{
				lanceState = false;
			}
		} 
		else 
		{
			lanceState = false;
		}
		LanceGraphic ();
	}

	private void LanceGraphic()
	{

		if (lanceState) {
			thisLance.SetActive (true);
			statHolder.energyInUse = true;
		} 
		else {
			thisLance.SetActive (false);
			statHolder.energyInUse = false;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "coin") {
			Destroy (other.gameObject);
			onHitCoin ();

		} else if (other.tag == "enemy") {
			Destroy (other.gameObject);
			onHitEnemy ();
		}
	}

	void onHitCoin()
	{
		statHolder.setCoin (1);
	}

	void onHitEnemy()
	{
		if (lanceState) {
			statHolder.setCoin (5);
		} else {
			statHolder.setHealth (-10);
		}
	}

	void checkDeath()
	{
		float health = statHolder.getHealth ();
		float curX = gameObject.transform.position.x;
		float curY = gameObject.transform.position.y;
		if (health <= 0) {
			Debug.Log ("Died from Health");
			killPlayer ();
		} else if (curX < -40) {
			Debug.Log ("Died from visibility");
			killPlayer ();
		} else if (curY < -15) {
			Debug.Log ("Died from Y");
			killPlayer ();
		
		}
			
	}

	public void killPlayer ()
	{
		Debug.Log ("Player has died!");
		Destroy (gameObject);
	}
} 