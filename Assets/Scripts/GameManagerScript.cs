using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

	public GameObject levelBlock;

	//Controls whether or not the player is alive
	private bool isPlayerAlive = true;

	// Use this for initialization
	void Start () {
		Instantiate (levelBlock, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if(!isPlayerAlive && Input.GetKeyDown(KeyCode.Return)){
			SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
		}
	}



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
