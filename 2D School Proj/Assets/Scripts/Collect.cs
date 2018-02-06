using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

	#region Variables
	public int points;
	public AudioClip CoinCollect;

	#endregion

	#region Methods
	void OnTriggerEnter2D (Collider2D coll) 
	{
		GameManager.AddScore(points);
		Object.Destroy(gameObject);
		if (CoinCollect != null)
		{
		AudioSource.PlayClipAtPoint(CoinCollect, transform.position, 2.0f);
		}
	}
	#endregion
}
