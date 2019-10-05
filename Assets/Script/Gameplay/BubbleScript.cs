using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {

	public bool clicked;
	public bool TriggeringA, TriggeringB = false;
	private float minPosY = -5f;
	private Vector2 IncreasedScale, DecreasedScale;

	void Start()
	{
		DecreasedScale = new Vector2(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f);
		IncreasedScale = new Vector2(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f);
	}
	
	void Update()
	{
		if(transform.position.y <= minPosY && clicked)
		{
			Vector2 pos = transform.position;
			pos.y = minPosY;
			transform.position = pos;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Ground" && minPosY == -5f)
		{
			minPosY = transform.position.y;
		}
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Answer_A" && clicked)
		{
			TriggeringA = true;
			transform.localScale = DecreasedScale;
		}
		if(coll.gameObject.tag == "Answer_B" && clicked)
		{
			TriggeringB = true;
			transform.localScale = DecreasedScale;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Answer_A" && clicked)
		{
			TriggeringA = false;
			transform.localScale = IncreasedScale;
		}
		if(coll.gameObject.tag == "Answer_B" && clicked)
		{
			TriggeringB = false;
			transform.localScale = IncreasedScale;
		}
	}
}
