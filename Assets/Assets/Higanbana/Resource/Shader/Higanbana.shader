Shader "Higanbana/Higanbana"
{
    Properties
    {
        [Header(Customization Color Parameters)] [Space(10)]
        [MaterialToggle] _UseCustomizeColor("UseCustomizeColor",int) = 0
        [MaterialToggle] _UseEmission("UseEmission",int) = 0
        [Space(20)]

        _StemColor("StemColor",Color) = (0.3,0.7,0.5)
        _FlowerColor("FlowerColor",Color) = (0.5,0.7,0.8)
        _StamenColor("StamenColor",Color) = (0.8,0.9,1)
        [Space(30)]


        [Header(Original Maps)][Space(10)]
        [NoScaleOffset] _BasecolorMap("BaseColorMap",2D) = "white"{}
        [NoScaleOffset] _RoughnessMap("RoughnessMap",2D) = "white"{}
        [NoScaleOffset] _NormalMap("NormalMap",2D) = "bump"{}
        [Space(20)]


        [Header(Customization Maps)][Space(10)]
        [NoScaleOffset] _RGBMask("RGBMask",2D) = "black"{}
        [NoScaleOffset] _ColorBlendBase("ColorBlendBase",2D) = "white"{}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Cull Off

        CGPROGRAM
        
        #pragma surface surf Standard fullforwardshadows

       
        #pragma target 3.0

        sampler2D _BasecolorMap;
        sampler2D _RoughnessMap;
        sampler2D _NormalMap;

        sampler2D _RGBMask;
        sampler2D _ColorBlendBase;

        struct Input
        {
            float2 uv_BasecolorMap;
        };

        int _UseCustomizeColor;
        int _UseEmission;

        fixed3 _StemColor;
        fixed3 _FlowerColor;
        fixed3 _StamenColor;

        
        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)


        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 uv = IN.uv_BasecolorMap;

            fixed3 defaultColor = tex2D (_BasecolorMap, uv);
            half roughness = tex2D(_RoughnessMap, uv).r;
            fixed3 normal = UnpackNormal(tex2D(_NormalMap, uv));

            fixed3 rgbMask = tex2D(_RGBMask, uv);
            fixed3 colorBlendBase = tex2D(_ColorBlendBase, uv);

            fixed3 color = defaultColor;

            color = lerp(color, _StemColor, rgbMask.r);
            color = lerp(color, _FlowerColor, rgbMask.g);
            color = lerp(color, _StamenColor, rgbMask.b);

            color = lerp(defaultColor, color, step(0.1, _UseCustomizeColor));

            o.Albedo = color;
            o.Smoothness = 1 - roughness;
            o.Normal = normal;
            o.Emission = lerp(fixed3(0, 0, 0),color,_UseEmission);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
