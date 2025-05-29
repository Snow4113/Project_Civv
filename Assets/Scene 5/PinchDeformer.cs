using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PinchDeformer : MonoBehaviour
{
    public XRController controller;
    public DeformableTerrain terrain;
    public float raycastDistance = 10f;

    void Update()
    {
        // Check for PINCH (trigger)
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            if (triggerValue > 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit, raycastDistance))
                {
                    terrain.DeformTerrain(hit.point, true); // Pull terrain
                }
            }
        }

        // Check for PUSH (grip) - SEPARATE from trigger check!
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            if (gripValue > 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit, raycastDistance))
                {
                    terrain.DeformTerrain(hit.point, false); // Push terrain
                }
            }
        }
    }
}