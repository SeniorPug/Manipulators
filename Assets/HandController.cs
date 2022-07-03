using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject rightClaw;
    public GameObject leftClaw;

    public GrabScript rightPoint;
    public GrabScript leftPoint;
    public GameObject grabbedObject;

    bool is_right = true; //if right hand or not
    void Start()
    {

    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetAxis("Mouse X") < 0 && transform.position.x > -15)
        {
            transform.position -= new Vector3(0.2f, 0, 0);
        }
        if (Input.GetAxis("Mouse X") > 0 && transform.position.x < 15)
        {
            transform.position += new Vector3(0.2f, 0, 0);
        }
        if (Input.GetAxis("Mouse Y") < 0 && transform.position.z > -15)
        {
            transform.position -= new Vector3(0, 0, 0.2f);
        }
        if (Input.GetAxis("Mouse Y") > 0 && transform.position.z < 15)
        {
            transform.position += new Vector3(0, 0, 0.2f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && transform.position.y > -5)
        {
            transform.position -= new Vector3(0, 0.5f, 0);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && transform.position.y < 5)
        {
            transform.position += new Vector3(0, 0.5f, 0);
        }
        if (!(Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1)))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                transform.Rotate(0, 0, 1);
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                transform.Rotate(0, 0, -1);
            }
        }
        if (Input.GetKey(KeyCode.Mouse2))
        {
            if (rightClaw.transform.localRotation.y < 0.41f)
            {
                rightClaw.transform.Rotate(0, 1, 0);
                leftClaw.transform.Rotate(0, -1, 0);
                rightPoint.grabbed = false;
                rightPoint.grabbedObject = null;
                leftPoint.grabbed = false;
                leftPoint.grabbedObject = null;
                if (grabbedObject != null)
                {
                    grabbedObject.transform.SetParent(null);
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                    grabbedObject.GetComponent<Rigidbody>().useGravity = true;
                }
                grabbedObject = null;
            }
        }
        else 
        {
            if (rightClaw.transform.localRotation.y > 0 && (!rightPoint.grabbed || !leftPoint.grabbed))
            {
                rightClaw.transform.Rotate(0, -1, 0);
                leftClaw.transform.Rotate(0, 1, 0);
                rightPoint.can_grab = leftPoint.can_grab = true;
            } else if (rightClaw.transform.localRotation.y <= 0)
            {
                rightPoint.can_grab = leftPoint.can_grab = false;
            }
        }
        if (rightPoint.grabbedObject == leftPoint.grabbedObject && rightPoint.grabbedObject != null)
        {
            grabbedObject = rightPoint.grabbedObject;
            grabbedObject.transform.SetParent(this.gameObject.transform);
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            grabbedObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

}
