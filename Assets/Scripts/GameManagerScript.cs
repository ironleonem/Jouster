using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public GameObject levelBlock;

	// Use this for initialization
	void Start () {
		Instantiate (levelBlock, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Controls whether or not the player is alive
	private bool isPlayerAlive = true;

	public bool getPlayerAlive ()
	{
		return isPlayerAlive;
	}

	public void setPlayerAlive(bool newStatus)
	{
		isPlayerAlive = newStatus;
	}

	//Controls player score
	private int playerScore = 0;

	public int getPlayerScore()
	{
		return playerScore;
	}

	public void modPlayerScore(int changeAmount)
	{
		playerScore += changeAmount;
	}
}
