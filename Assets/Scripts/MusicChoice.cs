using UnityEngine;
using System.Collections;

public class MusicChoice : MonoBehaviour {

	public AudioSource sourceMusic;
	public AudioClip insidiousTheme;
	public AudioClip sinisterTheme;
	public AudioClip mikeMyersTheme;

	private GameObject mainMenu;
	private MainMenuStart mainMenuStart;

	// Use this for initialization
	void Start () {
		sourceMusic = GameObject.Find ("Music").GetComponent<AudioSource> ();

		sourceMusic.clip = insidiousTheme;
		mainMenu = GameObject.Find ("MainMenu");
		mainMenuStart = mainMenu.GetComponent<MainMenuStart> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (mainMenuStart.difficultySetting == 0) {
			sourceMusic.clip = mikeMyersTheme;
		} else if (mainMenuStart.difficultySetting == 1) {
			sourceMusic.clip = sinisterTheme;
		} else {
			sourceMusic.clip = insidiousTheme;
		}
	}
}
