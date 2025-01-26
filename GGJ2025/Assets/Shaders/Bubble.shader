Shader "Custom/BubbleShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _TimeOffset ("TimeOffset", Float) = 0.0
        _DistortionStrength ("DistortionStrength", Vector) = (0.1, 0.1, 0.0, 0.0)
    }
    SubShader
    {
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
            float _TimeOffset;
            float4 _DistortionStrength;

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

                // Usando a variável global _Time diretamente
                float time = _Time.y; // _Time.y é o tempo global (segundos desde o início do jogo)

                // Manipula a posição do vértice para simular a flutuação e a mudança de tamanho
                // Animação de flutuação (movendo a bolha para cima e para baixo no eixo Y)
                float floatHeight = sin(time * 2.0) * 0.2;  // Animação de altura (senoide)
                // v.vertex.y += floatHeight;

                // Animação de expansão e contração (modificando a escala da bolha)
                float bubbleWidth  = 1.0 + _DistortionStrength.x * sin(time * 1.5); // Expansão e contração
                float bubbleHeight = 1.0 + _DistortionStrength.y * sin(time * 1.3); // Expansão e contração
                v.vertex.x *= bubbleWidth;
                v.vertex.y *= bubbleHeight;

                // Transformação para espaço de tela
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // Função de fragmento
            half4 frag(v2f i) : SV_Target
            {
                // Coordenadas de textura normalizadas
                half4 col = tex2D(_MainTex, i.uv);  // Aplica a textura na bolha
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
