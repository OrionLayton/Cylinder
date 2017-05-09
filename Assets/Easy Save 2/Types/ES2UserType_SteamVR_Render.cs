using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_SteamVR_Render : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		SteamVR_Render data = (SteamVR_Render)obj;
		// Add your writer.Write calls here.
writer.Write(data.pauseGameWhenDashboardIsVisible);writer.Write(data.lockPhysicsUpdateRateToRenderFrequency);writer.Write(data.trackingSpace);writer.Write(data.useGUILayout);
//writer.Write(data.runInEditMode);
writer.Write(data.enabled);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		SteamVR_Render data = GetOrCreate<SteamVR_Render>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		SteamVR_Render data = (SteamVR_Render)c;
		// Add your reader.Read calls here to read the data into the object.
data.pauseGameWhenDashboardIsVisible = reader.Read<System.Boolean>();
data.lockPhysicsUpdateRateToRenderFrequency = reader.Read<System.Boolean>();
data.trackingSpace = reader.Read<Valve.VR.ETrackingUniverseOrigin>();
data.useGUILayout = reader.Read<System.Boolean>();
//data.runInEditMode = reader.Read<System.Boolean>();
data.enabled = reader.Read<System.Boolean>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_SteamVR_Render():base(typeof(SteamVR_Render)){}
}