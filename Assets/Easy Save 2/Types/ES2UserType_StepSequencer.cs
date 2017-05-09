using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_StepSequencer : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		StepSequencer data = (StepSequencer)obj;
		// Add your writer.Write calls here.
//writer.Write(data.pink1);writer.Write(data.purple1);writer.Write(data.purple2);writer.Write(data.purple3);writer.Write(data.purple4);writer.Write(data.purple5);writer.Write(data.green1);writer.Write(data.green2);writer.Write(data.yellow1);writer.Write(data.blue1);writer.Write(data.red1);writer.Write(data.tempo);writer.Write(data.useGUILayout);
//writer.Write(data.runInEditMode);
writer.Write(data.enabled);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		StepSequencer data = GetOrCreate<StepSequencer>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		StepSequencer data = (StepSequencer)c;
		// Add your reader.Read calls here to read the data into the object.
//data.pink1 = reader.Read<UnityEngine.Color>();
//data.purple1 = reader.Read<UnityEngine.Color>();
//data.purple2 = reader.Read<UnityEngine.Color>();
//data.purple3 = reader.Read<UnityEngine.Color>();
//data.purple4 = reader.Read<UnityEngine.Color>();
//data.purple5 = reader.Read<UnityEngine.Color>();
//data.green1 = reader.Read<UnityEngine.Color>();
//data.green2 = reader.Read<UnityEngine.Color>();
//data.yellow1 = reader.Read<UnityEngine.Color>();
//data.blue1 = reader.Read<UnityEngine.Color>();
//data.red1 = reader.Read<UnityEngine.Color>();
data.tempo = reader.Read<System.Single>();
data.useGUILayout = reader.Read<System.Boolean>();
//data.runInEditMode = reader.Read<System.Boolean>();
data.enabled = reader.Read<System.Boolean>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_StepSequencer():base(typeof(StepSequencer)){}
}