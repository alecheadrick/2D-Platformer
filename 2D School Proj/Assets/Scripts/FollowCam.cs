using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

	#region Variables
	public float maxSpeed;
	public float xMax;
	public float yMax;
	public float xMin;
	public float yMin;
	public float smoothSpeed = 0.125f;


	private Transform target;
	#endregion

	#region Methods
	void Start()
	{
		target = GameObject.FindWithTag("Player").transform;

	}

	// Update is called once per frame
	void LateUpdate()
	{
		
		
		//Vector3 desiredPosition = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax),transform.position.z);
		//Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z); ;



		//how do we limit the camera between topLeft & bottomRight?

	}
	#endregion
}
