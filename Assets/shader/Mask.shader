Shader "Unlit/Mask"
{
  /**  Properties
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
    } **/
    SubShader
  {  
    ZWrite off
    ColorMask 0
    Cull off 
    
    Stencil{
        Ref 1
        Comp always
        Pass replace
    }
        
        Pass
        {
        }
    }
}
