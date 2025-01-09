using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2f;  // Mouse sensitivity
    private bool isDragging = false;
    private Vector3 lastMousePosition;

    void Update()
    {
        Vector3 delta = Vector3.zero;

        // Right-click (rotate)
        if (Input.GetMouseButtonDown(1)) // Right click pressed
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(1)) // Right click released
        {
            isDragging = false;
        }

        if (isDragging)
        {
            delta = Input.mousePosition - lastMousePosition;
            float rotationX = -delta.y * sensitivity;  // Invert Y-axis rotation
            float rotationY = delta.x * sensitivity;

            transform.eulerAngles += new Vector3(rotationX, rotationY, 0);
        }

        // Middle button (panning)
        if (Input.GetMouseButton(2)) // Middle mouse button held down
        {
            delta = Input.mousePosition - lastMousePosition;
            Vector3 pan = new Vector3(-delta.x, -delta.y, 0) * sensitivity * 0.01f;
            transform.Translate(pan, Space.Self);
        }

        lastMousePosition = Input.mousePosition; // Update last position
    }
}
