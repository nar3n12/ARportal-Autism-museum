Shader "Unlit/Mask"
{
    Properties
    {
       
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" }
        
        Cull off 
        
        Pass
        {
           Zwrite Off 
        }
    }
}
