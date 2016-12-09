using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class WinCondition : MonoBehaviour
    {
		/**
		 * A method that is triggerd when there is a collision with the castle indicating a win condition
		 * @param other is the collider area
	 	 */ 
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {

                SceneManager.LoadScene("Win");

            }
        }
    }
}
