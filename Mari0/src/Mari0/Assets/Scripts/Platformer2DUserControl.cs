/*! 
 *  \brief     User Controller class
 *  \details   This class is used to control the character
 *  \author    Unity Technologies
 */

using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
		/**
	 	* A PlatformerCharacter2D type
		*/ 
        private PlatformerCharacter2D m_Character;

		/**
	 	* A bool type
		*/ 
        private bool m_Jump;

		/**
	 	* A method that triggers when the game is awoken
		*/ 
        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

		/**
	 	* A method that updates once per frame and deals with user input and button presses
		*/ 
        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }

		/**
	 	* A method that updates the character's position
		*/ 
        private void FixedUpdate()
        {
            // Read the inputs.
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, m_Jump);
            m_Jump = false;
        }
    }
}
