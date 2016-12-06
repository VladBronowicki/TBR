using UnityEngine;
using System.Collections;

public class TBR_RearViewProperties : MonoBehaviour {

    void OnPreCull()
    {
        camera.ResetWorldToCameraMatrix();
        camera.ResetProjectionMatrix();
        camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
    }
    void OnPreRender()
    {
        GL.SetRevertBackfacing(true);
    }
    void OnPostRender()
    {
        GL.SetRevertBackfacing(false);
    }

}
