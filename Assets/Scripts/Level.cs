using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;
	//Block kalmayınca sonraki sahneye gitsin.
	SceneChanger sceneChange;

	private void Start()
	{
		sceneChange = FindObjectOfType<SceneChanger>();
	}

	public void CountBlocks()
	{
		breakableBlocks++;
	}

	public void BlockDestoyed()
	{
		breakableBlocks--;
		if(breakableBlocks <= 0)
		{
			sceneChange.SceneLoader();
		}
	}


}
