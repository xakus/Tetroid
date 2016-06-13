using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {

	public GameObject henderPanel;
	public GameObject exitMenu;
	public GameObject menuButton;
	public GameObject scoreText;
	public GameObject total;
	public GameObject lineText;
	public GameObject musicMuteC;
	public GameObject soundMuteC;
	public GameObject gameOver;
	private float musicValume =StaticClass.musicValume;
	private float soundValume =StaticClass.soundValume;
	private bool musicMute=StaticClass.musicMute;
	private bool soundMute=StaticClass.soundMute;

	private int graphicValue =StaticClass.graphicValue;

	public AudioClip[] audioSource;
	private AudioSource aSource;
	private int playNumber=0;

	public void openMenu(){

		henderPanel.SetActive (false);
	}
	public void openExitPanel(){
		exitMenu.SetActive (true);
		menuButton.GetComponent<Button> ().enabled = false;

	}
	public void yesButton(){
		Application.LoadLevel (1);
	}
	public void noButton(){
		exitMenu.SetActive (false);
		menuButton.GetComponent<Button> ().enabled = true;


	}

	public void MusicChange(bool value){
		StaticClass.musicMute = value;
	}
	public void SoundChange(bool value){
		StaticClass.soundMute = value;
	}
	public void replayGame(){
		Debug.Log ("ReplayGame");
		Control.replaseGame ();
		gameOver.SetActive (false);
	}
	void Start(){
		aSource = gameObject.GetComponent<AudioSource> ();
		if(audioSource.Length>0){
			playNumber = Random.Range (0, audioSource.Length); 
			aSource.clip =audioSource[playNumber];
			aSource.Play();
			aSource.volume=musicValume;
			aSource.mute=!musicMute;
			musicMuteC.GetComponent<Toggle>().isOn=StaticClass.musicMute;
			soundMuteC.GetComponent<Toggle>().isOn=StaticClass.soundMute;

			scoreText.GetComponent<Text> ().text =""+StaticClass.score;
			total.GetComponent<Text> ().text +=""+StaticClass.totalScore;
			lineText.GetComponent<Text> ().text =""+ StaticClass.line;
		}
	}
	public void musicM (bool value){
		StaticClass.musicMute = value;
	}
	public void soundM (bool value){
		StaticClass.soundMute = value;
	}
	void Update(){
		QualitySettings.SetQualityLevel (graphicValue);
		StaticClass.score=Control.score;
		StaticClass.totalScore=Control.score;
		StaticClass.line=Control.line;
		scoreText.GetComponent<Text> ().text =""+StaticClass.score;
		total.GetComponent<Text> ().text =""+StaticClass.totalScore;
		lineText.GetComponent<Text> ().text =""+ StaticClass.line;
		if(audioSource.Length>0){
			if (!aSource.isPlaying) {
				
				playNumber = Random.Range (0, audioSource.Length); 
				aSource.clip =audioSource[playNumber];
				aSource.Play();
				
			}
			aSource.volume=musicValume;
			aSource.mute=!StaticClass.musicMute;
		}
		if (Control.gameover) {
			if(!exitMenu.activeSelf){
				gameOver.SetActive(true);}else{
				gameOver.SetActive(false);
			}
		}
	}

}
