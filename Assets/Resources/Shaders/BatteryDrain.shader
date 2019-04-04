Shader "Unlit/BatteryDrain"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_BackColor("Used Color", color) = (1,1,1,1)
		_CurrentY("Current Y of effect", Range(-0.1,0.4)) = 0
		_EffectSize("Size of effect", float) = 2
		[HDR] _EmissionColor("Emission Color", color) = (0,0,0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
				float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _BackColor;
			float4 _EmissionColor;
			float _CurrentY;
			float _EffectSize;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex.xyz);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {

				return i.worldPos.y > _CurrentY ? _BackColor : (_BackColor + _EmissionColor);
            }
            ENDCG
        }
    }
}
