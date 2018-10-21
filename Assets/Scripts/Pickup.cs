using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.GetComponent<MoveAble>().player = transform.parent;
            GetComponentInParent<Player>().setInteractable(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == GetComponentInParent<Player>().getInteractable() )
        {
            GetComponentInParent<Player>().setInteractable(other.gameObject);
        }
    }
}
