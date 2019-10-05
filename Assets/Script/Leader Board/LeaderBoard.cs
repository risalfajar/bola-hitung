using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeaderBoard : MonoBehaviour {

	public GameObject LeaderBoardObject;
	public AudioSource ClickSound;
	private Text LeaderBoardText;

	void Start () {
		LeaderBoardText = LeaderBoardObject.GetComponent<Text>();
		LeaderBoardText.text = null;
		for(int i = 1; i < 6; i++)
		{
			LeaderBoardText.text = LeaderBoardText.text + i.ToString() + ". " + PlayerPrefs.GetInt("HighScore" + i.ToString(), 0) + "\n";
		}
	}

	public void Kembali()
	{
		ClickSound.Play();
		Destroy(GameObject.Find("Music"));
		Application.LoadLevel("Main Menu");
	}
}
