using UnityEngine;
using System.Collections;

public class DeadTetroid : MonoBehaviour
{
	private float t=0;
	private int x=0,y=0;
	private int tet=0;
	  void Update ()
	{
		x =int.Parse( gameObject.name.Split ((char)',')[0]);
		y = int.Parse( gameObject.name.Split ((char)',')[1]);
		Debug.Log ("x=" + x + " y=" + y);
		tet = Control.getMatrix() [x, y];

			if ( tet!=1) {
			Destroy (transform.gameObject);
		}

	}

}
