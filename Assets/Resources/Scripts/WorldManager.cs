using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	Random r = new Random();

	public int columns = 50;
	public int rows = 50;
	public GameObject grass;
	public GameObject wall;
	public GameObject playerSprite;
	public Entity player;

	private Transform boardHolder;
	//private List<Vector3> gridPositions = new List<Vector3> (); //store a gridPosition in each tile?
	private Tile[,] board; 

	public static WorldManager instance = null;

	void Awake () {		
		if (instance == null) {
			instance = this;
		}else if(instance != this){
			// Destroy the current object, so there is just one 
			Destroy(gameObject);
		}
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

	public void BoardSetup(){
		board = new Tile[columns, rows];
		int maxWalls = columns * (rows / 2);
		int wallCount = 0;

		boardHolder = new GameObject ("Board").transform;

		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				GameObject tileTypeToInstantiate;
				bool blocksMovement;
				bool blocksLight;
				int tileType = Random.Range (0, 5);

				if (tileType < 4 || wallCount > maxWalls) {
					tileTypeToInstantiate = grass;
					blocksMovement = false;
					blocksLight = false;
				} else {
					tileTypeToInstantiate = wall;
					blocksMovement = true;
					blocksLight = true;
					wallCount++;
				}

				Tile tile = new Tile (tileTypeToInstantiate, new Vector3 (x, y, 0), blocksMovement, blocksLight);

				GameObject instance = Instantiate (tile.GetTileTexture(), tile.GetGridPosition(), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);

				board [x, y] = tile;
			}
		}

		PlacePlayer ();
	}

	void PlacePlayer(){		
		

		bool placed = false;
		int y = rows / 2;
		int x = columns / 2;
		while (!placed) {
			if (!board [x, y].GetBlocksMovement()) {
				GameObject playerPawn = Instantiate (playerSprite, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
				player = new Entity (true, playerPawn);
				board [x, y].SetPresentEntity (player);					
				player.currentPosition = new  Vector3 (x, y, 0f);
				placed = true;
			}
			y++;
			x++;
		}
	}

	public Tile GetTileAt(Vector3 position){
		return board [(int)position.x, (int)position.y];
	}

	public void SetTileAt(Vector3 position, Tile tile){
		board [(int)position.x, (int)position.y] = tile; 
	}

}
