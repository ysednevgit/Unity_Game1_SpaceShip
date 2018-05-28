using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    Rigidbody shipRigidBody;
    Vector3 centerOFMass;

    AudioSource audioSource;
    [SerializeField] AudioClip audio_mainEngine;
    [SerializeField] AudioClip audio_win;
    [SerializeField] AudioClip audio_death;


    [SerializeField] float rotationCoeff = 15;
    [SerializeField] float accelerationCoeff = 11.5f;

    enum State { Alive, Dying, Transcending };

    [SerializeField] State state = State.Alive;


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

    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly": //
                break;
            case "Finish":
                state = State.Transcending;
                audioSource.PlayOneShot(audio_win);
                Invoke("LoadNextScene", 2f);
                break;
            default:
                Die();
                break;
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Die()
    {
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(audio_death);
        Invoke("RestartScene", 3f);
    }

    private void ProcessInput()
    {
        if (state == State.Transcending || state == State.Dying)
        {
            return;
        }

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
            audioSource.PlayOneShot(audio_mainEngine);
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

