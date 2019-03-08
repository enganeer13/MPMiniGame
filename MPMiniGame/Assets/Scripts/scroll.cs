using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
	public float speed = 10f;
	private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
		startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		//replace Time.deltaTime with Time.time to have the camera continuously accelerate
		transform.position = transform.position + Vector3.right * speed * Time.deltaTime ; 
    }
}
