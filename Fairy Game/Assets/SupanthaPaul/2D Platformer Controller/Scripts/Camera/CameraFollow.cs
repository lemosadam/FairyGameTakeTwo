using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SupanthaPaul
{
	public class CameraFollow : MonoBehaviour
	{
	    [SerializeField]
		private Transform target;
		[SerializeField]
		private float smoothSpeed = 0.125f;
		public Vector3 offset;
		[Header("Camera bounds")]
		public Vector3 minCamerabounds;
		public Vector3 maxCamerabounds;


        private void FixedUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // clamp camera's position between min and max
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minCamerabounds.x, maxCamerabounds.x),
                Mathf.Clamp(transform.position.y, minCamerabounds.y, maxCamerabounds.y),
                Mathf.Clamp(transform.position.z, minCamerabounds.z, maxCamerabounds.z)
            );
        }

        public void SetTarget(Transform targetToSet)
        {
            target = targetToSet;
        }
    }
}
