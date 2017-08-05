using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity  {

	bool isPlayer;
	bool isDead;

	//Base stats
	int level;
	int strength;
	int agility;
	int constitution;
	int intellect;
	int willpower;
	int charisma;

	//Stats dependent on base stat values
	int hp;
	int speed;

	//Inventory stuff
	List<Item> inventory;
	List<Item> equipped;
	int coins;

	GameObject texture;

	public Entity(){
		inventory = new List<Item>();
	}
}
