using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	#region Variables
	public float speed = 4f;
	public float jumpForce = 400f;
	public int flip = -1; //-1 means sprite faces right

	private Rigidbody2D rb;
#endregion

#region Methods
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}
	

	void Update () 
	{
		float x = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(x * speed * Time.deltaTime, rb.velocity.y);

		if (x < 0)
		{
			Vector3 scale = transform.localScale;
			scale.x = -1 * flip;
			transform.localScale = scale;
		}
		else if (x > 0) {
			Vector3 scale = transform.localScale;
			scale.x = flip;
			transform.localScale = scale;
		}

		if (Input.GetKeyDown(KeyCode.Space) && Grounded()) {
			rb.AddForce(new Vector2(0, jumpForce));
		}
	}

	private bool Grounded() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .6f, 1 << LayerMask.NameToLayer("midground"));

		if (hit.collider != null)
		{
			return true;
		} return false;
	}
#endregion
}
