﻿using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {


	void Start () 
	{
	
	}
	
	public void PlayerHitCheckpoint()
	{

	}

	private IEnumerator PlayerHitCheckpointCo(int bonus)
	{
		yield break;
	}

	public void PlayerLeftCheckpoint()
	{

	}

	public void SpawnPlayer(Player player)
	{
		player.RespawnAt (transform);
	}

	public void AssignObjectToCheckpoint()
	{

	}


}
