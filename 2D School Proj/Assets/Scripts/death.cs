using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour {

	#region Variables

	#endregion

	#region Methods
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Debug.Log(gameObject.name + "killed Player");
			GameManager.Death();
		}
		else
		{
			Object.Destroy(collision.gameObject);
		}
	}
	#endregion
}
