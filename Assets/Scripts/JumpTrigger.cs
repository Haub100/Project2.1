using UnityEngine;
using System.Collections;

public class JumpTrigger : MonoBehaviour {

	public float JumpMagnitude = 20;

	public IEnumerator ControllerEnter2D(CharacterController2D controller)
	{
		yield return new WaitForSeconds (0.2f);
		controller.SetVerticalForce(JumpMagnitude);
	}

}
