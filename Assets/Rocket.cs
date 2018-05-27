using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody shipRigidBody;
    Vector3 centerOFMass;

    private float rotationCoeff = 3;


	// Use this for initialization
	void Start () {
        shipRigidBody = GetComponent<Rigidbody>();
        centerOFMass = new Vector3(0f, 0f, 0);
        //centerOFMass = shipRigidBody.centerOfMass;
        //shipRigidBody.centerOfMass = centerOFMass;
    }
	
	// Update is called once per frame
	void Update () {
        //print("Update");
        ProcessInput();

	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shipRigidBody.AddRelativeForce(Vector3.up);
            //shipRigidBody.centerOfMass = centerOFMass;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(rotationCoeff * Vector3.forward * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rotationCoeff  * -1*Vector3.forward * Time.deltaTime);
        }

    }


}

