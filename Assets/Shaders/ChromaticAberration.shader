Shader "Custom/ChromaticAberration"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		
		[Header(Rouge)]
		_rX("Décalage X", Range(-0.5, 0.5)) = 0.0
		_rY("Décalage Y", Range(-0.5, 0.5)) = 0.0

		[Header(Vert)]
		_gX("Décalage X", Range(-0.5, 0.5)) = 0.0
		_gY("Décalage Y", Range(-0.5, 0.5)) = 0.0

		[Header(Bleu)]
		_bX("Décalage X", Range(-0.5, 0.5)) = 0.0
		_bY("Décalage Y", Range(-0.5, 0.5)) = 0.0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
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
			float _rX;
			float _rY;
			float _gX;
			float _gY;
			float _bX;
			float _bY;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 color = fixed4(1, 1, 1, 1);
				
				float2 r = i.uv + float2(_rX, _rY);
				float2 g = i.uv + float2(_gX, _gY);
				float2 b = i.uv + float2(_bX, _bY);

				color.r = tex2D(_MainTex, r).r;
				color.g = tex2D(_MainTex, g).g;
				color.b = tex2D(_MainTex, b).b;
				
				return color;
			}
			ENDCG
		}
	}
}
