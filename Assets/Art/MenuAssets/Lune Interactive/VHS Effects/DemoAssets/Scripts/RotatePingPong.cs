using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePingPong : MonoBehaviour
{
    public float pingPongSpeed = 1f;
    public float xAngle = 5f;

    
    void LateUpdate() {
        transform.localEulerAngles = new Vector3(-Mathf.PingPong(Time.time * pingPongSpeed, xAngle), 0, 0);
    }
}
