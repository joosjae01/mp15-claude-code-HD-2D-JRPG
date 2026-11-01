// 3D 조명(Main Light, 환경광)의 영향을 받는 스프라이트 셰이더
// SpriteRenderer, TilemapRenderer 공용
Shader "HD2D/SpriteLit"
{
    Properties
    {
        // SpriteRenderer 가 스프라이트 텍스처를 _MainTex 로 전달
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1, 1, 1, 1)
        _Cutoff ("Alpha Cutoff", Range(0, 1)) = 0.5
    }

    SubShader
    {
        Tags
        {
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "AlphaTest"
            "RenderType" = "TransparentCutout"
            "IgnoreProjector" = "True"
        }

        // flipX 시 뒷면이 되므로 양면 렌더링
        Cull Off

        HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

        TEXTURE2D(_MainTex);
        SAMPLER(sampler_MainTex);

        CBUFFER_START(UnityPerMaterial)
            float4 _MainTex_ST;
            half4 _Color;
            half _Cutoff;
        CBUFFER_END

        struct Attributes
        {
            float4 positionOS : POSITION;
            float2 uv : TEXCOORD0;
            half4 color : COLOR;
        };

        struct Varyings
        {
            float4 positionCS : SV_POSITION;
            float2 uv : TEXCOORD0;
            half4 color : COLOR;
        };

        Varyings Vert(Attributes input)
        {
            Varyings output;
            output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
            output.uv = TRANSFORM_TEX(input.uv, _MainTex);
            // SpriteRenderer 의 Color 와 머티리얼 Tint 곱
            output.color = input.color * _Color;
            return output;
        }

        // 텍스처 샘플링 및 투명 부분 잘라내기
        half4 SampleSprite(Varyings input)
        {
            half4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv) * input.color;
            clip(color.a - _Cutoff);
            return color;
        }
        ENDHLSL

        Pass
        {
            Name "UniversalForward"
            Tags { "LightMode" = "UniversalForward" }

            // 깊이 기록으로 땅 아래 부분 가림
            ZWrite On

            HLSLPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            half4 Frag(Varyings input) : SV_Target
            {
                half4 color = SampleSprite(input);

                // 빛의 방향은 무시, Main Light 색, 밝기와 위쪽 환경광만 반영
                Light mainLight = GetMainLight();
                half3 lighting = mainLight.color + SampleSH(half3(0, 1, 0));

                // 낮에는 원본 그림 색 유지 (최대 밝기 1)
                lighting = min(lighting, 1);

                return half4(color.rgb * lighting, 1);
            }
            ENDHLSL
        }

        // 깊이 텍스처용 (DOF 등 후처리)
        Pass
        {
            Name "DepthOnly"
            Tags { "LightMode" = "DepthOnly" }

            ZWrite On
            ColorMask R

            HLSLPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag

            half4 Frag(Varyings input) : SV_Target
            {
                SampleSprite(input);
                return 0;
            }
            ENDHLSL
        }
    }
}
