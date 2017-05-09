using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_Resizer : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		Resizer data = (Resizer)obj;
		// Add your writer.Write calls here.
writer.Write(data.useGUILayout);
//writer.Write(data.runInEditMode);
writer.Write(data.enabled);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		Resizer data = GetOrCreate<Resizer>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		Resizer data = (Resizer)c;
		// Add your reader.Read calls here to read the data into the object.
data.useGUILayout = reader.Read<System.Boolean>();
//data.runInEditMode = reader.Read<System.Boolean>();
data.enabled = reader.Read<System.Boolean>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_Resizer():base(typeof(Resizer)){}
}