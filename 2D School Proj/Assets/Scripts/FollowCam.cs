using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

	#region Variables
	public float maxSpeed;
	public float xMax;
	public float xMin;
	public float yMax;
	public float yMin;
	public float smoothSpeed = 0.125f;
	public float maxShake = 1.0f;
	public GameObject background;
	public float bgScrollPercent = .2f;

	private Transform target;
	#endregion

	#region Methods
	void Start()
	{
		target = GameObject.FindWithTag("Player").transform;

	}
	void Update()
	{
		
	}

	// Update is called once per frame
	void LateUpdate()
	{
		
		if (target == null)
		{
			Shake();
		}
		else
		{

			if (target != null)
			{
				//Vector3 desiredPosition = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax),transform.position.z);
				//Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
				transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
				//transform.LookAt(target);

			}
		}
		Vector2 oldpos = transform.position;
		Vector3 offset = (Vector2)transform.position - oldpos;
		background.transform.Translate(offset * (1 - bgScrollPercent));
	}

	public void Shake()
	{
		transform.position += new Vector3(Random.Range(-maxShake, maxShake),Random.Range(-maxShake, maxShake),0);
	}
	#endregion
}
