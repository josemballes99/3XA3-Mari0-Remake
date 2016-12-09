using UnityEngine;
using System.Collections;

public class QuestionBlock : MonoBehaviour {

    /**
     * A SpriteRenderer type
     */
	private SpriteRenderer spriteRenderer;

    /**
    * A Sprite type
    */
	public Sprite emptyBlock;

	/**
     * Method to initalize the SpriteRenderer
     */
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

    /**
     * Method to check if Mario hits a question mark block and changes the block once hit
     * @param colisor The collision box of the block
     */
	void OnCollisionEnter2D(Collision2D colisor){
		if(colisor.gameObject.name.Equals("Mario") && colisor.gameObject.transform.position.y < gameObject.transform.position.y){
			spriteRenderer.sprite = emptyBlock;
		}
	}
}
