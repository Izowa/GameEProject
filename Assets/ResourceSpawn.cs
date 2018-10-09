using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawn : MonoBehaviour {

    public GameObject item;
    public Transform point;
    // Use this for initialization
    public void Spawn () {
        Instantiate(item, point.position, item.transform.rotation);
	}
	
}
