using UnityEngine;
using System.Collections;

public class TEMP_levelToComplete : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		Application.LoadLevel (2);
		Debug.Log ("UGH");
	}
}
