using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float smoothSpeed = 0.125f;
    public Vector3 cameraOffset;

    public void FixedUpdate() 
    {
        Vector3 desiredPosition = target.transform.position + cameraOffset; 
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        
        // Not necessary unless doing 3D
        //transform.LookAt(target.transform.position);
    }
}
