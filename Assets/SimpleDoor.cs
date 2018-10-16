using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoor : MonoBehaviour {
    public float timeOfAnimation,speed;
    public Transform doorobj;
    public Vector3 dir;
    float timer = 0;
    public bool open;
    public bool Open
    {
        set
        {
            //Debug.Log("seting Open");
            open = value;
            timer = 0;
            //Debug.Log("seting Open 2");
            //StopAllCoroutines();           
            StartCoroutine("MoveDoor");
            //Debug.Log("seting Open 3");

        }
        get
        {
            return open;
        }
    }

    IEnumerator MoveDoor()
    {
        Debug.Log(timer);
        while(timer < timeOfAnimation) {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (open)
            {
                //Vector3.Lerp()
                doorobj.Translate(dir * speed * Time.deltaTime);
            }
            else
            {
                doorobj.Translate(-dir * speed * Time.deltaTime);
            }
            yield return new WaitForSeconds(.1f);
        }
        Debug.Log("Done");
        //yield return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Open = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Open = false;
    }
}
