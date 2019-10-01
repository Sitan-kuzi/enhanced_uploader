using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace WorkshopUploader
{
	// Token: 0x02000002 RID: 2
	internal class AssemblyReferencer
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private static Assembly GetEmbeddedAssembly(ResolveEventArgs args)
		{
			AssemblyName assemblyName = new AssemblyName(args.Name);
			foreach (Assembly assembly in new Assembly[]
			{
				Assembly.GetExecutingAssembly(),
				Assembly.GetEntryAssembly(),
				args.RequestingAssembly
			})
			{
				if (!(assembly == null))
				{
					string name = assemblyName.Name;
					string value = string.Format("ReferencedAssemblies.{0}.dll", name);
					foreach (string text in assembly.GetManifestResourceNames())
					{
						if (text.IndexOf(value, StringComparison.OrdinalIgnoreCase) > -1)
						{
							using (Stream manifestResourceStream = assembly.GetManifestResourceStream(text))
							{
								byte[] array2 = new byte[manifestResourceStream.Length];
								manifestResourceStream.Read(array2, 0, array2.Length);
								Assembly result = null;
								try
								{
									result = Assembly.Load(array2);
								}
								catch
								{
								}
								return result;
							}
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002160 File Offset: 0x00000360
		public static Assembly ResolveAssemblyCallback(object sender, ResolveEventArgs args)
		{
			return AssemblyReferencer.CachedLoadAssembly(args);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002168 File Offset: 0x00000368
		public static Assembly CachedLoadAssembly(ResolveEventArgs args)
		{
			string name = args.Name;
			if (!AssemblyReferencer.ResolvedAssemblies.ContainsKey(name))
			{
				Assembly embeddedAssembly = AssemblyReferencer.GetEmbeddedAssembly(args);
				AssemblyReferencer.ResolvedAssemblies.Add(name, embeddedAssembly);
			}
			return AssemblyReferencer.ResolvedAssemblies[name];
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000021A7 File Offset: 0x000003A7
		public static Stream GetEmbeddedResource(string ResourceName, Assembly ContainingAssembly = null)
		{
			if (ContainingAssembly == null)
			{
				ContainingAssembly = Assembly.GetCallingAssembly();
			}
			return ContainingAssembly.GetManifestResourceStream(string.Format("{0}.{1}", ContainingAssembly.GetName().Name, ResourceName));
		}

		// Token: 0x04000001 RID: 1
		private static Dictionary<string, Assembly> ResolvedAssemblies = new Dictionary<string, Assembly>();
	}
}
