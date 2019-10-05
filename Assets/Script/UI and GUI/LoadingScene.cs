using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScene : MonoBehaviour {

	public string[] TahukahKamu;
	public Color[] colors;

	private Camera cam;
	private Text tahukahKamuText;

	protected int randomIndex;
	protected float timer = 0;

	void Awake()
	{
		cam = Camera.main.GetComponent<Camera>();
		tahukahKamuText = GameObject.Find("Stuff").GetComponent<Text>();
		DontDestroyOnLoad(GameObject.Find("Music"));
	}

	void Start()
	{
		randomIndex = Random.Range(0, colors.Length);
		InvokeRepeating("PlayText", 0f, 3f);
		Invoke("LoadLevel", Random.Range(3f, 5f));
	}

	void LoadLevel()
	{
		Application.LoadLevel("Time Fast");
	}

	void PlayText()
	{
		int randomTextIndex = Random.Range(0, TahukahKamu.Length);
		tahukahKamuText.text = TahukahKamu[randomTextIndex];
	}

	void Update()
	{
		timer += 0.004f;
		cam.backgroundColor = Color.Lerp(cam.backgroundColor, colors[randomIndex], timer);
		if(timer > 1f)
		{
			timer = 0f;
			randomIndex = Random.Range(0, colors.Length);
		}
	}
}
