using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Main;

public class EmbeddedResource
{
	public static void LoadResource(string embeddedResource, string fileName)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(embeddedResource))
		{
			bool flag = manifestResourceStream == null;
			if (flag)
			{
				throw new Exception(embeddedResource + " is not found in Embedded Resources.");
			}
			byte[] array = new byte[(int)manifestResourceStream.Length];
			manifestResourceStream.Read(array, 0, (int)manifestResourceStream.Length);
			EmbeddedResource.EmbeddedResources.Add(fileName, array);
		}
	}

	public static void LoadAssembly(string embeddedAssembly, string fileName)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(embeddedAssembly))
		{
			bool flag = manifestResourceStream == null;
			if (flag)
			{
				throw new Exception(embeddedAssembly + " is not found in Embedded Resources.");
			}
			byte[] array = new byte[(int)manifestResourceStream.Length];
			manifestResourceStream.Read(array, 0, (int)manifestResourceStream.Length);
			try
			{
				Assembly assembly = Assembly.Load(array);
				EmbeddedResource.EmbeddedAssemblies.Add(assembly.FullName, assembly);
			}
			catch
			{
			}
		}
	}

	public static void ExecuteAssembly(string embeddedAssembly, string fileName)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(embeddedAssembly))
		{
			bool flag = manifestResourceStream == null;
			if (flag)
			{
				throw new Exception(embeddedAssembly + " is not found in Embedded Resources.");
			}
			byte[] array = new byte[(int)manifestResourceStream.Length];
			manifestResourceStream.Read(array, 0, (int)manifestResourceStream.Length);
			try
			{
				Assembly assembly = Assembly.Load(array);
				MethodInfo entryPoint = assembly.EntryPoint;
				entryPoint.Invoke(null, new object[1]);
				Logs.LogEntries.Add("Invoked Updater.exe");
				EmbeddedResource.EmbeddedAssemblies.Add(assembly.FullName, assembly);
			}
			catch (Exception ex)
			{
				Logs.LogEntries.Add("Error: " + ex.ToString());
			}
		}
	}

	public static Assembly Get(string assemblyFullName)
	{
		bool flag = EmbeddedResource.EmbeddedAssemblies.ContainsKey(assemblyFullName);
		Assembly result;
		if (flag)
		{
			result = EmbeddedResource.EmbeddedAssemblies[assemblyFullName];
		}
		else
		{
			result = null;
		}
		return result;
	}

	public static Dictionary<string, Assembly> EmbeddedAssemblies = new Dictionary<string, Assembly>();

	public static Dictionary<string, byte[]> EmbeddedResources = new Dictionary<string, byte[]>();
}
