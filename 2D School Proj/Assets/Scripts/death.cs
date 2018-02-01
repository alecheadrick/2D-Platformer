using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour {

	#region Variables

	#endregion

	#region Methods
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Object.Destroy(collision.gameObject);
	}
	#endregion
}
