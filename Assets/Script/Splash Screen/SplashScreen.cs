using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public GameObject Movie;
	public AudioSource splashSound;

	void Start () {
		StartCoroutine("Load");
	}

	IEnumerator Load()
	{
		splashSound.Play();
		yield return new WaitForSeconds(2f);
		Movie.SetActive(false);
		Camera.main.backgroundColor = Color.white;
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("Main Menu");
	}
}
