Shader "Custom/Blur"
{
    Properties // variables
    {
        _BlurRadius("Blur Radius", Range(0.0,20.0)) = 1
        _Intensity("Blur Intensity", Range(0.0,1.0)) = 0.01
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
            Name "HORIZONTALBLUR"
            
            ZWrite Off
            
            CGPROGRAM  // allows talk between two languages: shader lab and ndivia C for graphics
            #pragma vertex vert //define for the building function
            #pragma fragment frag //define for coloring function
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc" //library of built-in functions for shader writing
            
            // STRUCTURES ----

            struct v2f  //says how fragment function gets its data
            {
                float4 vertex : SV_POSITION;
                float4 uvgrab : TEXCOORD0;
            };
            
            // IMPORTS - re-import property from shader lab to nvidia cg
            float _BlurRadius;
            float4 _Intensity;
            sampler2D _GrabTexture;
            float4 _GrabTexture_TexelSize;

            // VERTEX FUNCTION - builds the object
            v2f vert(appdata_base IN)
            {
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
                return OUT;
            }
            
            
            // FRAGMENT FUNCTION - color it in
            half4 frag (v2f IN) : COLOR
            {
                half4 texcol = tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(IN.uvgrab)); 
                half4 texsum = half4(0,0,0,0);
                #define GRABPIXEL(weight, kernelx) tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(float4(IN.uvgrab.x + _GrabTexture_TexelSize.x * kernelx * _BlurRadius, IN.uvgrab.y, IN.uvgrab.z, IN.uvgrab.w))) * weight
                    texsum += GRABPIXEL(0.05, -4.0);
                    texsum += GRABPIXEL(0.09, -3.0); 
                    texsum += GRABPIXEL(0.12, -2.0);
                    texsum += GRABPIXEL(0.15, -1.0);
                    texsum += GRABPIXEL(0.18, 0.0);
                    texsum += GRABPIXEL(0.15, 1.0);
                    texsum += GRABPIXEL(0.12, 2.0);
                    texsum += GRABPIXEL(0.09, 3.0);
                    texsum += GRABPIXEL(0.05, 4.0);
                
                texcol = lerp(texcol,texsum,_Intensity); // gonna lerp between no blur and blur by the intensity; if intensity 1 then texsum so all the way blurred, 0 not blurred
                return texcol; 
            }
            ENDCG
        }

        GrabPass{}
         
        Pass // when something is shaded once
        {
            Name "VERTICALBLUR"
            CGPROGRAM  // allows talk between two languages: shader lab and ndivia C for graphics
            #pragma vertex vert //define for the building function
            #pragma fragment frag //define for coloring function
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc" //library of built-in functions for shader writing
            
            // STRUCTURES ----

            struct v2f  //says how fragment function gets its data
            {
                float4 vertex : SV_POSITION;
                float4 uvgrab : TEXCOORD0;
            };
            
            // IMPORTS
            float _BlurRadius;
            float4 _Intensity;
            sampler2D _GrabTexture;
            float4 _GrabTexture_TexelSize;

            // VERTEX FUNCTION - builds the object
            v2f vert(appdata_base IN)
            {
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
                return OUT;
            }
            
            
            // FRAGMENT FUNCTION - color it in
            half4 frag (v2f IN) : COLOR
            {
                half4 texcol = tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(IN.uvgrab)); 
                half4 texsum = half4(0,0,0,0);
                #define GRABPIXEL(weight, kernely) tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(float4(IN.uvgrab.x, IN.uvgrab.y + _GrabTexture_TexelSize.y * kernely * _BlurRadius, IN.uvgrab.z, IN.uvgrab.w))) * weight
                    texsum += GRABPIXEL(0.05, -4.0);
                    texsum += GRABPIXEL(0.09, -3.0); 
                    texsum += GRABPIXEL(0.12, -2.0);
                    texsum += GRABPIXEL(0.15, -1.0);
                    texsum += GRABPIXEL(0.18, 0.0);
                    texsum += GRABPIXEL(0.15, 1.0);
                    texsum += GRABPIXEL(0.12, 2.0);
                    texsum += GRABPIXEL(0.09, 3.0);
                    texsum += GRABPIXEL(0.05, 4.0);
                
                texcol = lerp(texcol,texsum,_Intensity); // gonna lerp between no blur and blur by the intensity; if intensity 1 then texsum so all the way blurred, 0 not blurred
                return texcol; 
            }
            ENDCG
        }
    }
}
