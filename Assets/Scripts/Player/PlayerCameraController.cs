using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public float sensitivity = 15f;
    public float extremumX = 360f;
    public float extremumY = 60f;

    private float rotationY = 0, rotationX = 0;

    public void ChangeRotation(float xAxis, float yAxis)
    {
        rotationX = transform.localEulerAngles.y + xAxis * sensitivity;

        rotationY += yAxis * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -extremumY, extremumY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
