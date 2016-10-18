using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;

        void Update()
        {
            if (target.position.x > 5.8)    // Camera only follows player after a certain point, center of camera is initially at x = 5.8
            {
                transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
            }
        }
    }
}
