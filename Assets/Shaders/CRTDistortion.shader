﻿Shader "Custom/CRTDistortion"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_DisplacementTex ("Distortion Texture", 2D) = "white" {}
		_Strength ("Strength", Float) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _DisplacementTex;
			fixed _Strength;

			float4 frag (v2f_img i) : COLOR
			{
				half2 n = tex2D(_DisplacementTex, i.uv);
				half2 d = n * 2 - 1;

				i.uv += d * _Strength;
				i.uv = saturate(i.uv);

				float4 c = tex2D(_MainTex, i.uv);
				return c;
			}

			ENDCG
		}
	}
}
