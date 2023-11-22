Shader "Water2D/Simulations/process"
{
    Properties
    { 
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata
            {
                float4 vertex : POSITION; 
                float2 uv : TEXCOORD0; 
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0; 
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            uniform sampler2D _NState;
            uniform sampler2D _ObstructionTex;

            uniform float4 OstructionTexPos;
            uniform float4 OstructionTexRes;
            uniform float4 texPos;

            uniform float2 resolution;

            uniform float waveRad;
            uniform float dispersion;
            uniform float waveHeight;
            uniform float diffusionSize;
            uniform float rainWaveH;
            uniform float rainSpeed;
            uniform float timeFromStart;
            uniform float rainSizeX;
            uniform float rainSizeY;
            uniform float enableRain;


            float hash12(float2 co) 
            {
                return frac(sin(dot(co.xy ,float2(12.9898,78.233))) * 43758.5453);
            }

            float2 GetObsUVs(float2 uv)
            {
                float2 res;

                float distX = OstructionTexPos.z - OstructionTexPos.x;
                float distY = OstructionTexPos.w - OstructionTexPos.y;

                float4 uvs;
                uvs.x =  (texPos.x - OstructionTexPos.x) / distX;
                uvs.y =  (texPos.y - OstructionTexPos.y) / distY;
                uvs.z =  (texPos.z - OstructionTexPos.x) / distX;
                uvs.w =  (texPos.w - OstructionTexPos.y) / distY;

                res.x = lerp(uvs.x,uvs.z,uv.x);
                res.y = lerp(uvs.y,uvs.w,uv.y);


                return res.xy;
            }

            float2 frag (v2f i) : SV_Target
            {
                //old h
                float2 data = tex2D(_NState,i.uv).xy;
                //new h

                float new_s = data.y;
                float org_s = data.x;

                const float take = 0.20;
                const float takeCorner = 0.05;

                float sum = 0;
                float2 stepSize = float2(1.0/resolution.x,1.0/resolution.y);

                sum += tex2D(_NState, (i.uv + float2(stepSize.x,0.0) ) ).x  ;
                sum += tex2D(_NState, i.uv + float2(-stepSize.x,0.0)  ).x  ;
                sum += tex2D(_NState, i.uv + float2(0.0,stepSize.y) ).x  ;
                sum += tex2D(_NState, i.uv + float2(0.0,-stepSize.y) ).x  ;
                sum *= take;

                sum += tex2D(_NState, i.uv + float2(stepSize.x,stepSize.y)  ).x* takeCorner;
                sum += tex2D(_NState, i.uv + float2(-stepSize.x,stepSize.y) ).x* takeCorner;
                sum += tex2D(_NState, i.uv + float2(stepSize.x,-stepSize.y) ).x* takeCorner;
                sum += tex2D(_NState, i.uv + float2(-stepSize.x,-stepSize.y)).x* takeCorner;

                sum -= org_s;

                //new height
                float newH = org_s * 2 - new_s + sum;

                //dispersion
                newH *= dispersion;


                //add obstructors
                float2 obsUvs = GetObsUVs(i.uv);
                if(obsUvs.x > 0 && obsUvs.x < 1 && obsUvs.y > 0 && obsUvs.y < 1 )
                {
                    newH -= tex2D(_ObstructionTex, obsUvs) * waveHeight;
                }

                if(enableRain)
                {
                    for(int x = -rainSizeX; x < rainSizeX+1; x++)
                    {
                        for(int y = -rainSizeY; y < rainSizeY+1; y++)
                        {
                            int rand = floor( hash12( frac(timeFromStart/2) * (i.uv + ( float2(x,y) * stepSize)  ) ).x * 10000 / rainSpeed );
                            if(rand==1){newH -= rainWaveH; }
                        }
                    }
                }

                return float2(newH, org_s);
            }

            ENDCG
        }
    }
}