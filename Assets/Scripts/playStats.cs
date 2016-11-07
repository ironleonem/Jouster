using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playStats : MonoBehaviour {
	[SerializeField] private float playerHealth;
	[SerializeField] private int coinCount;
	[SerializeField] private float playerEnergy;
	[SerializeField] private float playerEnergyMax;

	public Text healthText;
	public Text energyText;
	public Text coinText;
	public bool energyInUse = false;

	public float jumpThrust = 10;
	public float m_forwardSpeed = 1.0f;
	public float m_lanceSpeedMultiplier = 2.0f;

	public float u_xVelocity = -7;
	public float u_yVelocity = 10;

	public Transform spawnerLocation;// { get; private set; }
	public Transform despawnerLocation;//  { get; private set; }

	// Use this for initialization
	void Awake (){
		playerHealth = 100;
		playerEnergyMax = 100;
		playerEnergy = playerEnergyMax;
		coinCount = 0;
	}

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		updateText();
		EnergyRestore ();
	}

	//GETTER FUNCTIONS!
	public float getHealth(){ return playerHealth; }
	public float getEnergy(){ return playerEnergy; }
	public float getEnergyMax(){ return playerEnergyMax; }
	public int getCoin(){ return coinCount; }

	//SETTER FUNCTIONS
	public void setHealth( float change) { playerHealth += change; }
	public void setEnergy( float change) { playerEnergy += change; }
	public void setEnergyMax (float change) {playerEnergyMax += change; }
	public void setCoin  (int change)    { coinCount += change; }

	void updateText()
	{
		healthText.text = "Health: " + playerHealth;
		energyText.text = "Energy: " + playerEnergy + " / " + playerEnergyMax;
		coinText.text = "Coins: " + coinCount;
	}

	public float energyRechargeRate;
	public float burnoutClock;
	public float burnoutTimer;


	void EnergyRestore()
	{
		//Check to see if the player is capped on energy
		if (playerEnergy >= playerEnergyMax) {
			playerEnergy = playerEnergyMax;
		} 
		//Check to see if the player has burned out
		else if (burnoutClock > 0) {
			burnoutClock -= Time.deltaTime;
			if (burnoutClock <= 0) {
				burnoutClock = 0;
				playerEnergy = playerEnergyMax;
			}
		}
		//Check to see if the player should start burnout
		else if (playerEnergy < 0) {
			burnoutClock = burnoutTimer;
			playerEnergy = 0;
		}
		//Check to ensure energy is not in use.
		else if (!energyInUse) {
			playerEnergy += energyRechargeRate * Time.deltaTime;
		}
	}
}
