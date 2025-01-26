Shader "Custom/WaterShader"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" { }

		_YAmplitude ("YAmplitude", Float) = 0.01
		_YFrequency ("YFrequency", Float) = 10
		_YOffset ("YOffset", Float) = 0
		_YSpeed ("YSpeed", Float) = 1

		_XAmplitude ("YAmplitude", Float) = 0.005
		_XFrequency ("YFrequency", Float) = 15
		_XOffset ("XOffset", Float) = 0
		_XSpeed ("XSpeed", Float) = 1
	}
	SubShader
	{
		Blend SrcAlpha OneMinusSrcAlpha
		Tags { "DisableBatching" = "True" }
		Pass
		{
			ZTest Off
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			// Declarações de variáveis
			sampler2D _MainTex;
			float4 _DistortionStrength;
			float _YAmplitude;
			float _YFrequency;
			float _YOffset;
			float _YSpeed;
			float _XAmplitude;
			float _XFrequency;
			float _XOffset;
			float _XSpeed;

			// Função de vértice
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			// Função de fragmento
			half4 frag(v2f i) : SV_Target
			{
				// Coordenadas de textura normalizadas
				float time = _Time.y;

				float2 uv = i.uv;
				uv.y += (sin(uv.x * _YFrequency + (time + _YOffset) * +_YSpeed) + 1.0) / 2.0 * _YAmplitude;
				uv.x += (sin(uv.x * _XFrequency + (time + _XOffset) * +_XSpeed) + 1.0) / 2.0 * _XAmplitude;

				half4 col = tex2D(_MainTex, uv);
				col.a = 0.85;
				return col;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
