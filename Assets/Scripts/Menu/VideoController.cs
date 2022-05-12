using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    public GameObject VideoElement;


    public void Awake()
    {
        StartCoroutine(WaitForIntro());
    }

IEnumerator WaitForIntro()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(VideoElement);        
    }

}
