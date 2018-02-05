using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {

	#region Variables
	public GameObject projectile;
	public GameObject shotPoint;
	public GameObject player;
	public float shotForce = 8.0f;
	public float shotTTL = 5.0f;
	public float rechargeTime = 2.2f;
	public AudioClip launchNoise;

	private float lastShotTime;
	private SpriteRenderer sR;
	#endregion

	#region Methods
	void Update () 
	{
		if (Input.GetAxis("Fire1") > 0 && Time.time > lastShotTime + rechargeTime)
		{
			Shoot();
		}
	}
	void Shoot()
	{
		lastShotTime = Time.time;

		if (launchNoise != null)
		{
			AudioSource.PlayClipAtPoint(launchNoise, shotPoint.transform.position, 1.0f);
		}
		GameObject newshot = Object.Instantiate(projectile, shotPoint.transform.position, shotPoint.transform.rotation);
		sR = newshot.GetComponent<SpriteRenderer>();
		newshot.GetComponent<Rigidbody2D>().AddForce(shotPoint.transform.position * shotForce, ForceMode2D.Force);
		if (transform.localScale.x == -1)
		{
			Debug.Log("Facing Left");
			sR.flipX = true;
		}
		else if (transform.localScale.x == 1)
		{
			Debug.Log("Facing Right");
			sR.flipX = false;
		}

		

		Object.Destroy(newshot, shotTTL);
	}
	#endregion
}