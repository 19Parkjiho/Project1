Shader "Unlit/Rainbow"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Alpha("Transparency", Range(0.0, 1.0)) = 0.1
    }
        SubShader
        {
            Tags { "RenderType" = "Transparent" }
            LOD 100

            Blend SrcAlpha OneMinusSrcAlpha

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                sampler2D _MainTex;
                float _Alpha;

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed3 hsv2rgb(fixed3 c)
                {
                    float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
                    float3 p = abs(frac(c.xxx + K.xyz) * 6.0 - K.www);
                    return c.z * lerp(K.xxx, saturate(p - K.xxx), c.y);
                }

                fixed4 frag(v2f i) : SV_Target
                {

                    float hue = fmod(_Time.x * 5.0, 1.0); 
                    fixed3 hsv = fixed3(hue, 1.0, 1.0); 
                    fixed3 rgb = hsv2rgb(hsv); 

                    fixed4 texColor = tex2D(_MainTex, i.uv);

                    return texColor * fixed4(rgb, _Alpha); 
                }
                ENDCG
            }
        }
            FallBack "Unlit/Transparent"
}
