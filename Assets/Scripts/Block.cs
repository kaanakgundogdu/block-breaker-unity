using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class Block : MonoBehaviour
{
	//config params
	[SerializeField] AudioClip blockSounds,undreakableSound;
	[SerializeField] GameObject blockVfx;
	[SerializeField] Sprite[] hitSprites;

	//cached reference
	Level level;
	GameSession gamestatus;


	//State Var
	[SerializeField] int timesHit;


	private void Start()
	{
		gamestatus = FindObjectOfType<GameSession>();
		LevelDesign();

	}


	private void LevelDesign()
	{
		level = FindObjectOfType<Level>();
		if(tag == "Breakable")
		{
			level.CountBlocks();
		}
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(tag == "Breakable")
		{
			HandleHit();
		}

		else
		{
			UnbreakableSound();
		}

	}

	private void HandleHit()
	{
		int maxHits = hitSprites.Length + 1; 
		timesHit++;
		if (timesHit >= maxHits)
		{
			DestroyBlock();
		}
		else
		{
			ShowNextHitSprite();
		}
	}


	private void ShowNextHitSprite()
	{

		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] != null)
		{
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];

		}
		else
		{
			Debug.Log("Block Sprite is missing" + gameObject.name);
		}
	}

	private void DestroyBlock()
	{
		gamestatus.AddToScore();
		AudioSource.PlayClipAtPoint(blockSounds, Camera.main.transform.position);
		Destroy(gameObject);
		level.BlockDestoyed();
		TriggerVfx();

	}


	private void UnbreakableSound()
	{
		AudioSource.PlayClipAtPoint(undreakableSound, Camera.main.transform.position);

	}

	private void TriggerVfx()
	{
		GameObject sparkles = Instantiate(blockVfx, transform.position, transform.rotation);
		Destroy(sparkles, 2f);
	}

}
