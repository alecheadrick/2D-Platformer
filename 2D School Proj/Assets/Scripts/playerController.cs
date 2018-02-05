using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerController : MonoBehaviour {

	#region Variables
	public float speed = 4f;
	public float jumpForce = 400f;
	public int flip = -1; //-1 means sprite faces right
	public float fallMultiplyer = 2.5f;
	public float lowJumpMultiplyer = 2f;
	public GameObject dinoGrant;
	public Vector3 spawnOffset;

	private Rigidbody2D rb;
	private Animator anim;
	private int moveHash;
	private int idleHash;
	private int flyHash;
	private Vector3 spawnPoint;

#endregion

#region Methods
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		moveHash = Animator.StringToHash("Moving");
		flyHash = Animator.StringToHash("flying");
		idleHash = Animator.StringToHash("idle");
		spawnPoint = transform.position;
	}


	void Update()
	{
		if (dinoGrant != null)
		{
			dinoGrant.transform.position = transform.position+spawnOffset;
		}
		if (GameManager.state != GameManager.GameState.playing) {
			anim.SetBool(flyHash, false);
			anim.SetBool(moveHash, false);
			anim.SetBool(idleHash, false);
			return;
		}
		
		//float x = CrossPlatformInputManager.GetAxis("Horizontal"); 
		if (rb.velocity.y != 0)
		{
			//Debug.Log("Should be flying");
			anim.SetBool(flyHash, true);
			//anim.SetBool(moveHash, false);
			//anim.SetBool(idleHash, false);
		}
		else {
		anim.SetBool(flyHash, false);
		//anim.SetBool(idleHash, false);
		//anim.SetBool(moveHash, false);
		//return;

		}
		float x = Input.GetAxis("Horizontal");
		if (Mathf.Abs(x) < .05)
		{
			anim.SetBool(idleHash, true);
			anim.SetBool(moveHash, false);
		}
		else {
			anim.SetBool(idleHash, false);
			anim.SetBool(moveHash, true);
		}

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
			//if (CrossPlatformInputManager.GetButtonDown("Jump") && Grounded()) {
				
				anim.SetBool(flyHash, true);
				rb.AddForce(new Vector2(0, jumpForce));
		}

		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplyer - 1) * Time.deltaTime;
		}
		else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplyer - 1) * Time.deltaTime;
		}
	}

	public void Respawn() {
		transform.position = spawnPoint;
	}

	private bool Grounded() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << LayerMask.NameToLayer("midground"));

		if (hit.collider != null)
		{
			Debug.Log("grounded");
			return true;
		}
		else {
			Debug.Log("not grounded");
		}
		return false;
	}
#endregion
}
