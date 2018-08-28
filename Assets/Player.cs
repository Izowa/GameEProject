using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] Rigidbody attachedRigid;
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;

    float rotAmount;
    Vector3 lookDir;
    Quaternion lookQuat;

    float deadzone = 0.25f;
    public GameObject Interactable;
    public Transform held;
    
    public void setInteractable(GameObject obj)
    {
        Interactable = obj;
    }

    public GameObject getInteractable()
    {
        return Interactable;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {       
		if(Input.GetAxis("Horizontal") >= 1)
        {
            attachedRigid.AddForce(-Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetAxis("Horizontal") <= -1)
        {
            attachedRigid.AddForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetAxis("Vertical") >= 1)
        {
            attachedRigid.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetAxis("Vertical") <= -1)
        {
            attachedRigid.AddForce(-Vector3.right * speed * Time.deltaTime, ForceMode.Impulse);
        }
        lookDir = new Vector3(Input.GetAxis("RightJoyVert"), 0,Input.GetAxis("RightJoyHorz"));
        if (lookDir.magnitude < deadzone)
            lookDir = Vector2.zero;
        else
            lookDir = lookDir.normalized * ((lookDir.magnitude - deadzone) / (1 - deadzone));

        if (lookDir.x != 0 || lookDir.y != 0)
        {
            lookQuat = Quaternion.LookRotation(lookDir);
        }
        else if (lookDir.x == 0 && lookDir.y == 1){
            Debug.Log("right");
            lookQuat = Quaternion.LookRotation(new Vector3(0,0,-1));
        }
        else if (lookDir.x == 1 && lookDir.y == 0)
        {
            Debug.Log("left");
            lookQuat = Quaternion.LookRotation(new Vector3(0, 0, 1));
        }
        else if(attachedRigid.velocity.normalized.magnitude > 0)
        {
            lookQuat = Quaternion.LookRotation(attachedRigid.velocity.normalized);
        }
        transform.localRotation = Quaternion.Slerp(transform.rotation, lookQuat, turnSpeed * Time.deltaTime);
        if (held != null)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                held.GetComponent<Rigidbody>().isKinematic = false;
                held.GetComponent<Collider>().enabled = true;
                held.SetParent(null);
                held = null;

            }
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button0) && Interactable != null)
        {
            //Debug.Log("player interacted");
            attachedRigid.velocity = Vector3.zero;
            Interactable.GetComponent<Interactable>().use();
        }



    }
}
