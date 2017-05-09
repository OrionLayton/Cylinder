using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_UnityEngineCamera : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		UnityEngine.Camera data = (UnityEngine.Camera)obj;
		// Add your writer.Write calls here.
writer.Write(data.fieldOfView);
writer.Write(data.nearClipPlane);
writer.Write(data.farClipPlane);
writer.Write(data.renderingPath);
writer.Write(data.allowHDR);
writer.Write(data.forceIntoRenderTexture);
writer.Write(data.allowMSAA);
writer.Write(data.orthographicSize);
writer.Write(data.orthographic);
writer.Write(data.opaqueSortMode);
writer.Write(data.transparencySortMode);
writer.Write(data.transparencySortAxis);
writer.Write(data.depth);
writer.Write(data.aspect);
writer.Write(data.cullingMask);
writer.Write(data.eventMask);
writer.Write(data.backgroundColor);
writer.Write(data.rect);
writer.Write(data.pixelRect);
writer.Write(data.worldToCameraMatrix);
writer.Write(data.projectionMatrix);
writer.Write(data.nonJitteredProjectionMatrix);
writer.Write(data.useJitteredProjectionMatrixForTransparentRendering);
writer.Write(data.clearFlags);
writer.Write(data.stereoSeparation);
writer.Write(data.stereoConvergence);
writer.Write(data.cameraType);
writer.Write(data.stereoMirrorMode);
writer.Write(data.stereoTargetEye);
writer.Write(data.targetDisplay);
writer.Write(data.useOcclusionCulling);
writer.Write(data.cullingMatrix);
writer.Write(data.layerCullSpherical);
writer.Write(data.depthTextureMode);
writer.Write(data.clearStencilAfterLightingPass);
writer.Write(data.enabled);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		UnityEngine.Camera data = GetOrCreate<UnityEngine.Camera>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		UnityEngine.Camera data = (UnityEngine.Camera)c;
		// Add your reader.Read calls here to read the data into the object.
data.fieldOfView = reader.Read<System.Single>();
data.nearClipPlane = reader.Read<System.Single>();
data.farClipPlane = reader.Read<System.Single>();
data.renderingPath = reader.Read<UnityEngine.RenderingPath>();
data.allowHDR = reader.Read<System.Boolean>();
data.forceIntoRenderTexture = reader.Read<System.Boolean>();
data.allowMSAA = reader.Read<System.Boolean>();
data.orthographicSize = reader.Read<System.Single>();
data.orthographic = reader.Read<System.Boolean>();
data.opaqueSortMode = reader.Read<UnityEngine.Rendering.OpaqueSortMode>();
data.transparencySortMode = reader.Read<UnityEngine.TransparencySortMode>();
data.transparencySortAxis = reader.Read<UnityEngine.Vector3>();
data.depth = reader.Read<System.Single>();
data.aspect = reader.Read<System.Single>();
data.cullingMask = reader.Read<System.Int32>();
data.eventMask = reader.Read<System.Int32>();
data.backgroundColor = reader.Read<UnityEngine.Color>();
data.rect = reader.Read<UnityEngine.Rect>();
data.pixelRect = reader.Read<UnityEngine.Rect>();
data.worldToCameraMatrix = reader.Read<UnityEngine.Matrix4x4>();
data.projectionMatrix = reader.Read<UnityEngine.Matrix4x4>();
data.nonJitteredProjectionMatrix = reader.Read<UnityEngine.Matrix4x4>();
data.useJitteredProjectionMatrixForTransparentRendering = reader.Read<System.Boolean>();
data.clearFlags = reader.Read<UnityEngine.CameraClearFlags>();
data.stereoSeparation = reader.Read<System.Single>();
data.stereoConvergence = reader.Read<System.Single>();
data.cameraType = reader.Read<UnityEngine.CameraType>();
data.stereoMirrorMode = reader.Read<System.Boolean>();
data.stereoTargetEye = reader.Read<UnityEngine.StereoTargetEyeMask>();
data.targetDisplay = reader.Read<System.Int32>();
data.useOcclusionCulling = reader.Read<System.Boolean>();
data.cullingMatrix = reader.Read<UnityEngine.Matrix4x4>();
data.layerCullSpherical = reader.Read<System.Boolean>();
data.depthTextureMode = reader.Read<UnityEngine.DepthTextureMode>();
data.clearStencilAfterLightingPass = reader.Read<System.Boolean>();
data.enabled = reader.Read<System.Boolean>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_UnityEngineCamera():base(typeof(UnityEngine.Camera)){}
}