using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_SteamVR_UpdatePoses : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		SteamVR_UpdatePoses data = (SteamVR_UpdatePoses)obj;
		// Add your writer.Write calls here.
writer.Write(data.useGUILayout);
//writer.Write(data.runInEditMode);
writer.Write(data.enabled);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		SteamVR_UpdatePoses data = GetOrCreate<SteamVR_UpdatePoses>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		SteamVR_UpdatePoses data = (SteamVR_UpdatePoses)c;
		// Add your reader.Read calls here to read the data into the object.
data.useGUILayout = reader.Read<System.Boolean>();
//data.runInEditMode = reader.Read<System.Boolean>();
data.enabled = reader.Read<System.Boolean>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_SteamVR_UpdatePoses():base(typeof(SteamVR_UpdatePoses)){}
}