Shader "MD/Cobweb"
{
    Properties
    {
        [MainColor] _BaseColor ("Base Color", Color) = (1, 1, 1, 1)
        [MainTexture] _AlphaMap ("Alpha Map", 2D) = "white" {}
        _Smoothness ("Smoothness", Range(0, 1)) = 0.5
    }

    SubShader
    {
        Tags
        {
            "RenderPipeline" = "UniversalPipeline"
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
        }

        Pass
        {
            Name "UniversalForward"

            Tags
            {
                "LightMode" = "UniversalForward"
            }

            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            ZTest LEqual
            Cull Off

            HLSLPROGRAM

            #pragma target 3.0

            #pragma vertex Vert
            #pragma fragment Frag

            #pragma multi_compile_fog

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            CBUFFER_START(UnityPerMaterial)

                float4 _BaseColor;
                float4 _AlphaMap_ST;
                float _Smoothness;

            CBUFFER_END

            TEXTURE2D(_AlphaMap);
            SAMPLER(sampler_AlphaMap);

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS   : NORMAL;
                float2 uv         : TEXCOORD0;

                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float3 positionWS : TEXCOORD0;
                float3 normalWS   : TEXCOORD1;
                float2 uv         : TEXCOORD2;

                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_VERTEX_OUTPUT_STEREO
            };

            Varyings Vert(Attributes input)
            {
                Varyings output;

                UNITY_SETUP_INSTANCE_ID(input);
                UNITY_TRANSFER_INSTANCE_ID(input, output);

                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);

                VertexPositionInputs positionInput =
                    GetVertexPositionInputs(input.positionOS.xyz);

                VertexNormalInputs normalInput =
                    GetVertexNormalInputs(input.normalOS);

                output.positionCS = positionInput.positionCS;
                output.positionWS = positionInput.positionWS;
                output.normalWS = normalInput.normalWS;

                output.uv = TRANSFORM_TEX(
                    input.uv,
                    _AlphaMap
                );

                return output;
            }

            half4 Frag(Varyings input) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(input);
                UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);

                // --------------------------------------------------
                // Texture
                // --------------------------------------------------

                half alpha =
                    SAMPLE_TEXTURE2D(
                        _AlphaMap,
                        sampler_AlphaMap,
                        input.uv
                    ).r;

                alpha *= _BaseColor.a;

                // --------------------------------------------------
                // Normal
                // --------------------------------------------------

                float3 normalWS =
                    normalize(input.normalWS);

                // Make both sides of the cobweb light correctly
                normalWS =
                    normalize(
                        normalWS *
                        (dot(
                            normalWS,
                            GetWorldSpaceViewDir(input.positionWS)
                        ) < 0.0 ? -1.0 : 1.0)
                    );

                // --------------------------------------------------
                // Main Light
                // --------------------------------------------------

                Light mainLight =
                    GetMainLight();

                float NdotL =
                    saturate(
                        dot(
                            normalWS,
                            mainLight.direction
                        )
                    );

                float3 diffuse =
                    mainLight.color *
                    NdotL;

                // --------------------------------------------------
                // Ambient
                // --------------------------------------------------

                float3 ambient =
                    SampleSH(normalWS);

                // --------------------------------------------------
                // Specular
                // --------------------------------------------------

                float3 viewDir =
                    normalize(
                        GetWorldSpaceViewDir(
                            input.positionWS
                        )
                    );

                float3 halfDir =
                    normalize(
                        mainLight.direction +
                        viewDir
                    );

                float NdotH =
                    saturate(
                        dot(
                            normalWS,
                            halfDir
                        )
                    );

                float specularPower =
                    lerp(
                        8.0,
                        128.0,
                        _Smoothness
                    );

                float specular =
                    pow(
                        NdotH,
                        specularPower
                    );

                float3 specularColor =
                    mainLight.color *
                    specular *
                    _Smoothness;

                // --------------------------------------------------
                // Final Color
                // --------------------------------------------------

                float3 lighting =
                    ambient +
                    diffuse +
                    specularColor;

                float3 finalColor =
                    _BaseColor.rgb *
                    lighting;

                return half4(
                    finalColor,
                    alpha
                );
            }

            ENDHLSL
        }
    }

    FallBack Off
}