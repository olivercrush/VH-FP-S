Shader "Custom/Scanlines"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_MaskTex ("Mask Texture", 2D) = "white" {}
		_maskBlend("Mask Blending", Float) = 0.5
		_maskSize("Mask Size", Float) = 1
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

			uniform sampler2D _MainTex;
			uniform sampler2D _MaskTex;

			fixed _maskBlend;
			fixed _maskSize;

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

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			fixed4 frag (v2f_img i) : COLOR
			{
				fixed4 mask = tex2D(_MaskTex, i.uv * _maskSize + unity_DeltaTime);
				fixed4 base = tex2D(_MainTex, i.uv);
				return lerp(base, mask, _maskBlend);
			}

			ENDCG
		}
	}
}
