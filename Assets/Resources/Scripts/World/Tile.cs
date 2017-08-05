using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

	Entity presentEntity;
	Prop presentProp;
	Item presentItem;
	GameObject texture;
	Vector3 gridPosition;

	public Tile(){}

	public Tile(GameObject texture, Vector3 position){
		this.texture = texture;
		gridPosition = position;
	}

	public void SetGridPosition(Vector3 position){
		gridPosition = position;
	}

	public Vector3 GetGridPosition(){
		return gridPosition;
	}

	public void SetTileTexture(GameObject texture){
		this.texture = texture;
	}

	public GameObject GetTileTexture(){
		return this.texture;
	}
}
