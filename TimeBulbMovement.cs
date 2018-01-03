using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBulbMovement : MonoBehaviour {
    
    [SerializeField]
    float moveSpeed;
    GameObject timeTable;
    float timeTableRightBound;
    public bool move;
    Vector3 startPos;
    [SerializeField]
    float rightBoundOffset;
    [SerializeField]
    GameObject energy;

    void Start ()
    {
        timeTable = GameObject.FindGameObjectWithTag("TimeTableSprite");
        timeTableRightBound = timeTable.GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.localPosition;
        if (gameObject.tag == "Enemy")
        {
            moveSpeed = 4f;
            rightBoundOffset = -0.56f;
        }
        else if (gameObject.tag == "Player")
        {
            moveSpeed = 8f;
            rightBoundOffset = 0.83f;
        }
	}
	
	void FixedUpdate () {
        if(Input.GetKeyDown(KeyCode.T))
        {
            move = !move;
            energy.GetComponent<Energy>().move = move;
            Debug.Log("Bulb movement: " + move);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            move = false;
            transform.localPosition = startPos;
            /*if (gameObject.tag == "Player")
            {
                Debug.Log("Right bound: " + timeTableRightBound);
                Debug.Log("This local pos: " + transform.localPosition);
            }*/
        }

        if (move)
        {
            if (this.transform.localPosition.x <= timeTableRightBound * rightBoundOffset)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + (moveSpeed * Time.deltaTime), transform.localPosition.y, transform.localPosition.z);
            }
            else
            {
                move = false;
                energy.GetComponent<Energy>().move = move;

				Camera.main.GetComponent<Animator>().Play("Player Attack Cam");
			}
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            move = true;
        }
    }
}
