using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for the draining energy bar of igniculius
public class Energy : MonoBehaviour {

    Vector3 startSize;
    Vector3 startPos;
    [SerializeField]
    float scaleChange;
    public bool move;
    float moveSpeed;
    float posChange;

	void Start ()
    {
        transform.localPosition = new Vector3(0.2f, transform.localPosition.y, transform.localPosition.z);
        transform.localScale = new Vector3(0.7f, transform.localScale.y, transform.localScale.z);
        startSize = transform.localScale;
        startPos = transform.localPosition;
        move = false;
        scaleChange = -0.2f;
    }   
	
	void Update ()
    {
        moveSpeed = 2.67f * scaleChange;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            move = !move;
        }

        if (transform.localScale.x <= 0)
        {
            move = false;
        }

        if(move)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + (moveSpeed * Time.deltaTime), transform.localPosition.y, transform.localPosition.z);
            transform.localScale = new Vector3(transform.localScale.x + (scaleChange * Time.deltaTime), transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            move = false;
            transform.localPosition = startPos;
            transform.localScale = startSize;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            move = true;
        }
    }
}
