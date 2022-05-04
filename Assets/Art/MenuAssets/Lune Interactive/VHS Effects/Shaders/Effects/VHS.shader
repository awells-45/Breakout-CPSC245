Shader "Hidden/Lune Interactive/VHS Effects/VHS"
{
	HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

	TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	float _Strength;
	float _Offset;
	float _Scale;
	float _Speed;
	float _Power;
	float4 _Separation;
	float _NoiseStrength;
	int _Step;
	int _Debug;

	float random(float2 st) 
	{
		return frac(sin(dot(st.xy,float2(17.59898, 49.233)))* 43758.57453123);
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

	float4 Frag(VaryingsDefault i) : SV_Target
	{


		float s = (pow(abs(noise(float2(0, i.texcoord.y * _Scale + _Time.y * _Speed))), _Power) * _NoiseStrength);
		// some large number, we do this in order to not branch
		float v =  clamp((s - _Strength) * 10000000,0,1);
		v = lerp(s, v, _Step);
		// because we dont want a branch
		float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + float2(v * _Offset, 0));
		float colorR = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + float2(v * _Offset, 0) * _Separation.r).r;
		float colorG = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + float2(v * _Offset, 0) * _Separation.g).g;
		float colorB = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord + float2(v * _Offset, 0) * _Separation.b).b;
		
		float l = clamp(length(_Separation) * 10000000, 0, 1);
		color = lerp(color, float4(colorR, colorG, colorB, color.a), l);

		return lerp(color,v, _Debug);
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