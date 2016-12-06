Shader "Custom/TestShader" {
   
   Properties{

		_Color ("Main Color", Color) = (1,1,1,1)
		_SpecColor("Specular Color", Color) = (1,1,1,1)
		_Shininess("Specular Power", Range(-1,2)) = 0.5
		_RimColor ("Rim Color", Color) = (1,1,1,1)
		_RimPower ("Rim Power", Range(0.5, 8.0)) = 3.0
		_MainTex ("Base (RGB) Gloss (A)", 2d) = "white" {}
		_BumpMap ("Normal Map", 2D) = "white" {}


   }

   SubShader
   {

		Tags { "RenderType"="Opaque" }
		LOD 300

	CGPROGRAM
	#pragma surface surf BlinnPhong
	
	sampler2D _MainTex;
	sampler2D _BumpMap;
	float4 _Color;
	float4 _RimColor;
	float _RimPower;
	float _Shininess;
	
	struct Input
	{
	
		float2 uv_MainTex;
		float2 uv_BumpMap;
		float3 viewDir;

	};
	
	void surf (Input IN, inout SurfaceOutput o)
	{
	
		//Handle Textures
		fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
		float3 bump = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

		//Apply Normal Map
		o.Albedo = tex.rgb * _Color.rgb;

		//Specular
		o.Specular = _Shininess;
		o.Gloss = tex.a;

		//Rim Light
		half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
		o.Emission = _RimColor.rgb * pow(rim, _RimPower);
		
	} 
	ENDCG

   }
Fallback "VertexLit"
}