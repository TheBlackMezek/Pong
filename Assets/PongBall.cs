using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour {

    public float ballVelocity = 5.0f;
    [Range(0.0f, 1.0f)]
    public float minStartVelX = 0.25f;
    public int pointsPerScore = 1;

    public Rigidbody body;
    public ScoreManager scoreManager;

    private Vector3 startPos;

	
	void Start () {
        SetRandVel();
        startPos = transform.position;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Paddle")
        {
            Vector3 dir = transform.position - collision.transform.position;
            dir.Normalize();
            body.velocity = dir * ballVelocity;
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
    }

    private void SetRandVel()
    {
        Vector2 newVel = Random.insideUnitCircle.normalized;
        while(newVel.x < minStartVelX && newVel.x > -minStartVelX)
        {
            newVel = Random.insideUnitCircle.normalized;
        }
        body.velocity = newVel * ballVelocity;
    }


}
