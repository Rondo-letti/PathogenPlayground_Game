using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private Vector3 mousePosition;
	private float moveSpeed = 3f;
    private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
        
        // Convert mouse position to world space coordinates
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        targetPosition = Vector3.Lerp(transform.position, mousePosition, moveSpeed * Time.deltaTime);
    
        
        // Player moves toward mouse position
        transform.position = targetPosition;


	}
}