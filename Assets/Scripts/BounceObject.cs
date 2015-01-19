using UnityEngine;
using System.Collections;

public class BounceObject : MonoBehaviour {
	public int scoreValue = 10;

	public float explosionStrength = 100.0f;

	void OnCollisionEnter(Collision other){
		animation.Play();
		other.rigidbody.AddExplosionForce(explosionStrength, this.transform.position, 5);
	}

	void OnCollisionExit(Collision other){
		ScoreManager.score += scoreValue;
	}
}
