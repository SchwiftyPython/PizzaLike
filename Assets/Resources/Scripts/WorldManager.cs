using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	Random r = new Random();

	public int columns = 50;
	public int rows = 50;
	public GameObject grass;
	public GameObject wall;

	private Transform boardHolder;
	//private List<Vector3> gridPositions = new List<Vector3> (); //store a gridPosition in each tile?
	private Tile[,] board; 

	void Start () {		
		BoardSetup ();
	}

	void Update () {

	}

	/*
	void InitializeList(){
		
		gridPositions.Clear ();

		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				gridPositions.Add (new Vector3 (x, y, 0));
			}
		}
	}
    */

	void BoardSetup(){
		board = new Tile[columns, rows];
		int maxWalls = columns * (rows / 2);
		int wallCount = 0;

		boardHolder = new GameObject ("Board").transform;

		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				GameObject toInstantiate;
				int tileType = Random.Range (0, 5);

				if (tileType < 4 || wallCount > maxWalls) {
					toInstantiate = grass;
				} else {
					toInstantiate = wall;
					wallCount++;
				}

				Tile tile = new Tile (toInstantiate, new Vector3 (x, y, 0));

				GameObject instance = Instantiate (tile.GetTileTexture(), tile.GetGridPosition(), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);
			}
		}
	}

}
