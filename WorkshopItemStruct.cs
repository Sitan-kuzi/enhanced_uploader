using System;
using System.Collections.Generic;

namespace WorkshopUploader
{
	public struct WorkshopItemStruct
	{
		public ulong ItemID;
        public int ItemType;
        public string Title;
		public string Description;
        public IList<string> Tags;
        public string Preview;
		public int Visibility;
    }
}
