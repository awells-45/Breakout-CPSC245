using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerper : MonoBehaviour
{
    public Transform[] _positions;
    private Vector3 _tPos;
    private Quaternion _tRot;
    private float _cTime = 0;
    //private int _direction = -1;
    private int _index = 0;
    public float _speed = 1;
    // Start is called before the first frame update
    public bool _smooth = false;

    private void Start()
    {

        _tPos = transform.position;
        _tRot = transform.rotation;
    }
    public void Toggle()
    {
        _index += 1;
        if (_index > _positions.Length - 1)
        {
            _index = 0;
        }

        _cTime = 0;
        _tPos = transform.position;
        _tRot = transform.rotation;
    }
    float GetSmoothedAlpha(float alpha)
    {
        return alpha * alpha * (3.0f - 2.0f * alpha);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Toggle();
        }
        _cTime += Time.deltaTime * _speed;
        _cTime = Mathf.Clamp(_cTime, 0, 1);

        float alpha = (_smooth ? GetSmoothedAlpha(_cTime) : _cTime);
        transform.position = Vector3.Lerp(_tPos, _positions[_index].position, alpha);
        transform.rotation = Quaternion.Lerp(_tRot, _positions[_index].rotation, alpha);
        
    }
}
