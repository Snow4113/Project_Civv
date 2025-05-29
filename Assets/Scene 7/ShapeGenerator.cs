using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSetting settings;
    NoiseFilter noiseFilter;

    public ShapeGenerator (ShapeSetting ShapeSetting)
    {
        this.settings = ShapeSetting;
       // noiseFilter = new NoiseFilter ();
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float elevation = noiseFilter.Evaluate (pointOnUnitSphere);
        return pointOnUnitSphere * settings.planetRaduis * (1 + elevation);
    }

}
