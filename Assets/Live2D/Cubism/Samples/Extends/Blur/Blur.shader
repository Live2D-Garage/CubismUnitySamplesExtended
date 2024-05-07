/**
 * Copyright(c) Live2D Inc. All rights reserved.
 *
 * Released under the MIT license
 * https://opensource.org/licenses/mit-license.php
 */


Shader "Live2D Cubism/Blur"
{
    Properties
    {
        // Texture and model opacity settings.
        [PerRendererData] _MainTex("Main Texture", 2D) = "white" {}
        [PerRendererData] cubism_ModelOpacity("Model Opacity", Float) = 1

        // Blend settings.
        _SrcColor("Source Color", Int) = 1
        _DstColor("Destination Color", Int) = 10
        _SrcAlpha("Source Alpha", Int) = 1
        _DstAlpha("Destination Alpha", Int) = 10

        // Mask settings.
        [Toggle(CUBISM_MASK_ON)] cubism_MaskOn("Mask?", Int) = 0
        [PerRendererData] cubism_MaskTexture("cubism_Internal", 2D) = "white" {}
        [PerRendererData] cubism_MaskTile("cubism_Internal", Vector) = (0, 0, 0, 0)
        [PerRendererData] cubism_MaskTransform("cubism_Internal", Vector) = (0, 0, 0, 0)

        _Size("Size", Float) = 4
    }
    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
            "PreviewType" = "Plane"
            "CanUseSpriteAtlas" = "True"
        }

        Cull     Off
        Lighting Off
        ZWrite   Off
        Blend[_SrcColor][_DstColor],[_SrcAlpha][_DstAlpha]

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile CUBISM_MASK_ON CUBISM_MASK_OFF

            #include "UnityCG.cginc"
            #include "Assets/Live2D/Cubism/Rendering/Resources/Live2D/Cubism/Shaders/CubismCG.cginc"

            struct appdata
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_OUTPUT_STEREO

                // Add Cubism specific vertex output data.
                CUBISM_VERTEX_OUTPUT
            };

            sampler2D _MainTex;

            // Include Cubism specific shader variables.
            CUBISM_SHADER_VARIABLES

            v2f vert(appdata IN)
            {
                v2f OUT;

                UNITY_SETUP_INSTANCE_ID(IN);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);

                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color;

                // Initialize Cubism specific vertex output data.
                CUBISM_INITIALIZE_VERTEX_OUTPUT(IN, OUT);

                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                fixed4 OUT = tex2D(_MainTex, IN.texcoord) * IN.color;

                // Apply Cubism alpha to color.
                CUBISM_APPLY_ALPHA(IN, OUT);

                return OUT;
            }
            ENDCG
        }

        GrabPass
        {
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct v2f
            {
                float4 grabPos : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            v2f vert(appdata_base v) 
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.pos);
                return o;
            }

            sampler2D _GrabTexture;
            fixed _Size;

            half4 frag(v2f i) : SV_Target
            {
                float2 uv = i.grabPos.xy / i.grabPos.w;
                half4 sum = half4(0, 0, 0, 0);
                int count = 0;

                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        float2 offset = float2(x, y) * _Size / _ScreenParams.xy;
                        sum += tex2D(_GrabTexture, uv + offset);
                        count++;
                    }
                }

                return sum / count;
            }
            ENDCG
        }
    }
}
