using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_UnityEngineAudioListener : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		UnityEngine.AudioListener data = (UnityEngine.AudioListener)obj;
		// Add your writer.Write calls here.
writer.Write(data.velocityUpdateMode);
writer.Write(data.enabled);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		UnityEngine.AudioListener data = GetOrCreate<UnityEngine.AudioListener>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		UnityEngine.AudioListener data = (UnityEngine.AudioListener)c;
		// Add your reader.Read calls here to read the data into the object.
data.velocityUpdateMode = reader.Read<UnityEngine.AudioVelocityUpdateMode>();
data.enabled = reader.Read<System.Boolean>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_UnityEngineAudioListener():base(typeof(UnityEngine.AudioListener)){}
}