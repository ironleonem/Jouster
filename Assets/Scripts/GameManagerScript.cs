using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

	public GameObject levelBlock;

	public GameObject[] LevelBlocks;

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

	public void AddLevelBlock(Transform t){
		int picker = Random.Range (0, LevelBlocks.Length);
		Instantiate (LevelBlocks [picker], t.position - new Vector3(2f,0,0), t.rotation);
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
