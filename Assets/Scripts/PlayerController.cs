using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private Vector3 mousePosition;
    private Vector3 targetPosition;

	//float rotationSpeed = 180f;

	// Use this for initialization
	void Start () {
	

	}

	// Update is called once per frame
	void Update()
	{

		// Convert mouse position to world space coordinates
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = transform.position.z;
		targetPosition = Vector3.Lerp(transform.position, mousePosition, GameManager.instance.playerMoveSpeed * Time.deltaTime);


		// Player moves and faces toward mouse position
		transform.position = targetPosition;

		//float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;

        //Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		


	}
}