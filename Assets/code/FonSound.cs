using UnityEngine;
using System.Collections;

public class FonSound : MonoBehaviour {
	public float startDelay=5;
	private float dTime=0;
	private bool playFlag=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (playFlag) {
			dTime += Time.deltaTime;
		    if(dTime>=startDelay){
				transform.GetComponent<AudioSource>().Play();
				dTime=0;
				playFlag=false;
				Debug.Log("Play");
			}
		}
		transform.GetComponent<AudioSource> ().mute = !StaticClass.soundMute;
		transform.GetComponent<AudioSource> ().volume = StaticClass.soundValume;
	}
}
