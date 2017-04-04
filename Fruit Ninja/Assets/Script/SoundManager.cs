using UnityEngine;

public class SoundManager : MonoBehaviour 
{
	public static SoundManager Instance { set; get; }

	public AudioSource source;
	public AudioClip[] allSounds;

	private void Awake () 
	{
		Instance = this;	
		DontDestroyOnLoad(gameObject);
	}
	
	public void PlaySound(int soundIndex)
	{
		source.Play();
	}

}
