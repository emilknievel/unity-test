using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Rigidbody2D rb;
	private float maxSpeed = 200f;
	private float acceleration = 100f;
	private float inputX = 0f;
	private float inputY = 0f;
	private Vector2 speed = new Vector2();

	// Use this for initialization
	void Start () 
	{
		//rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		rb.velocity = new Vector2(0f, 0f);

		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");

		speed.Set(inputX * Time.deltaTime * acceleration, inputY * Time.deltaTime * acceleration);

		if (rb.velocity.x > -maxSpeed && speed.x < 0f ||
		    rb.velocity.x < maxSpeed && speed.x > 0f ||

		    rb.velocity.y > -maxSpeed && speed.y < 0f ||
		    rb.velocity.y < maxSpeed && speed.y > 0f)
		{
			rb.velocity = speed;
		}

		Debug.Log(speed);
	}
}
