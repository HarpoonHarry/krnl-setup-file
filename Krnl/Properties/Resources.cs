using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Krnl.Properties
{
	// Token: 0x02000005 RID: 5
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002795 File Offset: 0x00000995
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000015 RID: 21 RVA: 0x0000279D File Offset: 0x0000099D
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Krnl.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000027C9 File Offset: 0x000009C9
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000027D0 File Offset: 0x000009D0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000027D8 File Offset: 0x000009D8
		internal static byte[] _7z_NET
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("_7z_NET", Resources.resourceCulture);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000027F3 File Offset: 0x000009F3
		internal static byte[] _7za
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("_7za", Resources.resourceCulture);
			}
		}

		// Token: 0x0400001E RID: 30
		private static ResourceManager resourceMan;

		// Token: 0x0400001F RID: 31
		private static CultureInfo resourceCulture;
	}
}
