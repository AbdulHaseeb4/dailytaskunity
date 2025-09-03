using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float XMove;
    private float YMove;
    private float XRotation;
    [SerializeField] private Transform PlyaerBody;
    public Vector2 LockAxis;
    public float Sensitivity = 20f;

    [Header("Smoothness Settings")]
    public float smoothTime = 0.05f;
    private float currentXRotation;
    private float currentXVelocity;
    private float currentYRotation;
    private float currentYVelocity;

    void Update()
    {
        XMove = LockAxis.x * Sensitivity * Time.deltaTime;
        YMove = LockAxis.y * Sensitivity * Time.deltaTime;

        // Target rotation values
        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        // Smoothly interpolate camera (vertical rotation)
        currentXRotation = Mathf.SmoothDamp(currentXRotation, XRotation, ref currentXVelocity, smoothTime);

        // Smoothly interpolate body (horizontal rotation)
        currentYRotation = Mathf.SmoothDamp(currentYRotation, PlyaerBody.localEulerAngles.y + XMove, ref currentYVelocity, smoothTime);

        // Apply to transforms
        transform.localRotation = Quaternion.Euler(currentXRotation, 0f, 0f);
        PlyaerBody.rotation = Quaternion.Euler(0f, currentYRotation, 0f);
    }
}
