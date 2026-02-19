using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class TeleportManager : MonoBehaviour
{
    public XROrigin xrOrigin;

    public void TeleportTo(Transform target)
    {
        CharacterController cc = xrOrigin.GetComponent<CharacterController>();

        if (cc != null)
        {
            cc.enabled = false;
        }

        xrOrigin.transform.position = target.position;

        if (cc != null)
        {
            cc.enabled = true;
        }

    }

}
