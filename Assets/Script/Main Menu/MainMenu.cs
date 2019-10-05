using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public AudioSource ClickSound;

	void Start()
	{
		DontDestroyOnLoad(GameObject.Find("Music"));
	}

	public void Play()
	{
		ClickSound.Play();
		Application.LoadLevel("Loading");
	}

	public void Exit()
	{
		ClickSound.Play();
		Application.Quit();
	}

	public void Achievement()
	{
		ClickSound.Play();
		Application.LoadLevel("Leader Board");
	}
}
