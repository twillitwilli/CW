﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace Water2D
{
    [Serializable]
    public class WaterSettings
    {
        public WaterCryo<Color> color;
        public WaterCryo<Vector2> tiling;
        public WaterCryo<float> baseAlpha;
        public WaterCryo<int> numOfPixels;
        public WaterCryo<bool> pixelPerfect;
        public WaterCryo<float> obstructionWidth;
        public WaterCryo<Color> obstructionColor;
        public WaterCryo<float> obstructionAlpha;
        public WaterCryo<Color> depthColor;
        public WaterCryo<Color> foamColor;
        public WaterCryo<float> foamSize;
        public WaterCryo<Vector2> foamSpeed;
        public WaterCryo<float> foamAlpha;
        public WaterCryo<Vector2> distortionSpeed;
        public WaterCryo<Vector2> distortionStrength;
        public WaterCryo<Vector2> distortionTiling;
        public WaterCryo<Vector2> distortionMinMax;
        public WaterCryo<Color> distortionColor = new WaterCryo<Color>(Color.black);
        public Texture2D distortionTexture;
        public Texture2D sunStripsTexture;
        public WaterCryo<float> stripsSpeed;
        public WaterCryo<float> stripsScrollingSpeed;
        public WaterCryo<float> stripsSize;

        public Texture2D surfaceTexture;
        public WaterCryo<Vector2> surfaceTiling;
        public WaterCryo<Vector2> surfaceSpeed;
        public WaterCryo<bool> useFoamSpeed;
        public WaterCryo<float> surfaceAlpha;

        public WaterCryo<float> stripsAlpha;
        public WaterCryo<float> stripsDensity;
        public WaterCryo<float> foamDensity;
        public WaterCryo<Vector2> perspective;
        public WaterCryo<bool> _useLighting;

        public WaterCryo<bool> enableBelowWater;
        public WaterCryo<Vector4> belowWaterUV;
        public WaterCryo<float> belowWaterDistortionStrength;
        public WaterCryo<float> belowWaterAlpha;

        internal void onValueChanged(UnityAction onWaterChanged)
        {
            enableBelowWater.onValueChanged = onWaterChanged;
            belowWaterAlpha.onValueChanged = onWaterChanged;
            belowWaterDistortionStrength.onValueChanged = onWaterChanged;
            belowWaterUV.onValueChanged = onWaterChanged;
            surfaceSpeed.onValueChanged = onWaterChanged;
            surfaceTiling.onValueChanged = onWaterChanged;
            useFoamSpeed.onValueChanged = onWaterChanged;
            surfaceAlpha.onValueChanged = onWaterChanged;
            color.onValueChanged = onWaterChanged;
            tiling.onValueChanged = onWaterChanged;
            pixelPerfect.onValueChanged = onWaterChanged;
            numOfPixels.onValueChanged = onWaterChanged;
            obstructionWidth.onValueChanged = onWaterChanged;
            obstructionColor.onValueChanged = onWaterChanged;
            obstructionAlpha.onValueChanged = onWaterChanged;
            depthColor.onValueChanged = onWaterChanged;
            foamColor.onValueChanged = onWaterChanged;
            foamSize.onValueChanged = onWaterChanged;
            foamSpeed.onValueChanged = onWaterChanged;
            foamAlpha.onValueChanged = onWaterChanged;
            distortionSpeed.onValueChanged = onWaterChanged;
            distortionStrength.onValueChanged = onWaterChanged;
            distortionTiling.onValueChanged = onWaterChanged;
            stripsSpeed.onValueChanged = onWaterChanged;
            stripsScrollingSpeed.onValueChanged = onWaterChanged;
            stripsSize.onValueChanged = onWaterChanged;
            stripsAlpha.onValueChanged = onWaterChanged;
            stripsDensity.onValueChanged = onWaterChanged;
            foamDensity.onValueChanged = onWaterChanged;
            baseAlpha.onValueChanged = onWaterChanged;
            perspective.onValueChanged = onWaterChanged;
            distortionMinMax.onValueChanged = onWaterChanged;
            distortionColor.onValueChanged = onWaterChanged;
            _useLighting.onValueChanged = onWaterChanged;
        }
    }

}