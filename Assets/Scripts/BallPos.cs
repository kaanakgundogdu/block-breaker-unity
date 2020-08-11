using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPos : MonoBehaviour
{
    //Conifg parameters
    [SerializeField] Paddle paddle;

    [SerializeField] float xForce=2f;
    [SerializeField] float yForce=20f;
    [SerializeField] float randomFactor= 0.2f;

    //Muuuusiki
    [SerializeField] AudioClip[] ballSounds;
    AudioSource myAudioSource;
    Rigidbody2D myrigidBody;

    //state
    Vector2 paddleToBallVec;




    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        paddle= FindObjectOfType<Paddle>();
        paddleToBallVec = transform.position - paddle.transform.position ;
        myAudioSource = GetComponent<AudioSource>();
        myrigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallThePaddle();
            LaunchOnMouse();
        }
    }

    private void LaunchOnMouse()
	{
        if(Input.GetMouseButtonDown(0))
		{
            //Olduğu yerde beklemesinden ziyade harekete geçiren yeni vektör oluşturuyoruz.
            myrigidBody.velocity = new Vector2(xForce, yForce);
            hasStarted = true;

        }
    }

    private void LockBallThePaddle()
	{
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVec;
    }


	private void OnCollisionEnter2D(Collision2D collision)
	{
        Vector2 velocityTweak = new Vector2(
            (Random.Range(0f,randomFactor)),
            (Random.Range(0f,randomFactor)));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myrigidBody.velocity += velocityTweak;
        }
	}



}
