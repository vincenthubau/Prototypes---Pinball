using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {

	public Transform ball;
	private Vector3 startingPosition;

	void Start () {
		startingPosition = ball.position;
	}
	
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Ball"){
			other.rigidbody.velocity = Vector3.zero;
			other.transform.position = startingPosition;
			GameManager.gameManager.SendMessage("LoseLife");
		}
	}

}
