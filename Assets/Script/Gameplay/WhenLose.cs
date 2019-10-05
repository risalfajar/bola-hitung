using UnityEngine;
using System.Collections;

public class WhenLose : MonoBehaviour {

	public GameObject NewHighScoreText;

	void OnEnable()
	{
		for(int z = 1; z < 6; z++)
		{
			if(PlayerTouch.score > PlayerPrefs.GetInt("HighScore" + z.ToString(), 0))
			{
				NewHighScoreText.SetActive(true);
				for(int i = 5; i > z - 1; i--)
				{
					PlayerPrefs.SetInt("HighScore" + i.ToString(), PlayerPrefs.GetInt("HighScore" + (i - 1).ToString(), 0));
				}
				PlayerPrefs.SetInt("HighScore" + z.ToString(), PlayerTouch.score);
				break;
			}
		}
		PlayerPrefs.Save();
	}
}