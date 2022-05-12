using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    public GameObject VideoElement;
    public GameObject BlackImage;

    public void Awake()
    {
        StartCoroutine(WaitForIntro());
    }

IEnumerator WaitForIntro()
    {
        yield return new WaitForSeconds(5.0f);
        AudioManager.Instance.Play("MenuMainNoDrums");
        Destroy(VideoElement);
        Destroy(BlackImage);
    }

}
