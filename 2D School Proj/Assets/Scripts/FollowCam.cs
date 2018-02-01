using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

	#region Variables
	public float maxSpeed;
	public Vector2 topLeft;
	public Vector2 bottomRight;

	private GameObject target;
	#endregion

	#region Methods
	void Start()
	{
		target = GameObject.FindWithTag("Player");

		Vector3 newPos = target.transform.position;
		newPos.z = transform.position.z;
		transform.position = newPos;
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 newPos = Vector2.MoveTowards(
			transform.position,
			target.transform.position,
			maxSpeed * Time.deltaTime
		);

		//how do we limit the camera between topLeft & bottomRight?

		transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
	}
	#endregion
}
