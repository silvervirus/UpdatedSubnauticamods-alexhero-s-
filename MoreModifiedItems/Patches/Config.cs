using System;
using Nautilus.Json;
using Nautilus.Options.Attributes;

namespace AlexejheroYTB.MoreModifiedItems.Patches
{
	// Token: 0x0200000A RID: 10
	[Menu("MoreModifiedItems")]
	public class Config : ConfigFile
	{
		// Token: 0x0400001B RID: 27
		[Slider("currentWreckSpeedMultiplier ", 0.1f, 10f, DefaultValue = 1f, Format = "{0:R0}")]
		public float currentWreckSpeedMultiplier = 0f;
	}
}
