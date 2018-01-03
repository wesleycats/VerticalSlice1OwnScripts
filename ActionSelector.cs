using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelector : MonoBehaviour {

    private int index = 1;
    public bool finished = false;

    [SerializeField]
    private GameObject defendOption;
    public Sprite defendNonSelect;
    public Sprite defendSelect;

    [SerializeField]
    private GameObject attackOption;
    public Sprite attackNonSelect;
    public Sprite attackSelect;

    [SerializeField]
    private GameObject magicOption;
    public Sprite magicNonSelect;
    public Sprite magicSelect;

	[SerializeField]
	private GameObject enemyBulb;
	[SerializeField]
	private GameObject playerBulb;
	[SerializeField]
	private GameObject energy;
	[SerializeField]
	private GameObject lighting;

	[SerializeField]
    private float scaleValue;

    private Vector3 defendStartScale, attackStartScale, magicStartScale, defendScale, attackScale, magicScale;
    
    // Sets all the variables
    void Start () {
        defendStartScale = defendOption.transform.localScale;
        attackStartScale = attackOption.transform.localScale;
        magicStartScale = magicOption.transform.localScale;
        defendScale = defendStartScale;
        attackScale = attackStartScale;
        magicScale = magicStartScale;

        attackOption.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }

    void Update() {
        // Checks if the player chooses an option above
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && index < 3)
        {
            index--;
            if (index < 0)
            {
                index = 2;
            }
            CheckSelected();
        }

        // Checks if the player chooses an option down
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && index < 3)
        {
            index++;
            if (index > 2)
            {
                index = 0;
            }
            CheckSelected();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            index = 1;
            CheckSelected();
        }

        // Checks if the player presses enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            index = 3;
            CheckSelected();
			enemyBulb.GetComponent<TimeBulbMovement>().move = !enemyBulb.GetComponent<TimeBulbMovement>().move;
			playerBulb.GetComponent<TimeBulbMovement>().move = !playerBulb.GetComponent<TimeBulbMovement>().move;
			energy.GetComponent<Energy>().move = !energy.GetComponent<Energy>().move;
			lighting.GetComponent<Light>().color = lighting.GetComponent<Lighting>().startColor;
		}
    }

    // Checks which option is selected and increases its size to indicate it's selected
    // Also decreases the sizes of the not selected options
    void CheckSelected()
    {
        switch(index)
        {
            case 0:
                {
                    defendScale = new Vector3(scaleValue, scaleValue, scaleValue);
                    defendOption.GetComponent<SpriteRenderer>().sprite = defendSelect;

                    attackScale = attackStartScale;
                    attackOption.GetComponent<SpriteRenderer>().sprite = attackNonSelect;

                    magicScale = magicStartScale;
                    magicOption.GetComponent<SpriteRenderer>().sprite = magicNonSelect;
                }
                break;
            case 1:
                {

                    defendScale = defendStartScale;
                    defendOption.GetComponent<SpriteRenderer>().sprite = defendNonSelect;

                    attackScale = new Vector3(scaleValue, scaleValue, scaleValue);
                    attackOption.GetComponent<SpriteRenderer>().sprite = attackSelect;

                    magicScale = magicStartScale;
                    magicOption.GetComponent<SpriteRenderer>().sprite = magicNonSelect;
                }
                break;
            case 2:
                {
                    defendScale = defendStartScale;
                    defendOption.GetComponent<SpriteRenderer>().sprite = defendNonSelect;

                    attackScale = attackStartScale;
                    attackOption.GetComponent<SpriteRenderer>().sprite = attackNonSelect;

                    magicScale = new Vector3(scaleValue, scaleValue, scaleValue);
                    magicOption.GetComponent<SpriteRenderer>().sprite = magicSelect;
                }
                break;
            case 3:
                {
                    defendScale = defendStartScale;
                    defendOption.GetComponent<SpriteRenderer>().sprite = null;
                    attackScale = attackStartScale;
                    attackOption.GetComponent<SpriteRenderer>().sprite = null;
                    magicScale = magicStartScale;
                    magicOption.GetComponent<SpriteRenderer>().sprite = null;
                    finished = true;

                }
                break;
            default:
                {
                    defendScale = defendStartScale;
                    attackScale = attackStartScale;
                    magicScale = magicStartScale;
                }
                break;
        }
        defendOption.transform.localScale = defendScale;
        attackOption.transform.localScale = attackScale;
        magicOption.transform.localScale = magicScale;
    }
}
