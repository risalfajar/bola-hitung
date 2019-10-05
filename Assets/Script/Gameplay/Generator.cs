using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generator : MonoBehaviour {

	public GameObject[] Bubbles;
	public Color[] BubbleColors;

	private List<GameObject> CurrentBubbles = new List<GameObject>();
	private List<GameObject> RemoveBubbles = new List<GameObject>();
	private float GenerateTimer;
	private int fontSize;
	private Vector2 pixel;

	void Start () {
		fontSize = Mathf.RoundToInt((Screen.width / 10f) * 1.5f);
		pixel = new Vector2(fontSize * -0.5f, fontSize * 0.5f);
	}

	void Update () {
		GenerateTimer += Time.deltaTime;
		GenerateCheck();
	}

	void GenerateCheck()
	{
		if(GenerateTimer > .6f)
		{
			GenerateBubble();
			GenerateTimer = 0;
			foreach(var Bubbles in CurrentBubbles)
			{
				if(Bubbles.transform.position.y < -8f || Bubbles.activeInHierarchy == false)
				{
					RemoveBubbles.Add(Bubbles);
				}
			}
			foreach (var Bubbles in RemoveBubbles)
			{
				CurrentBubbles.Remove(Bubbles);
				Destroy(Bubbles);
			}
		}
	}

	void GenerateBubble()
	{
		//Generate Calculation
		Vector2 GeneratedPos = new Vector2(Random.Range(-2.7f, 2.8f), 8f);
		int RandomIndex = Random.Range(0, Bubbles.Length);
		GameObject GeneratedBubble = (GameObject)Instantiate(Bubbles[RandomIndex]);
		GeneratedBubble.transform.position = GeneratedPos;
		float randomScale = Random.Range(0.6f,0.9f);
		GeneratedBubble.transform.localScale = new Vector2(randomScale, randomScale);

		//Content of Bubble
		int randomvalue = Random.Range(1, 11);
		GUIText text = GeneratedBubble.GetComponentInChildren<GUIText>();
		text.fontSize = fontSize;
		text.pixelOffset = pixel;
		if(randomvalue < 10 && randomvalue >= 0)
		{
			text.text = " " + randomvalue.ToString();
		}
		else
		{
			text.text = randomvalue.ToString();
		}

		//Color of Bubble
		SpriteRenderer BubbleSprite = GeneratedBubble.GetComponent<SpriteRenderer>();
		BubbleSprite.color = BubbleColors[Random.Range(0, BubbleColors.Length)];

		//the RigidBody
		Rigidbody2D rigid = GeneratedBubble.GetComponent<Rigidbody2D>();
		float randomGravityScale = Random.Range(0.3f, 1.2f);
		rigid.gravityScale = randomGravityScale;


		CurrentBubbles.Add(GeneratedBubble);
	}
}
