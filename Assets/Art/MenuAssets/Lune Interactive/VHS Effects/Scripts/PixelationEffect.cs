using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PixelationRenderer), PostProcessEvent.AfterStack, "Lune Interactive/VHS Effects/Pixelate Effect")]
public sealed class PixelationEffect : PostProcessEffectSettings
{
    [Tooltip("Pixel Ratio.")]
    public IntParameter Pixels = new IntParameter { value = 100 };


}

public sealed class PixelationRenderer : PostProcessEffectRenderer<PixelationEffect>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Lune Interactive/VHS Effects/Pixelation"));
        sheet.properties.SetFloat("_Scale", settings.Pixels);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}