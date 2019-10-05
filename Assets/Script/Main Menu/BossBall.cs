using UnityEngine;
using System.Collections;

public class BossBall : MonoBehaviour {

	private Rigidbody2D[] rigidbodies;

	void Start () {
		rigidbodies = GameObject.FindObjectsOfType<Rigidbody2D>();
		//InvokeRepeating("Explode", 0, 3);
	}

	void Explode()
	{
		foreach(Rigidbody2D rigit in rigidbodies)
		{
			float distance = Vector2.Distance(rigit.transform.position, transform.position);
			if(distance < 5 && rigit.tag == "Bubble" && Input.GetMouseButtonDown(0))
			{
				float px = rigit.transform.position.x - transform.position.x;
				float py = rigit.transform.position.y - transform.position.y;

				rigit.AddForce(new Vector2(px,py).normalized * 5000f / distance);
			}
			if(rigit.transform.position.y < -15f)
			{
				rigit.gameObject.SetActive(false);
			}
		}
	}

	void FixedUpdate()
	{
		Explode();
	}
}
