using UnityEngine;
using System;
using System.Collections;

public class AnimTrigger : MonoBehaviour {

  public float JumpMagnitude = 20;
    Animator animator;
	//Animation animation;
	//GameObject top;

	
  void Start () {
      animator = GetComponent<Animator>();
  }

  public IEnumerator ControllerEnter2D(CharacterController2D controller)
  {
		animator.SetTrigger("InCollider");
		Debug.Log (animator.GetBool("InCollider"));
		yield return new WaitForSeconds (0.5f);
    	controller.SetVerticalForce(JumpMagnitude);
		//yield return new WaitForSeconds (0.5f);
		//animator.SetBool("InCollider", false);
		//Debug.Log (animator.GetBool("InCollider"));
		
	}
	
  //// Update is called once per frame
  //void Update () {

  //}

  void OnTriggerEnter2D(Collider2D cubeTrigger)
  {
		/*if (cubeTrigger.gameObject.tag.Equals ("Player")) {
			//Debug.Log (animator.GetBool("InCollider"));
			animator.SetBool("InCollider", true);
			Debug.Log (animator.GetBool("InCollider"));
		}*/

  }

	void OnTriggerExit2D(Collider2D cubeTrigger)
	{
		/*if (cubeTrigger.gameObject.tag.Equals ("Player")) {
			//Debug.Log (animator.GetBool("InCollider"));
			yield WaitForSeconds(1);
			animator.SetBool("InCollider", false);
			Debug.Log (animator.GetBool("InCollider"));
		}*/
		
	}
	
}
