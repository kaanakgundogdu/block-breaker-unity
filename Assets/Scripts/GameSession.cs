using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System.Security.Cryptography;

public class GameSession : MonoBehaviour
{
    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1;

    [SerializeField] 
    int pointsPerBlockDestroyed = 10;

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    bool isAutoplayEnabled;

    // Skor tutma
    [SerializeField] int currentscore = 0;


	private void Awake()
	{
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
		{
            gameObject.SetActive(false);
            Destroy(gameObject);
		}
		else
		{
            DontDestroyOnLoad(gameObject);
		}
	}


	void Start()
    {
        scoreText.text = currentscore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
	{
        currentscore = currentscore + pointsPerBlockDestroyed;
        scoreText.text = currentscore.ToString();

    }

    //Başlangıçta resetlemek için
    public void DestroyOnStart()
	{
        Destroy(gameObject);
	}

    public bool IsAutoPlayEnabled()
	{
        return isAutoplayEnabled;
	}

}
