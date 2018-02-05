using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {

	#region Variables
	public GameObject projectile;
	public GameObject shotPoint;
	public float shotForce = 8.0f;
	public float shotTTL = 5.0f;
	public float rechargeTime = 2.2f;
	public AudioClip launchNoise;

	private float lastShotTime;
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

		GameObject newshot = Object.Instantiate(projectile,
			shotPoint.transform.position,
			this.transform.rotation);

		newshot.GetComponent<Rigidbody2D>().AddForce(transform.forward * shotForce, ForceMode2D.Impulse);


		Object.Destroy(newshot, shotTTL);
	}
	#endregion
}
//need to find out why shot is just falling
