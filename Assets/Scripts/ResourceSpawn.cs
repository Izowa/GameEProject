using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawn : MonoBehaviour {

    public GameObject item;
    public Transform point;
    // Use this for initialization
	void Start (){
		
	}
	
	void Update (){
		/*
		Hi Tom,
		you're probably wondering wtf i've been doing this evening, haha, funny i've tried doing all manner of things related to making this "crafting" system work,
		but, well here is how i thought it might work, player drops items into chute, system stores amount of items in "storage", when player requests next item system
		processes that and removes ingredients from storage to make item which drops from the top chute...
		so...
		item gets dropped in chute, triggers own removal and "storage" increments by 1 of that item
		player then goes to computer to request next product, if there is enough materials the product is produced
		1 wood makes 4 planks
		6 planks makes a box....
		
		
		item (from above) would be the item to be produced if prerequisites are met (player asks for it and there are enough materials)
		point is the transform for where it spawns from (which seems to have been the idea)
		
		(I am truly sorry in advnace if this has not been done by midday monday, will buy coffee/drink of choice to make up for it on tuesday if necessary)
		*/
		
		
	}
	
    public void Spawn () {
        Instantiate(item, point.position, item.transform.rotation);
	}
}
