Shader "Hidden/Lune Interactive/VHS Effects/Pixelation"
{
	HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

	TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);


	
	float _Scale;
	float4 Frag(VaryingsDefault i) : SV_Target
	{


		float2 nUVs = i.texcoord * _Scale;
		nUVs = floor(nUVs)/ _Scale;
		
		float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, nUVs);


		return color;
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