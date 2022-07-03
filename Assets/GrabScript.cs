using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    public bool grabbed = false;
    public bool can_grab = false;
    public GameObject grabbedObject;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grabable" && can_grab)
        {
            grabbed = true;
            grabbedObject = collision.gameObject;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == grabbedObject)
        {
            grabbed = false;
            grabbedObject = null;
        }
    }
}
