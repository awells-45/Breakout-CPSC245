using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(TapeFlakeRenderer), PostProcessEvent.AfterStack, "Lune Interactive/VHS Effects/Flakiness Effect")]
public sealed class TapeFlake : PostProcessEffectSettings
{
    [Tooltip("Power Curve.")]
    public FloatParameter ScreenFallOff = new FloatParameter { value = 2 };
    public FloatParameter XScale = new FloatParameter { value = 1 };
    public FloatParameter YScale = new FloatParameter { value = 1 };
    public FloatParameter TimeScale = new FloatParameter { value = 1 };
    [Range(0,1.0f)]
    public FloatParameter Threshold = new FloatParameter { value = 0.5f };


}

public sealed class TapeFlakeRenderer : PostProcessEffectRenderer<TapeFlake>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Lune Interactive/VHS Effects/TapeFlake"));
        sheet.properties.SetFloat("_Power", settings.ScreenFallOff);
        sheet.properties.SetFloat("_NoiseScaleX", settings.XScale);
        sheet.properties.SetFloat("_NoiseScaleY", settings.YScale);
        sheet.properties.SetFloat("_TimeScale", settings.TimeScale);
        sheet.properties.SetFloat("_Threshold", settings.Threshold);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}