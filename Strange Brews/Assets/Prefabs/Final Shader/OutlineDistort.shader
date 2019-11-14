Shader "Custom/OutlineDistort"
{
    Properties // variables
    {
        _DistortColor("Distort Color", Color) = (1,1,1,1)
        _BumperAmt("Distortion", Range(0,128)) = 10
        _DistortTex("Distort Texture (RGB)", 2D) = "white" {}
        _BumpMap("Normal Map", 2D) = "bump" {}
        _OutlineWidth("Outline Width", Range(1.0,10.0)) = 1.1
    }
    SubShader
    {
        Tags 
        {
            "Queue" = "Transparent"
        }
        
        GrabPass{}
    
        Pass // when something is shaded once
        {
            Name "OUTLINEDISTORT"
            
            ZWrite Off
            
            CGPROGRAM  // allows talk between two languages: shader lab and ndivia C for graphics
            #pragma vertex vert //define for the building function
            #pragma fragment frag //define for coloring function
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc" //library of built-in functions for shader writing
            
            // STRUCTURES ----
            
            struct appdata 
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f  //says how fragment function gets its data
            {
                float4 vertex : SV_POSITION;
                float4 uvgrab : TEXCOORD0;
                float2 uvbump : TEXCOORD1;
                float uvmain : TEXCOORD2;
            };
            
            // IMPORTS - re-import property from shader lab to nvidia cg
            float _BumpAmt;
            float4 _BumpMap_ST;
            float4 _DistortTex_ST;
            fixed4 _DistortColor;
            sampler2D _GrabTexture;
            float4 _GrabTexture_TexelSize;
            sampler2D _BumpMap;
            sampler2D _DistortTex;
            float _OutlineWidth;
            

            // VERTEX FUNCTION - builds the object
            v2f vert(appdata IN)
            {
                IN.vertex.xyz *= _OutlineWidth;
                v2f OUT;
                
                OUT.vertex = UnityObjectToClipPos(IN.vertex); // allows it to appear on screen
                #if UNITY_UV_STARTS_AT_TOP
                    float scale = -1.0;
                #else
                    float scale = 1.0;
                #endif
                
                // make so only gets what's actually behind the object 
                OUT.uvgrab.xy = (float2(OUT.vertex.x, OUT.vertex.y * scale) + OUT.vertex.w) * 0.5;
                OUT.uvgrab.zw = OUT.vertex.zw;                
                OUT.uvbump = TRANSFORM_TEX(IN.texcoord, _BumpMap);
                OUT.uvmain = TRANSFORM_TEX(IN.texcoord, _DistortTex);
                return OUT;
            }
            
            
            // FRAGMENT FUNCTION - color it in
            half4 frag (v2f IN) : COLOR
            {
               half2 bump = UnpackNormal(tex2D(_BumpMap, IN.uvbump)).rg;
               float2 offset = bump * _BumpAmt * _GrabTexture_TexelSize.xy;
               IN.uvgrab.xy = offset * IN.uvgrab.x + IN.uvgrab.xy;
               
               half4 col = tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(IN.uvgrab));
               half4 tint = tex2D(_DistortTex, IN.uvmain)* _DistortColor;
               
               return col * tint;
 
            }
            ENDCG
        }   
    }
}
