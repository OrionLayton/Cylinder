using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_SteamVR_PlayArea : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		SteamVR_PlayArea data = (SteamVR_PlayArea)obj;
		// Add your writer.Write calls here.
writer.Write(data.borderThickness);writer.Write(data.wireframeHeight);writer.Write(data.drawWireframeWhenSelectedOnly);writer.Write(data.drawInGame);writer.Write(data.size);writer.Write(data.color);writer.Write(data.useGUILayout);
//writer.Write(data.runInEditMode);
writer.Write(data.enabled);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		SteamVR_PlayArea data = GetOrCreate<SteamVR_PlayArea>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		SteamVR_PlayArea data = (SteamVR_PlayArea)c;
		// Add your reader.Read calls here to read the data into the object.
data.borderThickness = reader.Read<System.Single>();
data.wireframeHeight = reader.Read<System.Single>();
data.drawWireframeWhenSelectedOnly = reader.Read<System.Boolean>();
data.drawInGame = reader.Read<System.Boolean>();
data.size = reader.Read<SteamVR_PlayArea.Size>();
data.color = reader.Read<UnityEngine.Color>();
data.useGUILayout = reader.Read<System.Boolean>();
//data.runInEditMode = reader.Read<System.Boolean>();
data.enabled = reader.Read<System.Boolean>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_SteamVR_PlayArea():base(typeof(SteamVR_PlayArea)){}
}