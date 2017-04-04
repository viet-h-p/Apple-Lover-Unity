using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
	public void PlayGame()
	{
		// SoundManager.Instance.PlaySound(0);
		SceneManager.LoadScene("Game");
	}
}
