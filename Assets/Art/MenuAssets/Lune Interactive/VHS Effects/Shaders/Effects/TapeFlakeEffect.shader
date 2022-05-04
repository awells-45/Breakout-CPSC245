Shader "Hidden/Lune Interactive/VHS Effects/TapeFlake"
{
	HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

	TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);


	float random(float2 st)
	{
		return frac(sin(dot(st.xy, float2(17.59898, 49.233))) * 43758.57453123);
	}

	float noise(float2 st)
	{
		float2 i = floor(st);
		float2 f = frac(st);

		// Sample the noise.
		float a = random(i);
		float b = random(i + float2(1.0, 0.0));
		float c = random(i + float2(0.0, 1.0));
		float d = random(i + float2(1.0, 1.0));

		// Interpolate for the alpha
		float2 u = f * f * (3.0 - 2.0 * f);

		// lerp percentages
		return lerp(a, b, u.x) + (c - a) * u.y * (1.0 - u.x) + (d - b) * u.x * u.y;
	}

	float _Power;
	float _NoiseScaleX, _NoiseScaleY;
	float _TimeScale;
	float _Threshold;
	float4 Frag(VaryingsDefault i) : SV_Target
	{

		float vScale = pow(abs(1 - i.texcoord.y),_Power);
		float noiseValue = vScale * noise(i.texcoord.xy * float2(_NoiseScaleX,_NoiseScaleY) * vScale + float2(_Time.y * _TimeScale,0)) * noise(i.texcoord.xy * float2(_NoiseScaleX, _NoiseScaleY * 0.5) * 0.5 + float2(_Time.y * _TimeScale, _Time.y * _TimeScale * 0.1) * vScale * 2);
		
		// this is wild when you use _TimeScale = 1 and a high NoiseScaleX value
		//noiseValue = vScale * noise(i.texcoord.xy * float2(_NoiseScaleX, 0) + float2(_Time.y * _TimeScale, 0)) * noise(i.texcoord.xy * float2(_NoiseScaleX, 0) * 1+ float2(_Time.y * _TimeScale, 0) * 2);

		float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);


		return lerp(color,1, step(_Threshold, noiseValue));
	}

	ENDHLSL

	SubShader
	{
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			HLSLPROGRAM

				#pragma vertex VertDefault
				#pragma fragment Frag

			ENDHLSL
		}
	}
}