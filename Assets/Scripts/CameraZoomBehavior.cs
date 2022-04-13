using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraZoomBehavior : MonoBehaviour
{
    private Camera _camera;
    [SerializeField]
    private Vector2 _refrenceAspectRatio;
    private Vector3 _camStartPos;
    private float _refRatio;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _refRatio = _refrenceAspectRatio.x / _refrenceAspectRatio.y;
        _camStartPos = transform.position;
    }

    private void Update()
    {
        double ratio = _refRatio / _camera.aspect;
        ratio = Math.Round(ratio, 4);

        Vector3 scalePosition = _camStartPos * (float)ratio;

        transform.position = scalePosition;
    }
}
