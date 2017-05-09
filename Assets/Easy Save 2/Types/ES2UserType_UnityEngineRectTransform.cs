using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_UnityEngineRectTransform : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		UnityEngine.RectTransform data = (UnityEngine.RectTransform)obj;
		// Add your writer.Write calls here.
writer.Write(data.anchorMin);
writer.Write(data.anchorMax);
writer.Write(data.anchoredPosition3D);
writer.Write(data.anchoredPosition);
writer.Write(data.sizeDelta);
writer.Write(data.pivot);
writer.Write(data.offsetMin);
writer.Write(data.offsetMax);
writer.Write(data.position);
writer.Write(data.localPosition);
writer.Write(data.eulerAngles);
writer.Write(data.localEulerAngles);
writer.Write(data.right);
writer.Write(data.up);
writer.Write(data.forward);
writer.Write(data.rotation);
writer.Write(data.localRotation);
writer.Write(data.localScale);
writer.Write(data.hasChanged);
writer.Write(data.hierarchyCapacity);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		UnityEngine.RectTransform data = GetOrCreate<UnityEngine.RectTransform>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		UnityEngine.RectTransform data = (UnityEngine.RectTransform)c;
		// Add your reader.Read calls here to read the data into the object.
data.anchorMin = reader.Read<UnityEngine.Vector2>();
data.anchorMax = reader.Read<UnityEngine.Vector2>();
data.anchoredPosition3D = reader.Read<UnityEngine.Vector3>();
data.anchoredPosition = reader.Read<UnityEngine.Vector2>();
data.sizeDelta = reader.Read<UnityEngine.Vector2>();
data.pivot = reader.Read<UnityEngine.Vector2>();
data.offsetMin = reader.Read<UnityEngine.Vector2>();
data.offsetMax = reader.Read<UnityEngine.Vector2>();
data.position = reader.Read<UnityEngine.Vector3>();
data.localPosition = reader.Read<UnityEngine.Vector3>();
data.eulerAngles = reader.Read<UnityEngine.Vector3>();
data.localEulerAngles = reader.Read<UnityEngine.Vector3>();
data.right = reader.Read<UnityEngine.Vector3>();
data.up = reader.Read<UnityEngine.Vector3>();
data.forward = reader.Read<UnityEngine.Vector3>();
data.rotation = reader.Read<UnityEngine.Quaternion>();
data.localRotation = reader.Read<UnityEngine.Quaternion>();
data.localScale = reader.Read<UnityEngine.Vector3>();
data.hasChanged = reader.Read<System.Boolean>();
data.hierarchyCapacity = reader.Read<System.Int32>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_UnityEngineRectTransform():base(typeof(UnityEngine.RectTransform)){}
}