using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(VHSEffectRenderer), PostProcessEvent.AfterStack, "Lune Interactive/VHS Effects/VHS Effect")]
public sealed class VHSEffect : PostProcessEffectSettings
{
    [Tooltip("Any noise value under this is ignored.")]
    public FloatParameter NoiseLimit = new FloatParameter { value = 0.5f };
    [Tooltip("Scale the offset sampling.")]
    public FloatParameter DistortionOffset = new FloatParameter { value = 0.5f };
    [Tooltip("Noise Scale (in a uv sense).")]
    public FloatParameter NoiseScale = new FloatParameter { value = 0.5f };
    [Tooltip("Speed.")]
    public FloatParameter speed = new FloatParameter { value = 0.5f };
    [Tooltip("Power.")]
    public FloatParameter NoisePower = new FloatParameter { value = 0.5f };
    [Tooltip("Strength.")]
    public FloatParameter NoiseStrength = new FloatParameter { value = 0.5f };
    [Tooltip("RGB Separation.")]
    public Vector3Parameter RGBSeparation = new Vector3Parameter { value = new Vector3(0,0,0) };
    [Tooltip("Threshold or Smooth?")]
    public BoolParameter ThresholdOption = new BoolParameter { value = false };
    [Tooltip("Debug.")]
    public BoolParameter Debug = new BoolParameter { value = false };
}

public sealed class VHSEffectRenderer : PostProcessEffectRenderer<VHSEffect>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Lune Interactive/VHS Effects/VHS"));
        sheet.properties.SetFloat("_Strength", settings.NoiseLimit);
        sheet.properties.SetFloat("_Offset", settings.DistortionOffset);
        sheet.properties.SetFloat("_Scale", settings.NoiseScale);
        sheet.properties.SetFloat("_Speed", settings.speed);
        sheet.properties.SetFloat("_Power", settings.NoisePower);
        sheet.properties.SetFloat("_NoiseStrength", settings.NoiseStrength);
        sheet.properties.SetInt("_Debug", settings.Debug ? 1 : 0);
        sheet.properties.SetInt("_Step", settings.ThresholdOption ? 1 : 0);
        sheet.properties.SetVector("_Separation", (Vector4)settings.RGBSeparation);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}