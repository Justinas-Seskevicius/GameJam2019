using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{

    public float FogChangeSpeed;
    [Range(0, 0.5f)]
    public float offset;

    // Update is called once per frame
    void Update()
    {
        float polution = (float) this.GetComponent<WorldObjectCounter>().CalculatePollution() / (float) this.GetComponent<WorldObjectCounter>().TotalSpotCount.Value;

        if (polution - offset > RenderSettings.fogDensity)
        {
            RenderSettings.fogDensity += Time.deltaTime * FogChangeSpeed;
        }
        else if (polution - offset < RenderSettings.fogDensity)
        {
            RenderSettings.fogDensity -= Time.deltaTime * FogChangeSpeed;
        }

        RenderSettings.fogDensity = Mathf.Clamp(RenderSettings.fogDensity, 0f, 1f);
    }
}
