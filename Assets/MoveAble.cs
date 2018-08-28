using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAble : Interactable
{
    public Transform player;

    public override void use()
    {
        transform.SetParent(player);
        transform.localPosition = new Vector3(0.5f, -1, 1.5f);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
        player.gameObject.GetComponent<Player>().held = transform;
    }
}
