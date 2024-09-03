using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    public float rotationSpeed = 100;
    [Range(0, 1)]
    public float decelerationRate = 0.95f; // This value should be between 0 and 1

    private float currentRotationX;
    private float currentRotationY;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, -currentRotationX * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right, currentRotationY * rotationSpeed * Time.deltaTime);

        // Decrease the rotation speed over time
        currentRotationX *= decelerationRate;
        currentRotationY *= decelerationRate;
    }

    public void RotateObject(float x, float y)
    {
        currentRotationX = x;
        currentRotationY = y;
    }
}
