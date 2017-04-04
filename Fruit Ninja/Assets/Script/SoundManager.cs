using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour 
{
	public static SoundManager Instance { set; get; }

	public AudioSource source;
	public AudioClip[] allSounds;

	private void Awake () 
	{
		Instance = this;	
	}

	private void Start()
	{
		DontDestroyOnLoad(gameObject);
		SceneManager.LoadScene("Menu");
	}

	public void PlaySound(int soundIndex)
	{
		// source.Play();
	}

}
