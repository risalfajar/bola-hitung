using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerTouch : MonoBehaviour {

	public GameObject SoalText;
	public AudioSource CorrectSound;

	private float timer;
	private Ray2D ray;
	private RaycastHit2D hit = new RaycastHit2D();
	private Vector2 MovedPos;
	private Transform SelectedObject = null;
	private bool isTouching;
	private Rigidbody2D selectedRigid;
	private BubbleScript bubbleScript;
	private GUIText textInBubble;

	private int a, b, soal, soalMax;
	private Text teksSoal, scoreText, timerText;

	public static int score = 0;

	void Awake()
	{
		SelectedObject = null;
		selectedRigid = null;
		bubbleScript = null;
		isTouching = false;
		soalMax = 16;
		score = 0;
		teksSoal = SoalText.GetComponent<Text>();
		scoreText = GameObject.Find("Text_Score").GetComponent<Text>();
		timerText = GameObject.Find("Timer Text").GetComponent<Text>();
	}

	void Start()
	{
		ResetSoal();
		timer = 25;
	}

	void ResetSoal()
	{
		a = 0;
		b = 0;
		soal = Random.Range(5, soalMax);
		teksSoal.text = a + " - " + b + " = " + soal;
		scoreText.text = score.ToString();
	}

	void CekSoal()
	{
		teksSoal.text = a + " - " + b + " = " + soal;
		if(a - b == soal) //jawaban benar
		{
			CorrectSound.Play();
			soalMax += 1;
			score += 1;
			timer += soalMax/2;
			ResetSoal();
		}
	}

	void CekTimer()
	{
		timer -= Time.deltaTime;
		timerText.text = Mathf.RoundToInt(timer).ToString();
		if(timer <= 0)
		{
			MainGame.isLose = true;
		}
	}

	void Update()
	{
		CekTimer();
		if(Input.GetMouseButtonDown(0))
		{
			hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
			if(hit.collider.gameObject.tag == "Bubble")
			{
				SelectedObject = hit.transform;
				selectedRigid = hit.rigidbody;
				isTouching = true;
				bubbleScript = SelectedObject.gameObject.GetComponent<BubbleScript>();
				bubbleScript.clicked = true;
				textInBubble = SelectedObject.GetComponentInChildren<GUIText>();
			}
			else
			{
				SelectedObject = null;
				selectedRigid = null;
				bubbleScript = null;
				isTouching = false;
			}
		}
		else if(Input.GetMouseButtonUp(0))
		{
			if(bubbleScript.TriggeringA)
			{
				a += int.Parse(textInBubble.text);
				SelectedObject.gameObject.SetActive(false);
				CekSoal();
			}
			else if(bubbleScript.TriggeringB)
			{
				b += int.Parse(textInBubble.text);
				SelectedObject.gameObject.SetActive(false);
				CekSoal();
			}
			SelectedObject = null;
			selectedRigid = null;
			isTouching = false;
			bubbleScript.clicked = false;
			bubbleScript = null;
		}
	}

	void FixedUpdate()
	{
		if(isTouching)
		{
			selectedRigid.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
	}
}
