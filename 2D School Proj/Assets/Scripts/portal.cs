using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour {


	#region Variables
	#endregion

	#region Methods
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player")
		{
			GameManager.NextLevel();
		}
	}
#endregion
}
