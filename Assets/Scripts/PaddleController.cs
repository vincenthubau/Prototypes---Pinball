using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	public float restPosition = 0f;
	public float pressedPosition = 45f;
	public float flipperStrenght = 10f;
	public float flipperDamper = 1f;
	public string inputButtonName = "LeftPaddle";

	private JointLimits limits;

	void Awake(){
		hingeJoint.useSpring = true;

		limits = hingeJoint.limits;
	}

	// Update is called once per frame
	void Update () {
		JointSpring spring = new JointSpring();
		hingeJoint.spring = spring;
		spring.spring = flipperStrenght;
		spring.damper = flipperDamper;

		if(Input.GetButton(inputButtonName)){
			spring.targetPosition = pressedPosition;
		}
		else{
			spring.targetPosition = restPosition;
		}
		hingeJoint.spring = spring;
		hingeJoint.useLimits = true;
		limits.min = restPosition;
		limits.max = pressedPosition;
		hingeJoint.limits = limits;
	}
}
