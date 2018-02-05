using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blankforpaste : MonoBehaviour
{

	#region Variables
	#region PlayAudioVars
	//playe Noise
	//public AudioClip launchNoise;
	#endregion
	#region ShootingVars
	//Shoot?
	public GameObject projectile;
	public GameObject shotPoint;
	public float shotForce = 8.0f;
	public float shotTTL = 5.0f;
	public float rechargeTime = 2.2f;
	public float damage;
	public AudioClip launchNoise;

	private float lastShotTime;
	#endregion
	#endregion

	#region Methods
	void Start()
	{
		#region playAudioMeth
		//if (launchNoise != null)
		//{
		//AudioSource.PlayClipAtPoint(launchNoise, transform.position, 1.0f);
		//}
		#endregion
	}


	void Update()
	{
		#region Shooting
		if (Input.GetAxis("Fire1") > 0 && Time.time > lastShotTime + rechargeTime)
		{
			Shoot();
		}
		#endregion
	}
	#region shootMethod
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

		newshot.GetComponent<Rigidbody>().AddForce(transform.up * shotForce, ForceMode.Impulse);


		Object.Destroy(newshot, shotTTL);
	}
	#endregion
	#endregion

}
