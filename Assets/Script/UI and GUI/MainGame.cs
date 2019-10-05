using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainGame : MonoBehaviour {

	public GameObject PauseScreen, LoseScreen;
	public GameObject LoseScore;
	public AudioSource ClickSound;
	private PlayerTouch playertouch;
	private Generator generator;
	private Text loseScoreText;
	float timer = 0;
	public static bool isLose;

	void Start () {
		playertouch = GetComponent<PlayerTouch>();
		generator = GetComponent<Generator>();
		loseScoreText = LoseScore.GetComponent<Text>();
		isLose = false;
	}

	void Update()
	{
		if(isLose)
		{
			LoseScreen.SetActive(true);
			playertouch.enabled = false;
			generator.enabled = false;
			timer += 0.02f;
			loseScoreText.text = Mathf.RoundToInt(Mathf.Lerp(0, PlayerTouch.score, timer)).ToString();
		}
	}

	public void Pause()
	{
		ClickSound.Play();
		Time.timeScale = 0;
		PauseScreen.SetActive(true);
	}

	public void Resume()
	{
		Time.timeScale = 1;
		ClickSound.Play();
		PauseScreen.SetActive(false);
	}

	public void Exit()
	{
		PlayerPrefs.Save();
		Time.timeScale = 1;
		ClickSound.Play();
		Destroy(GameObject.Find("Music"));
		Application.LoadLevel("Main Menu");
	}

	public void ExitandSave()
	{
		for(int z = 1; z < 6; z++)
		{
			if(PlayerTouch.score > PlayerPrefs.GetInt("HighScore" + z.ToString(), 0))
			{
				for(int i = 5; i > z - 1; i--)
				{
					PlayerPrefs.SetInt("HighScore" + i.ToString(), PlayerPrefs.GetInt("HighScore" + (i - 1).ToString(), 0));
				}
				PlayerPrefs.SetInt("HighScore" + z.ToString(), PlayerTouch.score);
				break;
			}
		}
		PlayerPrefs.Save();
		Time.timeScale = 1;
		ClickSound.Play();
		Destroy(GameObject.Find("Music"));
		Application.LoadLevel("Main Menu");
	}
}
