using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGestures : MonoBehaviour
{
    private List<Vector3> _angles;
    private Vector3 _centerAngle;
    private float _timeStamp;
    private bool? _reaction;

    // Use this for initialization
	void Start ()
    {
        _angles = new List<Vector3>();
        _timeStamp = 0;
        _centerAngle = GvrViewer.Instance.HeadPose.Orientation.eulerAngles;
    }

    public bool? GetReaction()
    {
        bool? value = _reaction;
        _reaction = null;
        return value;
    }
    // Update is called once per frame
    void Update()

    {
     if (_timeStamp < 0.8f)
        { 
            _angles.Add(GvrViewer.Instance.HeadPose.Orientation.eulerAngles);
        _timeStamp += Time.deltaTime;
        }   
    else
     {
         _reaction = null;
            CheckMovement();
        }
	}

    private void CheckMovement()
    {
        bool right = false, left = false, up = false, down = false;
        foreach (var angle in _angles)
        {
            if (angle.x < _centerAngle.x - 20 && !up)
                up = true;
            else if (angle.x > _centerAngle.x + 20 && !down)
                down = true;
            if (angle.y < _centerAngle.y -20 && !left)
                left = true;
            else if (angle.y > _centerAngle.y +20  && !right)
                right = true;
        }
        if (left && right && !(up && down))
        {
            _reaction = false;
            Debug.Log("nay");
        }
        if (up && down && !(left && right))
        {
            _reaction = true;
            Debug.Log("indeed");
        }
        Reset();
    }

    private void Reset()
    {
        _angles.Clear();
        _centerAngle = GvrViewer.Instance.HeadPose.Orientation.eulerAngles;
        _timeStamp = 0;
    }
}
