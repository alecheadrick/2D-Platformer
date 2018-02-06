using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSwitch : MonoBehaviour {

	#region Variables
	public GameObject Grant;
	public GameObject dinoGrant;
	public bool doneWaiting;
	private Animator anim;
	private int hatchHash;
	#endregion

	#region Methods
	private void Start()
	{
		anim = GetComponent<Animator>();
		hatchHash = Animator.StringToHash("hatch");
		doneWaiting = true;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			Debug.Log("Player has entered Egg");
			Grant.SetActive(false);
			if (doneWaiting == true){
				anim.SetBool(hatchHash, true);
				doneWaiting = false;
			}
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Egg Hatch"))
			{
				return;
			}
			else 
			{
				StartCoroutine (Waiting());
				
			}
		}
	}
	IEnumerator Waiting() {
		yield return new WaitForSecondsRealtime((float)2.5);
		dinoGrant.SetActive(true);
		Destroy(gameObject);
	}
	#endregion
}