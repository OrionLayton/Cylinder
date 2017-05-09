using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_UnityEngineAudioSource : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		UnityEngine.AudioSource data = (UnityEngine.AudioSource)obj;
		// Add your writer.Write calls here.
writer.Write(data.volume);
writer.Write(data.pitch);
writer.Write(data.time);
writer.Write(data.timeSamples);
writer.Write(data.loop);
writer.Write(data.ignoreListenerVolume);
writer.Write(data.playOnAwake);
writer.Write(data.ignoreListenerPause);
writer.Write(data.velocityUpdateMode);
writer.Write(data.panStereo);
writer.Write(data.spatialBlend);
writer.Write(data.spatialize);
writer.Write(data.spatializePostEffects);
writer.Write(data.reverbZoneMix);
writer.Write(data.bypassEffects);
writer.Write(data.bypassListenerEffects);
writer.Write(data.bypassReverbZones);
writer.Write(data.dopplerLevel);
writer.Write(data.spread);
writer.Write(data.priority);
writer.Write(data.mute);
writer.Write(data.minDistance);
writer.Write(data.maxDistance);
writer.Write(data.rolloffMode);
writer.Write(data.enabled);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		UnityEngine.AudioSource data = GetOrCreate<UnityEngine.AudioSource>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		UnityEngine.AudioSource data = (UnityEngine.AudioSource)c;
		// Add your reader.Read calls here to read the data into the object.
data.volume = reader.Read<System.Single>();
data.pitch = reader.Read<System.Single>();
data.time = reader.Read<System.Single>();
data.timeSamples = reader.Read<System.Int32>();
data.loop = reader.Read<System.Boolean>();
data.ignoreListenerVolume = reader.Read<System.Boolean>();
data.playOnAwake = reader.Read<System.Boolean>();
data.ignoreListenerPause = reader.Read<System.Boolean>();
data.velocityUpdateMode = reader.Read<UnityEngine.AudioVelocityUpdateMode>();
data.panStereo = reader.Read<System.Single>();
data.spatialBlend = reader.Read<System.Single>();
data.spatialize = reader.Read<System.Boolean>();
data.spatializePostEffects = reader.Read<System.Boolean>();
data.reverbZoneMix = reader.Read<System.Single>();
data.bypassEffects = reader.Read<System.Boolean>();
data.bypassListenerEffects = reader.Read<System.Boolean>();
data.bypassReverbZones = reader.Read<System.Boolean>();
data.dopplerLevel = reader.Read<System.Single>();
data.spread = reader.Read<System.Single>();
data.priority = reader.Read<System.Int32>();
data.mute = reader.Read<System.Boolean>();
data.minDistance = reader.Read<System.Single>();
data.maxDistance = reader.Read<System.Single>();
data.rolloffMode = reader.Read<UnityEngine.AudioRolloffMode>();
data.enabled = reader.Read<System.Boolean>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_UnityEngineAudioSource():base(typeof(UnityEngine.AudioSource)){}
}