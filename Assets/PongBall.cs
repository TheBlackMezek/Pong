using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour {

    public float ballVelocity = 5.0f;
    public float velocityIncreaseAmt = 0.5f;
    [Range(0.0f, 1.0f)]
    public float minStartVelX = 0.25f;
    public int pointsPerScore = 1;
    public float startWait = 2.0f;

    public Rigidbody body;
    public ScoreManager scoreManager;

    private Vector3 startPos;
    private float trueVel;

	
	void Start () {
        Invoke("SetRandVel", startWait);
        startPos = transform.position;
        trueVel = ballVelocity;
	}

    private void OnCollisionEnter(Collision collision)
    {
        trueVel += velocityIncreaseAmt;
        if(collision.gameObject.tag == "Paddle")
        {
            Vector3 dir = transform.position - collision.transform.position;
            dir.Normalize();
            body.velocity = dir * trueVel;
        }
        else if(collision.gameObject.tag == "ScoreWall1")
        {
            scoreManager.AddScoreP2(pointsPerScore);
            transform.position = startPos;
            SetRandVel();
        }
        else if (collision.gameObject.tag == "ScoreWall2")
        {
            scoreManager.AddScoreP1(pointsPerScore);
            transform.position = startPos;
            SetRandVel();
        }
        else
        {
            body.velocity = body.velocity.normalized * trueVel;
        }
    }

    private void SetRandVel()
    {
        trueVel = ballVelocity;
        Vector2 newVel = Random.insideUnitCircle.normalized;
        while(newVel.x < minStartVelX && newVel.x > -minStartVelX)
        {
            newVel = Random.insideUnitCircle.normalized;
        }
        body.velocity = newVel * trueVel;
    }


}
