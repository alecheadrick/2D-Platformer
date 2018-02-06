using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portal : MonoBehaviour {


	#region Variables
	public GameObject levelCompleteText;
	public AudioClip teleNoise;
	public bool levelcompactive;
	public Rigidbody2D rb;
	#endregion

	#region Methods
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && levelcompactive == true)
		{
			//Debug.Log("Next Level now");
			GameManager.NextLevel();
		}
	}
	void OnTriggerEnter2D(Collider2D coll) {
		coll.transform.GetComponent<playerController>().enabled = false;
		if (coll.gameObject.tag == "Player")
		{
			levelcompactive = true;
			if (teleNoise != null)
			{
				AudioSource.PlayClipAtPoint(teleNoise, transform.position, 3f);
				
			}
			levelCompleteText.SetActive(true);

			
		}
	}
#endregion
}
