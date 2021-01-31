// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/VertexColor" {
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
	}	
	Category
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 200
		SubShader
		{
			/* Outside Faces */
			Pass
			{
				Cull Back

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				sampler2D _MainTex;
				float4 _Color;

				struct Input {
					float4 vertex : POSITION;
					float4 color  : COLOR;
					float3 normal : NORMAL;
					float2 uv : TEXCOORD0;
				};

				struct v2f {
					float4 vertex : SV_POSITION;
					float3 normal : TEXCOORD1;
					float3 viewDir : TEXCOORD2;
					float4 color : COLOR;
				};

				v2f vert(Input v) {
					v2f o;

					o.vertex = UnityObjectToClipPos(v.vertex);
					o.normal = v.normal;
					o.color = v.color;
					o.viewDir = normalize(ObjSpaceViewDir(v.vertex));
					return o;
				}

				fixed4 frag(v2f i) : SV_TARGET{
					float4 c = i.color;
					c *= _Color;

					return c;
				}
				ENDCG
			}
		}
		Fallback "Transparent/VertexLit"
	}
}
