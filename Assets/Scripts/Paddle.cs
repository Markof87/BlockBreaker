using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    private bool autoPlay;
    private Ball ball;

	// Use this for initialization
	void Start () {

        autoPlay = false;
        ball = GameObject.FindObjectOfType<Ball>(); 

	}
	
	// Update is called once per frame
	void Update () {

        if (!autoPlay)
            MoveWithMouse();
        else
            AutoPlay();

	}


    void MoveWithMouse()
    {

        Time.timeScale = 1;
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1f, 15f);

        this.transform.position = paddlePos;

    }

    void AutoPlay()
    {

        Time.timeScale = 4;
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);

        this.transform.position = paddlePos;

    }

}
