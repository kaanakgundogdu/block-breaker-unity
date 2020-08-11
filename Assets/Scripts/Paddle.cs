using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Configuration Parameters
    [SerializeField] float screenWitdhUnits = 16f; //kameranın boyu 6 toplam boy yani y=12 . Aspect ratio 4:3 ise eni yani x= 16
    [SerializeField] float minimumX = 1f;
    [SerializeField] float maximumX = 15f;
    //cache the references
    GameSession gameSession;
    BallPos ball;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<BallPos>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse pozisyonu hesaplama= Input.mousePosition.x/Screen.width  * screenWitdhUnits
       
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minimumX, maximumX);
        transform.position = paddlePos;

    }

    private float GetXPos()
	{
        if ( gameSession.IsAutoPlayEnabled())
		{
            return ball.transform.position.x;
		}
        else
		{
            return Input.mousePosition.x / Screen.width * screenWitdhUnits;
        }
	}
}
