using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGestures : MonoBehaviour
{
    private Quaternion _centerAngle;
    private float _timeStamp;
    private bool? _reaction;
    private bool _right, _left, _up, _down;

    void Start ()
    {
        _timeStamp = 0;
        _centerAngle = GvrViewer.Instance.HeadPose.Orientation;
    }

    public bool? GetReaction()
    {
        bool? value = _reaction;
        _reaction = null;
        return value;
    }

    void Update()
    {
        if (_timeStamp < 1f)
        {
            CheckAngles();
            _timeStamp += Time.deltaTime;
        }
        else
        {
            _reaction = null;
            Reset();
        }
    }
    private void CheckAngles()
    {
        Quaternion posDiff = Quaternion.Inverse(_centerAngle)*GvrViewer.Instance.HeadPose.Orientation;
        if (posDiff.x > 0.1 && !_down)
            _down = true;
        else if (posDiff.x < -0.05 && !_up)
            _up = true;
        if (posDiff.y > 0.05 && !_right)
            _right = true;
        else if (posDiff.y < -0.05 && !_left)
            _left = true;
        CheckMovement();
    }

    private void CheckMovement()
    {
        if (_left && _right && !(_up && _down))
        {
            _reaction = false;
            Reset();
        }
        else if (_up && _down && !(_left && _right))
        {
            _reaction = true;
            Reset();
        }        
    }

    private void Reset()
    {
        _down = false;
        _up = false;
        _left = false;
        _right = false;
        _centerAngle = GvrViewer.Instance.HeadPose.Orientation;
        _timeStamp = 0;
    }
}
