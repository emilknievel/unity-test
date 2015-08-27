using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody2D rb;

	private float maxSpeed = 200f;
	private float acceleration = 100f;
	private float inputX = 0f;
	private float inputY = 0f;
	private Vector2 speed = new Vector2 ();

	private float startPosY = -0.72f;
	private float minPosX = -1.2f;
	private float maxPosX = 1.2f;
	private float minPosY = -0.6f;
	private float maxPosY = 0.6f;

	// Use this for initialization
	void Start ()
	{

	}

	void Update ()
	{
		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0.025f, 0, dist)
		).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0.975f, 0, dist)
		).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 0.025f, dist)
		).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 0.975f, dist)
		).y;
		
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp (transform.position.y, topBorder, bottomBorder),
			transform.position.z
		);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		rb.velocity = new Vector2 (0f, 0f);
		
		inputX = Input.GetAxis ("Horizontal");
		inputY = Input.GetAxis ("Vertical");

		speed.Set (inputX * Time.deltaTime * acceleration, inputY * Time.deltaTime * acceleration);


		if (rb.velocity.x > -maxSpeed && speed.x < 0f ||
			rb.velocity.x < maxSpeed && speed.x > 0f || 
			rb.velocity.y > -maxSpeed && speed.y < 0f ||
			rb.velocity.y < maxSpeed && speed.y > 0f)

			rb.velocity = speed;
	}
}