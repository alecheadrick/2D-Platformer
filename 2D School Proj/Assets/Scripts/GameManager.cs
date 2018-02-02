using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	#region Variables
	public static int level = 1;
	public static int score = 0;
	public static int lives = 3;

	public Text scoreText;
	public Image[] lifeIcons;
#endregion

	#region Methods
	void Start () 
	{
		
	}
	

	void Update () 
	{
		//display level in ui
		scoreText.text = "" + score;
		//display lives in ui
		for (int i = 0; i < lifeIcons.Length; i++) {
			if (i < lives - 1)
			{
				lifeIcons[i].enabled = true;
			}
			else {
				lifeIcons[i].enabled = false;
			}
		}
		//check if time has expired
	}

	public static void AddScore(int points) {
		score += points;
	}

	public static void Death() {
		//play the player death animation?

		//screen shake


		//decrement lives
		lives--;

		//if lives == 0 
		if (lives <= 0)
		{
			//change state to game over
		}
		else
		{
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			//move player at starting point
			player.SendMessage("Respawn");
			//move the camera immediately to player position
			Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, Camera.main.transform.position.z);
		}
		FollowCam cam = Camera.main.GetComponent<FollowCam>();
		if (cam != null)
		{
			cam.Shake();
		}
	}

	public static void NextLevel() {

	}
#endregion
}
