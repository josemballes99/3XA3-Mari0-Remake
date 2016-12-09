using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
		/**
	 	* A transform type
		*/ 
        public Transform target;
		/**
	 	* A float type
		*/ 
        public float damping = 1;
		/**
	 	* A float type
		*/ 
        public float lookAheadFactor = 3;
		/**
	 	* A float type
		*/ 
        public float lookAheadReturnSpeed = 0.5f;
		/**
	 	* A float type
		*/ 
        public float lookAheadMoveThreshold = 0.1f;

		/**
	 	* A float type
		*/ 
        private float m_OffsetZ;

		/**
	 	* A Vector3 type
		*/ 
        private Vector3 m_LastTargetPosition;

		/**
	 	* A Vector3 type
		*/ 
        private Vector3 m_CurrentVelocity;

		/**
	 	* A Vector3 type
		*/ 
        private Vector3 m_LookAheadPos;

		/**
	 	* A method that starts the set up for the camera
		*/ 
        private void Start()
        {
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }


		/**
	 	* A method that updates once perframe and accelerates the camera to follow the player
		*/ 
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            newPos.y = transform.position.y;

            transform.position = newPos;
        }
    }
}
