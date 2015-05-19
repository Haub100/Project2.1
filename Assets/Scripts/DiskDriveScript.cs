using UnityEngine;
using System.Collections;

public class DiskDriveScript : MonoBehaviour 
{
	public GameObject disk;
	private BoxCollider2D boxcollider;

	public void Awake()
	{
		boxcollider = disk.GetComponent<BoxCollider2D> ();
	}

	public void Update()
	{
		if (this.transform.position.z > 12.0f) 
		{
			Debug.Log ("Disabled");
			boxcollider.enabled = false;
		}
		else
		{
			Debug.Log ("Enabled");
			boxcollider.enabled = true;
		}
	}
}
