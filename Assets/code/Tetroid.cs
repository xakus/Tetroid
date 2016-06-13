/**
 *
 * @author S.Murad
 */
using UnityEngine;
using System.Collections;

public class Tetroid 
{
	public static int nextTet;	
	private static bool flag=true;
	private  int[,] tet = new int[4, 4];
	public static  int[,] nextTetroid;	
	private static int nt;
	void Start(){
		if (StaticClass.nextTetroid != null) {
			nextTet=StaticClass.nextTetroid;
			flag=false;
		}
	}
	public static int[,] tetroid ()
	{


		if (flag) {
			nextTet = Random.Range (0, 7);
			flag = false;
		}
	


			nt = nextTet;
			nextTet = Random.Range (0, 7);

	
			
		
		return new Tetroid().tetroidX(nt);
	}
	public static int[,] nextTetroids(){
		if(nextTetroid!=null){
			for (int i = 0; i < 4; i++) {
				for (int j = 0; j < 4; j++) {
					nextTetroid [i, j] = 0;
				}
			}
		}
		nextTetroid=new Tetroid().tetroidX(nextTet);

		return nextTetroid;
	}
		private  int[,] tetroidX (int t){
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				tet [i, j] = 0;
			}
		} 
		if (t == 0) {
			tet [1, 1] = 1;//oooo
			tet [1, 2] = 1;//o##o
			tet [2, 1] = 1;//o##o
			tet [2, 2] = 1;//oooo
		} else if (t == 1) {
			tet [0, 1] = 1;//o#oo
			tet [1, 1] = 1;//o#oo
			tet [2, 1] = 1;//o#oo
			tet [3, 1] = 1;//o#oo
		} else if (t == 2) {
			tet [1, 0] = 1;//o#oo
			tet [1, 1] = 1;//o#oo
			tet [1, 2] = 1;//o##o
			tet [2, 2] = 1;//oooo
		} else if (t == 3) {
			tet [2, 0] = 1;//oo#o
			tet [2, 1] = 1;//oo#o
			tet [2, 2] = 1;//o##o
			tet [1, 2] = 1;//oooo
		} else if (t == 4) {
			tet [0, 1] = 1;//oooo
			tet [1, 1] = 1;//##oo
			tet [1, 2] = 1;//o##o
			tet [2, 2] = 1;//oooo
		} else if (t == 5) {
			tet [1, 2] = 1;//oooo
			tet [2, 2] = 1;//oo##
			tet [2, 1] = 1;//o##o
			tet [3, 1] = 1;//oooo
		} else if (t == 6) {
			tet [1, 1] = 1;//oooo
			tet [2, 1] = 1;//o###
			tet [3, 1] = 1;//oo#o
			tet [2, 2] = 1;//oooo
		} else if (t == 7) {  
			tet [1, 2] = 1;//
			tet [2, 1] = 1;//
			tet [2, 2] = 1;//
			tet [2, 3] = 1;//oooo
			tet [3, 1] = 1;//o###
			tet [3, 2] = 1;//o###
			tet [1, 1] = 1;//o###
			tet [1, 3] = 1;//
			tet [3, 3] = 1;//
				
		} else if (t == 8) {
			tet [0, 1] = 1;//oooo
			tet [0, 2] = 1;//####
			tet [1, 1] = 1;//#oo#
			tet [2, 1] = 1;//oooo
			tet [3, 1] = 1;//
			tet [3, 2] = 1;//
		}

		return tet;
	}


}
