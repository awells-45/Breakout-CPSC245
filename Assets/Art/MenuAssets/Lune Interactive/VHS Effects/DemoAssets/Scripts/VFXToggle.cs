using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VFXToggle : MonoBehaviour
{
    public PostProcessVolume volume;

    private VHSEffect vhs;
    private PixelationEffect pix;
    private TapeFlake tape;
    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out vhs);
        volume.profile.TryGetSettings(out pix);
        volume.profile.TryGetSettings(out tape);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))vhs.enabled.value = !vhs.enabled.value;
        if (Input.GetKeyDown(KeyCode.Alpha2)) pix.enabled.value = !pix.enabled.value;
        if (Input.GetKeyDown(KeyCode.Alpha3)) tape.enabled.value = !tape.enabled.value;

        if (Input.GetKey(KeyCode.UpArrow)) pix.Pixels.value = Mathf.Clamp(pix.Pixels.value + 4,0,400);
        if (Input.GetKey(KeyCode.DownArrow)) pix.Pixels.value = Mathf.Clamp(pix.Pixels.value - 4, 0, 400);
        if (Input.GetKey(KeyCode.RightArrow)) tape.Threshold.value = Mathf.Clamp01(tape.Threshold.value + Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow)) tape.Threshold.value = Mathf.Clamp01(tape.Threshold.value - Time.deltaTime);
    }
}
