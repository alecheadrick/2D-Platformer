using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

	#region Variables
	public int points;

#endregion

#region Methods
	void OnTriggerEnter2D (Collider2D coll) 
	{
		GameManager.AddScore(points);
		Object.Destroy(gameObject);
	}
#endregion
}
