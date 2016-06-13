using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public int width=12;
	public int height=16;
	public float speed=0.9f;
	private float speedD;
	public float sh=2.0f;
	private bool clearTet2=false;
	public float positionX=0.0f,positionY=0.0f,positionZ=0.0f;
	public float smallPositionX=0.0f,smallPositionY=0.0f,smallPositionZ=0.0f;
	public GameObject tet;
	public GameObject tet2;
	public GameObject tet3;
	private int[,] smallMatrix=new int[4,4];
	private  bool speedFlag=false;
	//public GameObject tetroids;
	//private GraphicsT gT=new GraphicsT();
	private int[,] matrix;
	// Use this for initialization
	void Start () {
		//smallMatrix=Tetroid.nextTetroids();
		Control.livel = StaticClass.level;
		if (StaticClass.saveMatrix!=null) {
			Debug.Log("1ok");
			matrix = StaticClass.saveMatrix;
			Control.setMatrix (StaticClass.saveMatrix);
			showTetroid(true);
		} else {
			matrix=new int[width,height];
			Control.setMatrix(matrix);
		}
		if (StaticClass.Tetroid != null) {
			Control.tetmatrix=StaticClass.Tetroid;
		}
		if (StaticClass.TetCoordinat != null) {
			Control.tetCoordinat = StaticClass.TetCoordinat;
		} else {
			Control.newTetroid();
		}
		speedD=speed;



		//matrix=Control.move();
		smallClearM();
	    smallMatrix=Tetroid.nextTetroids(); 
		smallShowTetroid(); 
	
	}
	float t = 0;
	int flaghor = 0;
	bool hflag=true;
	bool flagver = true;
	bool mov=true;
	float th = 0 ;
	float tv = 0;
	// Update is called once per frame
	void Update () {
		///////////////////////////////
		///save
		StaticClass.saveMatrix = matrix;
		StaticClass.TetCoordinat = Control.tetCoordinat;
		StaticClass.Tetroid = Control.tetmatrix;
		StaticClass.nextTetroid = Tetroid.nextTet;
			///////////////////////////////
		this.GetComponent<AudioSource> ().volume = StaticClass.soundValume;
		this.GetComponent<AudioSource> ().mute = !StaticClass.soundMute;
		if(!Control.getmove()){
			if(StaticClass.TetroidSound){
			this.GetComponent<AudioSource>().Play();
				StaticClass.TetroidSound=false;
			}
		}

		ClearM(false);
		t += Time.deltaTime;

		tv += Time.deltaTime;
		if (t >= speedD&&mov) {
			t = 0;
			Control.move ();
		}
		if(Control.isSits()){
			speedFlag=false;
			smallClearM();
			smallMatrix=Tetroid.nextTetroids();
			smallShowTetroid();
			clearTet2=true;

			Debug.Log("Sets");
			
			
		}
		float hor = Input.GetAxis ("Horizontal");
		float ver = Input.GetAxis ("Vertical");
		//Horizontal
		if(hor>0){
			flaghor=1;
			mov=false;
		}
		if(hor<0){
			flaghor=-1;
			mov=false;
		}
		if(hor==0){
			hflag=true;
			th=0;
			mov=true;

		}
		if(flaghor!=0){
			th+=Time.deltaTime;
			if(th>=speedD/2&&!hflag){
				if(hor==1){
					Control.rightMove();
				}
				if(hor==-1){
					Control.leftMove();
				}  
			}

			if(hflag){
			  if(hor==1){
					Control.rightMove();
					hflag=false;
					Debug.Log("move Right");
				}
				if(hor==-1){
					Control.leftMove();
					hflag=false;
					Debug.Log("move Right");
				}

			}
		}
		//Vertical 
		if (ver > 0f && flagver) {
			
			Control.rotate ();
			flagver = false;
		} else
		if (ver < 0f) {
			if(speedFlag){
			speedD = speed / 1000;
			}
		} 
		if (ver == 0) {
			speedFlag=true;
			speedD = speed;
			flagver = true;
			Debug.Log(speedFlag);
		} 
		ClearM(clearTet2);
		showTetroid (clearTet2);
		matrix = Control.getMatrix();
	}



	public  void ClearM (bool tet2) 
	{
		
		for (int i=0; i<width; i++) {
			for (int j=0; j<height; j++) {
				if (matrix [i, j] == 1&&!tet2 ) {
				
					Destroy (GameObject.Find (i + "," + j));
				
				}
				if ( tet2) { 

					Destroy (GameObject.Find (i + ",2," + j));
					
				}
			}
			
			
		}
		
		
	}
	public void showTetroid(bool fl)
	{
		for (int i=0; i<width; i++) {
			for (int j=0; j<height; j++) {
				if (matrix [i, j] == 1 )
				{
					Instantiate (tet, new Vector3 (i * sh + positionX, (height - j * sh) + positionY, positionZ),
					             Quaternion.identity).name = i + "," + j;
				}
				if(fl){
					
					if ( matrix [i, j] == 2 )
					{
						
						Instantiate (tet2, new Vector3 (i * sh + positionX, (height - j * sh) + positionY, positionZ),
						             Quaternion.identity).name = i + ",2," + j;
					}
					

				}
			}
		}

		StaticClass.clearTet2=false;

	}
	public  void smallClearM ()
	{
		
		for (int i=0; i<smallMatrix.GetLength(0); i++) {
			for (int j=0; j<smallMatrix.GetLength(1); j++) {

					
					Destroy (GameObject.Find (i + ",s," + j));
					
				    smallMatrix[i,j]=0;

			}
			
			
		}

		
		
	}
	public void smallShowTetroid()
	{
		for (int i=0; i<smallMatrix.GetLength(0); i++) { 
			for (int j=0; j<smallMatrix.GetLength(1); j++) {
				if (smallMatrix [i, j] == 1 )
				{
					Instantiate (tet3, new Vector3 (i * sh + smallPositionX, (height - j * sh) + smallPositionY, smallPositionZ),
					             Quaternion.identity).name = i + ",s," + j;
				}
				
			}
		}
	
		
	}
}
