using System;
using System.IO;
using System.Reflection;

namespace AlexejheroYTB.Common
{
	// Token: 0x02000007 RID: 7
	public class PathHelper
	{
		// Token: 0x06000011 RID: 17 RVA: 0x000025BC File Offset: 0x000007BC
		public static string GetDLLPath()
		{
			return Assembly.GetCallingAssembly().Location;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000025C8 File Offset: 0x000007C8
		public PathHelper(string path)
		{
			this.Path = path;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000025D8 File Offset: 0x000007D8
		public PathHelper Append(string pathToAppend)
		{
			PathHelper pathHelper = new PathHelper(this.Path);
			pathHelper.Path = System.IO.Path.Combine(pathHelper.Path, pathToAppend);
			return pathHelper;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002609 File Offset: 0x00000809
		public static PathHelper operator +(PathHelper currentPath, string pathToAppend)
		{
			return currentPath.Append(pathToAppend);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002612 File Offset: 0x00000812
		public static implicit operator PathHelper(string s)
		{
			return new PathHelper(s);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000261A File Offset: 0x0000081A
		public static implicit operator string(PathHelper p)
		{
			return p.Path;
		}

		// Token: 0x0400001A RID: 26
		public string Path;
	}
}
