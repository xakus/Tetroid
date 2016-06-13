using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public  class StaticClass : MonoBehaviour {
	//public GameObject dontDestroyObj;
	public static long score=0;
	public static long totalScore=0;
	public static long line=0;
	public static int level=1;
	public static float musicValume=1.0f;
	public static float soundValume=1.0f;
	private static int openLevel=5;
	public static bool musicMute=true;
	public static bool soundMute=true;
	public static bool clearTet2=false;
	private static bool tetroidSound = false; 
	public static int graphicValue=5 ; 
	private int width;
	private int height;
	public GameObject settingsCanvas;
	public GameObject exitCanvas;
	public GameObject loadCanvas;
	public GameObject GameButton;
	public GameObject LoadButton;
	public GameObject SettingsButton;
	public GameObject ExitButton;
	public GameObject MusicSlider;
	public GameObject SoundSlider;
	public GameObject MusicMute;
	public GameObject SoundMute;
	public GameObject[] Levels;
	public static int[,]  saveMatrix;
	public static int[,]  Tetroid;
	public static int[] TetCoordinat;
	public static int nextTetroid;
////	public Toggle video_1;
	public GameObject  VideoChange;
	public GameObject  VideoT;
	public AudioClip[] audioSource;
	private AudioSource aSource;
	private int playNumber=0;
	//public Toggle video_3;
	//public Toggle video_4;
	//public Toggle video_5;
	//public Toggle video_6;

	public static bool TetroidSound
	{
		get { return tetroidSound; }
		set { tetroidSound = value; }
	}
	public void game(){
		Application.LoadLevel(2);
		//GameObject.DontDestroyOnLoad (dontDestroyObj);
		 
	}
	public void settingsOpen (){
		GameButton.GetComponent<Button> ().enabled = false;
		LoadButton.GetComponent<Button> ().enabled = false;
		SettingsButton.GetComponent<Button> ().enabled = false;
		ExitButton.GetComponent<Button> ().enabled = false;
		settingsCanvas.SetActive (true);
	}
	public void settingsClose(){
		GameButton.GetComponent<Button> ().enabled = true;
		LoadButton.GetComponent<Button> ().enabled = true;
		SettingsButton.GetComponent<Button> ().enabled = true;
		ExitButton.GetComponent<Button> ().enabled = true;
		settingsCanvas.SetActive (false);
	}

	public void loadOpen (){
		GameButton.GetComponent<Button> ().enabled = false;
		LoadButton.GetComponent<Button> ().enabled = false;
		SettingsButton.GetComponent<Button> ().enabled = false;
		ExitButton.GetComponent<Button> ().enabled = false;
		loadCanvas.SetActive (true);
	}
	public void loadClose(){
		GameButton.GetComponent<Button> ().enabled = true;
		LoadButton.GetComponent<Button> ().enabled = true;
		SettingsButton.GetComponent<Button> ().enabled = true;
		ExitButton.GetComponent<Button> ().enabled = true;
		loadCanvas.SetActive (false);
	}


	public  void exit(){
		GameButton.GetComponent<Button> ().enabled = false;
		LoadButton.GetComponent<Button> ().enabled = false;
		SettingsButton.GetComponent<Button> ().enabled = false;
		ExitButton.GetComponent<Button> ().enabled = false;
		exitCanvas.SetActive( true);
	}
	public void exitYes(){
		Application.Quit ();
	}
	public void exitNo(){
		GameButton.GetComponent<Button> ().enabled = true;
		LoadButton.GetComponent<Button> ().enabled = true;
		SettingsButton.GetComponent<Button> ().enabled = true;
		ExitButton.GetComponent<Button> ().enabled = true;
		exitCanvas.SetActive( false);

	}
	public void musicChange(float value){
		musicValume=value;
		Debug.Log (musicValume);
	}
	public void soundChange(float value){
		soundValume=value;
		Debug.Log (soundValume);
	}
	public void musicMuteChange(bool value){
		musicMute = value;
		Debug.Log (musicMute);
	}
	public void soundMuteChange(bool value){
		soundMute = value;	
		Debug.Log (soundMute); 
	}
	public void videoC(float value){
		graphicValue=(int)value;
		Debug.Log (graphicValue);
		videoT ();
	}

	void Start () {
		Resolution res = Screen.currentResolution;
		width = res.width ;
		height = res.height;
		Screen.SetResolution (width, height, true);
		aSource = gameObject.GetComponent<AudioSource> ();
		MusicSlider.GetComponent<Slider> ().value = musicValume;
		SoundSlider.GetComponent<Slider> ().value = soundValume;
		MusicMute.GetComponent<Toggle> ().isOn = musicMute;
		SoundMute.GetComponent<Toggle> ().isOn = soundMute;
		VideoChange.GetComponent<Slider> ().value = graphicValue;
		videoT ();
		if(audioSource.Length>0){
		playNumber = Random.Range (0, audioSource.Length); 
			aSource.clip =audioSource[playNumber];
			aSource.Play();
			aSource.volume=musicValume;
			aSource.mute=!musicMute;
		}


	}
	private void videoT(){
		if (graphicValue == 0) {
			VideoT.GetComponent<Text>().text="Fastest";
		}
		if (graphicValue == 1) {
			VideoT.GetComponent<Text>().text="Fast";
		}
		if (graphicValue == 2) {
			VideoT.GetComponent<Text>().text="Simple";
		}
		if (graphicValue == 3) {
			VideoT.GetComponent<Text>().text="Good";
		}
		if (graphicValue == 4) {
			VideoT.GetComponent<Text>().text="Beautiful";
		}
		if (graphicValue == 5) {
			VideoT.GetComponent<Text>().text="Fantastic";
		}
	}
	void Update(){
		QualitySettings.SetQualityLevel (graphicValue);

		if(audioSource.Length>0){
			if (!aSource.isPlaying) {

				playNumber = Random.Range (0, audioSource.Length); 
				aSource.clip =audioSource[playNumber];
				aSource.Play();

			}
			aSource.volume=musicValume;
			aSource.mute=!musicMute;
		}
		for (int i=0; i<Levels.Length; i++) {
		   if(i<=openLevel){
				Levels[i].GetComponent<RawImage>().color=new Color(1,1,1);
			}else{
				Levels[i].GetComponent<RawImage>().color=new Color(0,0,0);
			}
		}
		Debug.Log ("width="+width+" heght="+height );
	}


}