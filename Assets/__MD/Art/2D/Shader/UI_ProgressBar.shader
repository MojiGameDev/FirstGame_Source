Shader "ProgressBar"
{
	Properties
	{
		[HideInInspector]_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		[HideInInspector]_MainTex ("Particle Texture", 2D) = "white" {}
		[HideInInspector]_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
		_MainTexture("MainTexture", 2D) = "white" {}
		_Emision("Emision", Float) = 1
		_ProgressBar("ProgressBar", Range( 0 , 1)) = 1
		_DissolveEdge("DissolveEdge", Range( 0 , 1)) = -0.49
		_Noise("Noise", 2D) = "white" {}
		[Toggle(_MASK_OVER_ON)] _Mask_over("Mask_over", Float) = 0
		_OverMask("OverMask", 2D) = "white" {}
		_ColorMask("ColorMask", Color) = (1,1,1,1)
		_OverMaskEmission("OverMaskEmission", Float) = 0.3
		_OverMask_Speed_X("OverMask_Speed_X", Range( -1 , 1)) = 0
		_OverMask_Speed_Y("OverMask_Speed_Y", Range( -1 , 1)) = 0
		_OverMask_Tiling_X("OverMask_Tiling_X", Range( 0 , 5)) = 0
		_OverMask_Tiling_Y("OverMask_Tiling_Y", Range( 0 , 5)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}

	}


	Category 
	{
		SubShader
		{
		LOD 0

			Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask RGB
			Cull Off
			Lighting Off 
			ZWrite Off
			ZTest LEqual
			
			Pass {
			
				CGPROGRAM
				
				#ifndef UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX
				#define UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input)
				#endif
				
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 2.0
				#pragma multi_compile_instancing
				#pragma multi_compile_particles
				#pragma multi_compile_fog
				#include "UnityShaderVariables.cginc"
				#pragma shader_feature_local _MASK_OVER_ON


				#include "UnityCG.cginc"

				struct appdata_t 
				{
					float4 vertex : POSITION;
					fixed4 color : COLOR;
					float4 texcoord : TEXCOORD0;
					UNITY_VERTEX_INPUT_INSTANCE_ID
					
				};

				struct v2f 
				{
					float4 vertex : SV_POSITION;
					fixed4 color : COLOR;
					float4 texcoord : TEXCOORD0;
					UNITY_FOG_COORDS(1)
					#ifdef SOFTPARTICLES_ON
					float4 projPos : TEXCOORD2;
					#endif
					UNITY_VERTEX_INPUT_INSTANCE_ID
					UNITY_VERTEX_OUTPUT_STEREO
					
				};
				
				
				#if UNITY_VERSION >= 560
				UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
				#else
				uniform sampler2D_float _CameraDepthTexture;
				#endif

				//Don't delete this comment
				// uniform sampler2D_float _CameraDepthTexture;

				uniform sampler2D _MainTex;
				uniform fixed4 _TintColor;
				uniform float4 _MainTex_ST;
				uniform float _InvFade;
				uniform sampler2D _MainTexture;
				uniform float _OverMaskEmission;
				uniform sampler2D _OverMask;
				SamplerState sampler_OverMask;
				uniform float _OverMask_Speed_X;
				uniform float _OverMask_Speed_Y;
				uniform float _OverMask_Tiling_X;
				uniform float _OverMask_Tiling_Y;
				uniform float _Emision;
				uniform float4 _ColorMask;
				uniform float _DissolveEdge;
				uniform float _ProgressBar;
				uniform sampler2D _Noise;
				SamplerState sampler_Noise;
				uniform float4 _Noise_ST;


				v2f vert ( appdata_t v  )
				{
					v2f o;
					UNITY_SETUP_INSTANCE_ID(v);
					UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
					UNITY_TRANSFER_INSTANCE_ID(v, o);
					

					v.vertex.xyz +=  float3( 0, 0, 0 ) ;
					o.vertex = UnityObjectToClipPos(v.vertex);
					#ifdef SOFTPARTICLES_ON
						o.projPos = ComputeScreenPos (o.vertex);
						COMPUTE_EYEDEPTH(o.projPos.z);
					#endif
					o.color = v.color;
					o.texcoord = v.texcoord;
					UNITY_TRANSFER_FOG(o,o.vertex);
					return o;
				}

				fixed4 frag ( v2f i  ) : SV_Target
				{
					UNITY_SETUP_INSTANCE_ID( i );
					UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( i );

					#ifdef SOFTPARTICLES_ON
						float sceneZ = LinearEyeDepth (SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)));
						float partZ = i.projPos.z;
						float fade = saturate (_InvFade * (sceneZ-partZ));
						i.color.a *= fade;
					#endif

					float2 texCoord50 = i.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
					float4 tex2DNode14 = tex2D( _MainTexture, texCoord50 );
					float clampResult48 = clamp( _OverMask_Speed_X , -5.0 , 5.0 );
					float clampResult49 = clamp( _OverMask_Speed_Y , -5.0 , 5.0 );
					float2 appendResult39 = (float2(clampResult48 , clampResult49));
					float clampResult46 = clamp( _OverMask_Tiling_X , 0.0 , 5.0 );
					float clampResult47 = clamp( _OverMask_Tiling_Y , 0.0 , 5.0 );
					float2 appendResult45 = (float2(clampResult46 , clampResult47));
					float2 texCoord23 = i.texcoord.xy * appendResult45 + float2( 2,0 );
					float2 panner24 = ( 1.0 * _Time.y * appendResult39 + texCoord23);
					float temp_output_27_0 = saturate( ( _OverMaskEmission * tex2D( _OverMask, panner24 ).r ) );
					float4 temp_cast_0 = (temp_output_27_0).xxxx;
					float4 lerpResult29 = lerp( tex2DNode14 , temp_cast_0 , ( temp_output_27_0 * tex2DNode14 ));
					#ifdef _MASK_OVER_ON
					float4 staticSwitch31 = ( lerpResult29 * _Emision * _ColorMask );
					#else
					float4 staticSwitch31 = tex2DNode14;
					#endif
					float lerpResult54 = lerp( ( 0.98 + _DissolveEdge ) , ( 0.0 - _DissolveEdge ) , _ProgressBar);
					float2 texCoord2 = i.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
					float smoothstepResult4 = smoothstep( ( lerpResult54 + ( _DissolveEdge * -1.5 ) ) , ( lerpResult54 + _DissolveEdge ) , ( 1.0 - texCoord2.x ));
					float temp_output_10_0 = saturate( smoothstepResult4 );
					float2 uv_Noise = i.texcoord.xy * _Noise_ST.xy + _Noise_ST.zw;
					float lerpResult5 = lerp( tex2D( _Noise, uv_Noise ).r , temp_output_10_0 , temp_output_10_0);
					

					fixed4 col = ( staticSwitch31 * saturate( ( temp_output_10_0 * lerpResult5 ) ) );
					UNITY_APPLY_FOG(i.fogCoord, col);
					return col;
				}
				ENDCG 
			}
		}	
	}
	CustomEditor "ASEMaterialInspector"
	
	
}