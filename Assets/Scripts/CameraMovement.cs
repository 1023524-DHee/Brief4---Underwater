using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
	public float incrementTime;

	private float startTime;
	private bool gameStarted;

	private void Start()
	{
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
		{
			gameStarted = true;
		}

		if (gameStarted)
		{
			if (Time.time > startTime + incrementTime)
			{
				startTime = Time.time;
				cameraSpeed *= 1.2f;
			}

			transform.position += new Vector3(0f, cameraSpeed, 0f) * Time.deltaTime;
		}
    }
}
