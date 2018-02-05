using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackDamage : MonoBehaviour {

	#region Variables
	public int damage;
	#endregion

	#region Methods
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			enemyHealth EnemyHealth = collision.transform.GetComponent<enemyHealth>();
			EnemyHealth.TakeDamage(damage);
		}
	}
		#endregion
}
