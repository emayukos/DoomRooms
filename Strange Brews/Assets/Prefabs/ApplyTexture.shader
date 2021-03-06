﻿Shader "Custom/ApplyTexture"
{
    Properties // variables
    {
        _MainTex ("Main Texture (RBG)", 2D) = "white" {} // allows for a texture property
        _Color("Color", Color) = (1,1,1,1) // allows for a color property
    }
    SubShader
    {

        Pass // when something is shaded once
        {
            CGPROGRAM  // allows talk between two languages: shader lab and ndivia C for graphics
            #pragma vertex vert //define for the building function
            #pragma fragment frag //define for coloring function
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc" //library of built-in functions for shader writing
            
            // STRUCTURES ----

            struct appdata  //says how vertex function is gonna get info
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f  //says how fragment function gets its data
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };
            
            float4 _Color;
            sampler2D _MainTex;

            // VERTEX FUNCTION - builds the object
            v2f vert (appdata IN)
            {
                v2f OUT;
                
                OUT.pos = UnityObjectToClipPos(IN.vertex); // allows it to appear on screen
                OUT.uv = IN.uv;
                return OUT;
            }
            
            
            // FRAGMENT FUNCTION - color it in
            fixed4 frag (v2f IN) : SV_Target
            {
                float4 texColor = tex2D(_MainTex, IN.uv); // gets texture and wraps it around the object
                return texColor * _Color; 
            }
            ENDCG
        }
    }
}
