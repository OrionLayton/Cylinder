using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_UnityEngineTextMesh : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		UnityEngine.TextMesh data = (UnityEngine.TextMesh)obj;
		// Add your writer.Write calls here.
writer.Write(data.fontSize);
writer.Write(data.fontStyle);
writer.Write(data.offsetZ);
writer.Write(data.alignment);
writer.Write(data.anchor);
writer.Write(data.characterSize);
writer.Write(data.lineSpacing);
writer.Write(data.tabSize);
writer.Write(data.richText);
writer.Write(data.color);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		UnityEngine.TextMesh data = GetOrCreate<UnityEngine.TextMesh>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		UnityEngine.TextMesh data = (UnityEngine.TextMesh)c;
		// Add your reader.Read calls here to read the data into the object.
data.fontSize = reader.Read<System.Int32>();
data.fontStyle = reader.Read<UnityEngine.FontStyle>();
data.offsetZ = reader.Read<System.Single>();
data.alignment = reader.Read<UnityEngine.TextAlignment>();
data.anchor = reader.Read<UnityEngine.TextAnchor>();
data.characterSize = reader.Read<System.Single>();
data.lineSpacing = reader.Read<System.Single>();
data.tabSize = reader.Read<System.Single>();
data.richText = reader.Read<System.Boolean>();
data.color = reader.Read<UnityEngine.Color>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_UnityEngineTextMesh():base(typeof(UnityEngine.TextMesh)){}
}