using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BossShot : MonoBehaviour {

	#region Variables
	public Transform target;
	public float speed = 5f;
	public float rotateSpeed = 200f;

	private Rigidbody2D rb;
#endregion

#region Methods
	void Start () 
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		rb = GetComponent<Rigidbody2D>();
	}
	

	void FixedUpdate () 
	{
		Vector2 direction = (Vector2)target.position - rb.position;
		direction.Normalize();
		float rotateAmount = Vector3.Cross(direction, transform.right).z;
		rb.angularVelocity = -rotateAmount * rotateSpeed;
		rb.velocity = transform.right * speed;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag =="Player") {
			GameManager.Death();
			Destroy(gameObject);
		}
		if (collision.gameObject.tag == "playerShot")
		{
			Destroy(gameObject);
		}
	}
	#endregion
}
