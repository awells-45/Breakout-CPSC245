using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScreen : MonoBehaviour
{
    [Header("Screen Texture")]
    public float offsetAmount = 0.5f;
    public float offsetInterval = 1f;

    [Header("Light Settings")]
    public Vector2 angleMinMax = new Vector2(43f, 45f);

    public Renderer _renderer;
    public Light _light;


    private void Start() {
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker() {
        float totalOffset = 0f;
        while(true) {

            // Do screen texture offset
            totalOffset += offsetAmount;
            _renderer.material.SetTextureOffset("_MainTex", new Vector2(0, totalOffset));

            // Do random light angle
            _light.spotAngle = Random.Range(angleMinMax.x, angleMinMax.y);

            yield return new WaitForSeconds(offsetInterval);
        }
    }
}
