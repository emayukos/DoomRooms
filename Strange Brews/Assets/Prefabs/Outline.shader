Shader "Custom/Outline"
{
    Properties // variables
    {
        _MainTex ("Main Texture (RBG)", 2D) = "white" {} // allows for a texture property
        _Color("Color", Color) = (1,1,1,1) // allows for a color property
        _OutlineTex("Outline Texture", 2D) = "white" {}
        _OutlineColor("Outline Color", Color) = (1,1,1,1)
        _OutlineWidth("Outline Width", Range(1.0,10.0)) = 1.1
    }
    SubShader
    {
        Tags 
        {
            "Queue" = "Transparent"
        }
    
        Pass // when something is shaded once
        {
            Name "OUTLINE"
            
            ZWrite Off
            
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
            // IMPORTS
            float _OutlineWidth;
            float4 _OutlineColor;
            sampler2D _OutlineTex;

            // VERTEX FUNCTION - builds the object
            v2f vert (appdata IN)
            {
                IN.vertex.xyz *= _OutlineWidth; // make outline the same size if 1 or bigger if it's more than 1
                v2f OUT;
                
                OUT.pos = UnityObjectToClipPos(IN.vertex); // allows it to appear on screen
                OUT.uv = IN.uv;
                return OUT;
            }
            
            
            // FRAGMENT FUNCTION - color it in
            fixed4 frag (v2f IN) : SV_Target
            {
                float4 texColor = tex2D(_OutlineTex, IN.uv); // gets texture and wraps it around the object
                return texColor * _OutlineColor; 
            }
            ENDCG
        }


        Pass // when something is shaded once
        {
            Name "OBJECT"
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
