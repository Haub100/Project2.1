using UnityEngine;
using System.Collections;

public class TEMP_menuToLevel : MonoBehaviour {

	public GameObject movie;
	public MovieTexture movieTexture;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.mainTexture = movieTexture;
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator OnMouseDown(){
		movie.SetActive(true);
		movieTexture.Play ();
		yield return new WaitForSeconds(30);
		Application.LoadLevel (1);
	}

}
