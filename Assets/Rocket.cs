using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody shipRigidBody;
    Vector3 centerOFMass;

    AudioSource audioSource;

    private float rotationCoeff = 15;
    private float accelerationCoeff = 11;


    // Use this for initialization
    void Start () {
        shipRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        //centerOFMass = new Vector3(0f, 0f, 0);
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
        Thrust();
        Rotate();
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shipRigidBody.AddRelativeForce(accelerationCoeff * Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //shipRigidBody.AddRelativeForce(accelerationCoeff * Vector3.up);
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        shipRigidBody.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(rotationCoeff * Vector3.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rotationCoeff * -1 * Vector3.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            //transform.Rotate(rotationCoeff * Vector3.right * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
           // transform.Rotate(rotationCoeff * -1 * Vector3.right * Time.deltaTime);
        }

        shipRigidBody.freezeRotation = false;
    }

}

