using UnityEngine;
using System.Collections;

public class LigthMove : MonoBehaviour {

	public float startPosition=-9f;
	public float moveSpeed=0.1f;
	public float endPosition=10f;
	private float time=0f;
	private Vector3 myVector;
	void Start () {
		QualitySettings.SetQualityLevel (0);
		transform.position = new Vector3( startPosition ,transform.position.y,transform.position.z);
		myVector = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < endPosition) {
		
			time += Time.deltaTime;

		} else {
			Application.LoadLevel(1);
		}
		if (time >=0.02) {
			transform.position=new Vector3(transform.position.x+Mathf.Abs(moveSpeed),myVector.y,myVector.z);
			time=0;
		}
	}
}
