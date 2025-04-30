using System;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public class BendingManager : MonoBehaviour
{

    private const string BENDING_FEATURE = "ENABLE_BENDING";
    private static float size = 10000;

    private void Awake()
    {
        if (Application.isPlaying)
        {
            Shader.EnableKeyword(BENDING_FEATURE);
        }
        else
        {
            Shader.DisableKeyword(BENDING_FEATURE);
        }
    }

    private void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
    }
    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
    }


    private static void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        if (camera == null) return;
        Matrix4x4 customCulling = Matrix4x4.Ortho(-size, size, -size, size, camera.nearClipPlane, camera.farClipPlane);
        camera.cullingMatrix = customCulling * camera.worldToCameraMatrix;
    }

    private static void OnEndCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        if (camera == null) return;

        camera.ResetCullingMatrix();
    }
}
