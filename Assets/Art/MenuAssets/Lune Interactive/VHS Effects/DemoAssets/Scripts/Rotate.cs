using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed = 5f;


    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.smoothDeltaTime, 0f);
    }
}
