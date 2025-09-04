using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedTouchField _FixedTouchField;
    public CameraLook _CameraLook;
    public Player _player;
    public FixedButtons _FixedButton;
    void Start()
    {
        
    }


    void Update()
    {
        _CameraLook.LockAxis = _FixedTouchField.TouchDist;
        _player.isPressed = _FixedButton.Pressed;
    }
}
