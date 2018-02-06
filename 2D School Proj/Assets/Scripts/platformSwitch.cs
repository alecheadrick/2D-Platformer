using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSwitch : MonoBehaviour {

	#region Variables
	public GameObject platform;
	private int idleHash;
	private int flipHash;
	private int flippedHash;
	private Animator anim;
	#endregion

	#region Methods
	void Start () 
	{
		anim = GetComponent<Animator>();
		flipHash = Animator.StringToHash("flip");
		flippedHash = Animator.StringToHash("flipped");
		idleHash = Animator.StringToHash("idle");
	}
	private void Update()
	{
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("switch flip"))
		{
			StartCoroutine(Waiting());
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			anim.SetBool(idleHash, false);
			anim.SetBool(flipHash, true);
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("switch flip"))
			{
				StartCoroutine(Waiting());
			}
			platform.transform.GetComponent<MoveBackAndForth>().enabled = true;
		}
	}

	IEnumerator Waiting()
	{
		yield return new WaitForSeconds((float)0.05);
		anim.SetBool(flippedHash, true);
		anim.SetBool(flipHash, false);
	}
	#endregion
}
