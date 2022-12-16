using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 0f;
    
    void Update()
    {

    }
    void MouseCamera()
    {
        Vector2 input = MouseInput();
        transform.Rotate(Vector3.up * input.x * mouseSensitivity * Time.deltaTime);
    }
    public Vector2 MouseInput()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        return new Vector2(x, y);
    }
}
