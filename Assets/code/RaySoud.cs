using UnityEngine;
using System.Collections;

public class RaySoud : MonoBehaviour {
	public float dist=1f,dx,dy,dz;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if(Physics.Raycast(transform.position,(-1)*transform.up,out hit,dist)){
			Debug.DrawLine(this.transform.position,hit.transform.position,Color.red);
			Debug.Log("Stolcnovenie s "+hit.collider.tag);
			if(StaticClass.TetroidSound&&hit.collider.tag!="Tetroid"){
			
				this.GetComponent<AudioSource>().Play();
				StaticClass.TetroidSound =false;
			}

		}
	}
}
