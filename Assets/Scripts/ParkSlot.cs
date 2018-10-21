using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkSlot : Interactable {

    //serilizable varibles for the parking slot
    [SerializeField] GameObject ui;
    //private Varibles for the parking slot
    private GameObject player;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && player == null)
        {
            player = other.transform.parent.gameObject;
            other.GetComponentInParent<Player>().setInteractable(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            other.GetComponentInParent<Player>().setInteractable(null);
        }
    }

    public override void use()
    {      
        player.transform.SetParent(gameObject.transform);
        player.transform.localPosition = new Vector3(0, player.transform.localPosition.y, 0);     
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Player>().enabled = false;
        player.transform.localRotation = Quaternion.Euler(0, -90, 0);
        Debug.Log(player.transform.eulerAngles);
        ui.SetActive(true);
    }

    public void activateBot()
    {
        player.transform.SetParent(null);
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<Player>().enabled = true;
        ui.SetActive(false);
    }
}
