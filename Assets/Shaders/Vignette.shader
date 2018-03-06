Shader "Custom/Vignette"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
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

			fixed4 frag (v2f i) : SV_Target
			{
				float2 texCoord = i.uv;
				half4 color = tex2D(_MainTex, i.uv);

				texCoord -= 0.5;
				float vignette = 1.0 - pow(dot(texCoord, texCoord), 1);
				vignette = pow(vignette, 5);
				
				color *= vignette;
				return color + float4(0, 0.0013, 0.0026, 0);
			}
			ENDCG
		}
	}
}
