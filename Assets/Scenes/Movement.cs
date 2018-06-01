using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Movement : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(0,50,0);

    [Range(0f, 1f)][SerializeField] float movementFactor;

    private Vector3 startingPosition;
    private Vector3 offset;

    //in seconds
    [SerializeField] float period = 10f;

    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (period <= Mathf.Epsilon) { return;  }

        offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;

        float cycles = Time.time / period;

        float rawSinWave = Mathf.Sin(cycles * 2 * Mathf.PI);

        movementFactor = rawSinWave / 2f + 0.5f;
	}
}
