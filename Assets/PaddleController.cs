using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public float sensitivity = 1.0f;
    public float minPosY = -5.0f;
    public float maxPosY = 5.0f;

    [Range(1, 2)]
    public int player = 1;


    private void Update()
    {
        float moveAmt = 0.0f;
        if(player == 1)
        {
            moveAmt = Input.GetAxis("Player1");
        }
        else if(player == 2)
        {
            moveAmt = Input.GetAxis("Player2");
        }

        Vector3 newPos = transform.position;
        newPos.y = Mathf.Clamp(newPos.y + moveAmt * Time.deltaTime * sensitivity,
                               minPosY,
                               maxPosY);
        
        transform.position = newPos;
    }

}
