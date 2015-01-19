using UnityEngine;
using System.Collections;

public class PullSpring : MonoBehaviour {

	public string inputButtonName = "Pull";
	public float distance = 50f;	//To modify depending on the board
	public float speed = 1f;		//To modify depending on the board
	public float power = 2000f;		//To modify depending on the board
	public GameObject ball;

	private bool ready = false;
	private bool fire = false;
	private float moveCount = 0f; 

	// Use this for initialization
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Ball"){
			ready = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton(inputButtonName)){
			if(moveCount < distance){
				transform.Translate(0, -speed * Time.deltaTime, 0);		//Axis may need changes
				moveCount += speed * Time.deltaTime;
				fire = true;
			}
		}
		else if(moveCount >0){
			if(fire && ready){
				ball.transform.TransformDirection(Vector3.forward * 10);
				ball.rigidbody.AddForce(0, 0, moveCount * power);
				fire = false;
				ready = false;
			}
			transform.Translate(0, 20 * Time.deltaTime, 0);				//Axis may need changes
			moveCount -= 20 * Time.deltaTime;
		}

		if(moveCount <= 0){
			fire = false;
			moveCount = 0;
		}

	}
}
