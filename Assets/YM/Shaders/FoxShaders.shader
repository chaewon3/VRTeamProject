Shader "Toon/FoxSurface"
{
    Properties
    {
        _Color ("Color", Color) = (0.4,0.4,0.4,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Emission("Emission", Range(0,1)) = 0.5
        _Transparency("Transparency", Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Fade" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert
        #pragma target 3.0

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        fixed4 _Color;
        fixed _Emission;

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            
            
            o.Albedo = c.rgb;
            c.a = 0;
            
            // Re-use the same texture on emission to give the soft look
            o.Emission = tex2D (_MainTex, IN.uv_MainTex) * _Emission;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
