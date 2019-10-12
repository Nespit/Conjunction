Shader "Unlit/NodeStatusBar"
{
    Properties 
    {
        _Progress ("Progress", float) = 0.24
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Texture", 2D) = "white" {}
    }
    
    SubShader 
    {
        Tags {"Queue"="Transparent"}
        LOD 1000

        Pass
        {
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata 
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 postiion : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            fixed4 _Color;
            float _Progress;
            sampler2D _MainTexture;

            v2f vert(appdata IN)
            {
                v2f OUT;
                
                OUT.postiion = UnityObjectToClipPos(IN.vertex);
                OUT.uv = IN.uv;

                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                fixed4 pixelColor = tex2D(_MainTexture, IN.uv);
                pixelColor.rgb = step(_Progress, IN.uv.x);
                //pixelColor.g = pixelColor.g*IN.uv.y;
                return pixelColor;
            }

            ENDCG
        }
    }
}