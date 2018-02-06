using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttack : MonoBehaviour {

	#region Variables
	public float fireRadius = 5f;
	public GameObject bossShot;
	public GameObject bossShotPoint;
	public float rechargeTime = 2.2f;
	public AudioClip launchNoise;

	private float lastShotTime;

	Transform target;
	#endregion

#region Methods
	void Start () 
	{
		
	}
	

	void Update () 
	{
		if (Time.time > lastShotTime + rechargeTime)
		{
			target = GameObject.FindGameObjectWithTag("Player").transform;
			float distance = Vector2.Distance(target.position, transform.position);
			if (distance <= fireRadius)
			{
				Debug.Log("Should shoot");
				Shoot();
			}
		}
	}
	void Shoot() {
		if (launchNoise != null)
		{
			AudioSource.PlayClipAtPoint(launchNoise, bossShotPoint.transform.position, 3f);
		}
		lastShotTime = Time.time;
		Instantiate(bossShot, bossShotPoint.transform.position, bossShotPoint.transform.rotation);
	}
#endregion
}
//Object.Instantiate(projectile, crouchShotPoint.transform.position, crouchShotPoint.transform.rotation);
