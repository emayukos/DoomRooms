Shader "Custom/FinalOutline"
{
    Properties // variables
    {
        _MainTex ("Main Texture (RBG)", 2D) = "white" {} // allows for a texture property
        _Color("Color", Color) = (1,1,1,1) // allows for a color property
        
        _OutlineWidth("Outline Width", Range(1.0,10.0)) = 1.1
        
        _BlurRadius("Blur Radius", Range(0.0,20.0)) = 1
        _Intensity("Blur Intensity", Range(0.0,1.0)) = 0.01
        
        _DistortColor("Distort Color", Color) = (1,1,1,1)
        _BumperAmt("Distortion", Range(0,128)) = 10
        _DistortTex("Distort Texture (RGB)", 2D) = "white" {}
        _BumpMap("Normal Map", 2D) = "bump" {}
    }
    SubShader
    {
        Tags 
        {
            "Queue" = "Transparent"
        }
    
        GrabPass {}
        UsePass "Custom/OutlineDistort/OUTLINEDISTORT"
        
        GrabPass {}
        UsePass "Custom/OutlineBlur/OUTLINEHORIZONTALBLUR"  // going to horizontally blur everything behind the object
    
        GrabPass {}
        UsePass "Custom/OutlineBlur/OUTLINEVERTICALBLUR"
    
        UsePass "Custom/Outline/OBJECT"

     
    }
}
