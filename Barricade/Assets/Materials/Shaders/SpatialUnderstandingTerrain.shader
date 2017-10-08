// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

Shader "SpatialUnderstandingTerrain"
{
	Properties
	{
		_NoiseTex("Noise texture", 2D) = "black" {}
		_GrassTex("Grass (RGB)", 2D) = "green" {}
		_WallTex("Wall (RGB)", 2D) = "brown" {}
		_WaterTex("Water (RGB)", 2D) = "blue" {}
	}

		SubShader
	{
		Tags{ "RenderType" = "Opaque" }

		Pass
		{
			CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag

		#include "UnityCG.cginc"


			sampler2D _GrassTex;
			sampler2D _WallTex;
			sampler2D _WaterTex;

			struct V2F
			{
				float4 viewPos : SV_POSITION;
				float3 normal : NORMAL;
				float4 worldPos: TEXCOORD0;
			};


			// This is the vertex program.
			V2F vert(appdata_base v)
			{
				V2F o;

				o.viewPos = UnityObjectToClipPos(v.vertex);
				o.normal = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);

				return o;
			}

			fixed4 frag(V2F input) : SV_Target
			{
				float4 wpmodip;
				float4 wpmod = modf(input.worldPos, wpmodip);

				fixed4 col = tex2D(_GrassTex, input.worldPos);//float4(0,0,0,1);
				float3 normal = normalize(input.normal);

				if (abs(normal.y) < 0.2f)
				{
					col = tex2D(_WallTex, input.worldPos);
				}
				if (normal.y > 0.2f)
				{
					if (input.worldPos.y > -0.5f)
					{
						col = tex2D(_GrassTex, input.worldPos);
					}
					else
					{
						col = tex2D(_WaterTex, input.worldPos);
					}

				}
				else
				{
					col = float4(0, 0, 0, 0);
				}

				return col;
				}
				ENDCG
			}
		}
   FallBack "Diffuse"
}
