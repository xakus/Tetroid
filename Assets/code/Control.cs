using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public static int[] tetCoordinat;
	public static int[,] tetmatrix;
	private static int[,] matrix = null;

	private static int y = 0;
	private static int x = 5;
	private static bool gameOverFlag = true;
	private static int count;
	public static int line=0;
	public static long score=0;
	public static int livel=1;
	private static bool isvictory=false;
	private static bool sits=false;
	public static bool gameover=false;
	
	public static void newTetroid() {
		StaticClass.TetroidSound = true;

		x=matrix.GetLength(0)/2;
		y=0;
		gameOver();
		if (isGameOverFlag()) {
			
			victory();
			tetmatrix = Tetroid.tetroid();
			matrixUpdate();
		}
		
	}
	
	private static void matrixUpdate() {
		int count = 0;
		for (int i = 0; i < tetmatrix.GetLength(0); i++) {
			for (int j = 0; j < tetmatrix.GetLength(1); j++) {
				if (tetmatrix[i,j] == 1) {
					count += 2;
				}
			}
		}
		tetCoordinat = null;
		tetCoordinat = new int[count];
		count = 0;
		for (int i = 0; i < tetmatrix.GetLength(0); i++) {
			for (int j = 0; j < tetmatrix.GetLength(1); j++) {
				if (tetmatrix[i,j] == 1) {
					tetCoordinat[count] = i;
					count++;
					tetCoordinat[count] = j;
					count++;
				}
			}
		}
		for (int i = 0; i < getMatrix().GetLength(0); i++) {
			for (int j = 0; j < getMatrix().GetLength(1); j++) {
				if (matrix[i,j] == 1) {
					matrix[i,j] = 0;
				}
			}
		}
		for (int c = 0; c < tetCoordinat.GetLength(0); c += 2) {
			matrix[tetCoordinat[c] + x,tetCoordinat[c + 1] + y] = 1;
		}
	}
	
	private static bool getRotate() {
		bool flag = true;
		int count = 0;
		try {
			for (int i = 0; i < tetmatrix.GetLength(0); i++) {
				for (int j = 0; j < tetmatrix.GetLength(1); j++) {
					if (tetmatrix [i, j] == 1) {
						count += 2;
					}
				}
			}
			int[,] ttt = new int[tetmatrix.GetLength (0), tetmatrix.GetLength (1)];
			for (int i = 0; i < tetmatrix.GetLength(0); i++) {
				for (int j = 0; j < tetmatrix.GetLength(1); j++) {
					ttt [i, tetmatrix.GetLength (1) - 1 - j] = tetmatrix [j, i];
				}
			}
			
			count = 0;
			for (int i = 0; i < ttt.GetLength(0); i++) {
				for (int j = 0; j < ttt.GetLength(1); j++) {
					if (ttt [i, j] == 1) {
						if (i + x > matrix.GetLength (0) - 1 || i + x < 0) {
							flag = false;
						}
						if (j + y >= matrix.GetLength (1)) {
							flag = false;
						}
						if (i + x > 0 || i + x < matrix.GetLength (0)) {
							if (matrix [i + x, j + y] == 2) {
								flag = false;
							}
						}
						
					}
				}
			}
		} catch {
			Debug.Log ("Выход за грацу дисплея!!!");
			flag = false;
		}
		return flag;
	}
	
	public static void rotate() {
		if (getRotate()) {
			int[,] ttt = new int[tetmatrix.GetLength(0),tetmatrix.GetLength(1)];
			for (int i = 0; i < tetmatrix.GetLength(0); i++) {
				for (int j = 0; j < tetmatrix.GetLength(1); j++) {
					ttt[i,tetmatrix.GetLength(1) - 1 - j] = tetmatrix[j,i];
				}
			}
			for (int i = 0; i < tetmatrix.GetLength(0); i++) {
				for (int j = 0; j < tetmatrix.GetLength(1); j++) {
					tetmatrix[i,j] = ttt[i,j];
				}
			}
		}
		matrixUpdate();
		
	}
	
	public static bool getRightmove() {
		bool flag = true;
		
		for (int c = 0; c < tetCoordinat.GetLength(0); c += 2) {
			if (tetCoordinat[c] + x + 1 > matrix.GetLength(0) - 1) {
				flag = false;
				
			}
			if (tetCoordinat[c] + x + 1 < matrix.GetLength(0)) {
				
				if (matrix[tetCoordinat[c] + x + 1,y + tetCoordinat[c + 1]] == 2) {
					flag = false;
				}
			}
			
			
		}
		matrixUpdate();
		return flag;
	}
	
	public static bool getLeftmove() {
		bool flag = true;

		for (int c = 0; c < tetCoordinat.GetLength(0); c += 2) {
			if (tetCoordinat[c] + x - 1 < 0) {
				flag = false;
				
			}
			if (tetCoordinat[c] + x - 1 > 0) {
				if (matrix[tetCoordinat[c] + x - 1,y + tetCoordinat[c + 1]] == 2) {
					Debug.Log (tetCoordinat[c] + x - 1);
					flag = false;
				}
			}
			
			
		}
		matrixUpdate();
		return flag;
	}
	
	private static void gameOver() {
		y=0;

		if (matrix[matrix.GetLength(0)/2,1] == 2
		    ||matrix[matrix.GetLength(0)/2-1,1] == 2
		    ||matrix[matrix.GetLength(0)/2+1,1] == 2 
		    ||matrix[matrix.GetLength(0)/2-2,1] == 2
		    ||matrix[matrix.GetLength(0)/2+2,1] == 2){//|| matrix[8,2] == 2 || matrix[9,2] == 2) {
			setGameOverFlag(false);
			gameover=true;
		} else {
			setGameOverFlag(true);
		}


		if (isGameOverFlag()) {
		} else {
			clearMatrix();
			for (int i = 0; i < matrix.GetLength(0); i++) {
				for (int j = 0; j < matrix.GetLength(1); j++) {
					matrix[i,j] = 2;
					count=0;
				}
			}
			for (int i = 0; i < tetmatrix.GetLength(0); i++) {
				for (int j = 0; j < tetmatrix.GetLength(1); j++) {
					tetmatrix[i,j] = 2;
				}
			}
			matrixUpdate();
		}
	}
	
	public static bool getmove() {
		
		bool flag = true;
		
		for (int c = 0; c < tetCoordinat.GetLength(0); c += 2) {
			if (y + tetCoordinat[c + 1] != matrix.GetLength(1) - 1) {
				if (matrix[tetCoordinat[c] + x,y + tetCoordinat[c + 1] + 1] == 2) {
					flag = false;
				}
			} else {
				flag = false;
			}
			
		}
		if (flag) {
			StaticClass.TetroidSound=true;
		}
		return flag;
	}
	
	private static void victory() {
		bool flag = true ;
		int paran_j = 0;
		int linNumber = 0;
		for (int j = 0; j < matrix.GetLength(1); j++) {
			flag = true;
			for (int i = 0; i < matrix.GetLength(0); i++) {
				if (matrix[i,j] != 2) {
					flag = false;
				}
			}
			if (flag) {
				isvictory=true;
				paran_j = j;
				count++;
				linNumber++;
				for (int ii = 0; ii < matrix.GetLength(0); ii++) {
					for (int jj = j; jj > 0; jj--) {
						matrix[ii,jj] = matrix[ii,jj - 1];
					}
				}
				j = paran_j - 1;
			} else {
				paran_j = 0;
			}
		}
		line += linNumber;
		score +=(int) Mathf.Pow( linNumber , (10* (25-livel))/(10+ (25-livel)));
	}
	
	public static void leftMove() {
		if (getLeftmove()) {
			--x;
		}
		matrixUpdate();
	}
	
	public static void rightMove() {
		if (getRightmove()) {
			++x;
		}
		matrixUpdate();
	}
	
	public static int[,] move() {
		for (int i = 0; i < getMatrix().GetLength(0); i++) {
			for (int j = 0; j < getMatrix().GetLength(1); j++) {
				if (matrix[i,j] == 1) {
					matrix[i,j] = 0;
				}
			}
		}
		
		if (getmove()) {
			y++;
		} else {
			sits=true;
			for (int c = 0; c < tetCoordinat.GetLength(0); c += 2) {
				matrix[tetCoordinat[c] + x,tetCoordinat[c + 1] + y] = 2;
			}
			y = 0;
			newTetroid();
		}
		for (int c = 0; c < tetCoordinat.GetLength(0); c += 2) {
			matrix[tetCoordinat[c] + x,tetCoordinat[c + 1] + y] = 1;
		}
		return matrix;
	}
	
	public static void clearMatrix() {
		for (int i = 0; i < matrix.GetLength(0); i++) {
			for (int j = 0; j < matrix.GetLength(1); j++) {
				matrix[i,j] = 0;
			}
		}
	}
	
	/**
     * @return the matrix
     */
	public static int[,] getMatrix() {
		return matrix;
	}
	
	/**
     * @param matrix the matrix to set
     */
	public static void setMatrix(int[,] matrix) {
		Control.matrix = matrix;
	}
	
	private static void Message(string lajksld) {
		//throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
	}
	
	/**
     * @return the gameOverFlag
     */
	public static bool isGameOverFlag() {
		return gameOverFlag;
	}
	/**
     * @return the gameOverFlag
     */
	public static bool isVictory() {
		bool v=isvictory;
		isvictory=false;
		return v;
	}
	/**
     * @return the gameOverFlag
     */
	public static bool isSits() {
		bool s=sits;
		sits=false;
		return s;
	}
	public static void replaseGame(){

		 tetCoordinat=null;
		 tetmatrix=null;
		// matrix = null;
		
		 y = 0;
		 x = 5;
		 gameOverFlag = true;
		 count=0;
		 line=0;
		score=0;
		livel=1;
		isvictory=false;
		 sits=false;
		 gameover=false;

		int[,] newMtrix=new int[Control.getMatrix().GetLength(0),Control.getMatrix().GetLength(1)];
		for(int i=0;i<Control.getMatrix().GetLength(0);i++)
		{
			for(int j=0;j<Control.getMatrix().GetLength(1);j++)
			{
				newMtrix[i,j]=0;
			}
		}
		setMatrix (newMtrix);
		newTetroid ();
		//StaticClass.clearTet2 = true;
		//new Main ().ClearM (StaticClass.clearTet2);
		//new Main ().smallClearM();
		for (int i=0; i<matrix.GetLength(0); i++) {
			for (int j=0; j<matrix.GetLength(1); j++) {				
					Destroy (GameObject.Find (i + ",2," + j));					

			}
			
			
		}
	}
	
	/**
     * @return the count
     */
	public static int getCount() {
		return count;
	}
	
	/**
     * @param aGameOverFlag the gameOverFlag to set
     */
	public static void setGameOverFlag(bool aGameOverFlag) {
		gameOverFlag = aGameOverFlag;
	}
}
