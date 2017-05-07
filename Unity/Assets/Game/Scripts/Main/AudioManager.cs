using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

	[HideInInspector] public bool isSoundEnabled
	{
		get{ return (PlayerPrefs.GetInt ("isSoundEnabled", 0) == 0) ? true : false; }
		set { PlayerPrefs.SetInt ("isSoundEnabled", value ? 0 : 1); }
	}

	[HideInInspector] public bool isMusicEnabled 
	{
		get { return (PlayerPrefs.GetInt ("isMusicEnabled", 0) == 0) ? true : false; }
		set { PlayerPrefs.SetInt ("isMusicEnabled", value ? 0 : 1); }
	}
	AudioSource audioSource;
	[SerializeField] AudioSource TitleMusic;
	[SerializeField] AudioSource GameMusic;
	[SerializeField] AudioClip SFX_ButtonClick;
	[SerializeField] AudioClip SFX_GameOver;
	[SerializeField] AudioClip SFX_GameWin;


	static AudioManager _instance;

	public static AudioManager instance {
		get {
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<AudioManager> ();
			}
			return _instance;
		}
	}

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake ()
	{
		if (_instance != null && _instance.gameObject != gameObject) {			
				Destroy (gameObject);
				return;
		}
		_instance = this;
		audioSource = this.gameObject.GetComponent<AudioSource>();

	}

	void Start ()
	{
		PlayTitlMusic ();
	}


	/// <summary>
	/// Plaies the button click sound.
	/// </summary>
	public void PlayButtonClickSound ()
	{

		if (isSoundEnabled) {
			audioSource.PlayOneShot (SFX_ButtonClick);
		}

	}

	/// <summary>
	/// Plaies the one shot clip.
	/// </summary>
	/// <param name="clip">Clip.</param>
	public void PlayOneShotClip (AudioClip clip)
	{
		if (isSoundEnabled) {
			audioSource.PlayOneShot (clip);
		}
	}

	public void PlayGameOverSound ()
	{
		PlayOneShotClip (SFX_GameOver);
	}

	public void PlayGameWinSound ()
	{
		PlayOneShotClip (SFX_GameWin);
	}

	public void PlayTitlMusic ()
	{
		if (isMusicEnabled) {
			TitleMusic.Play ();
		}
	}
}

