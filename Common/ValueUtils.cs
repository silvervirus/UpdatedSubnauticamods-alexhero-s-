using System;
using UnityEngine;

namespace AlexejheroYTB.Common
{
	// Token: 0x02000008 RID: 8
	public static class ValueUtils
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002624 File Offset: 0x00000824
		public static bool ToNormalBool(this bool? nullableBool)
		{
			bool flag3;
			if (nullableBool != null)
			{
				bool? flag = nullableBool;
				bool flag2 = false;
				flag3 = (flag.GetValueOrDefault() == flag2 & flag != null);
			}
			else
			{
				flag3 = true;
			}
			bool flag4 = flag3;
			bool result;
			if (flag4)
			{
				result = false;
			}
			else
			{
				bool? flag = nullableBool;
				bool flag2 = true;
				bool flag5 = flag.GetValueOrDefault() == flag2 & flag != null;
				result = flag5;
			}
			return result;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002684 File Offset: 0x00000884
		public static Predicate<T> ToPredicate<T>(this bool @bool)
		{
			Predicate<T> result;
			if (@bool)
			{
				result = ((T obj) => true);
			}
			else
			{
				result = ((T obj) => false);
			}
			return result;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000026DC File Offset: 0x000008DC
		public static Sprite ToSprite(this Texture2D texture)
		{
			return Sprite.Create(texture, new Rect(0f, 0f, (float)texture.width, (float)texture.height), Vector2.zero);
		}
	}
}
