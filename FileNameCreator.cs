using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Library.Helpers
{
	public class FileNameCreator
	{
		public string Create(string name, string path)
		{
			int counter = 1;
			string newName = name, extension = "", tempName = "";
			
			string[] splitName = name.Split('.');

			extension = splitName.Last();

			tempName = String.Join("", splitName.Take(splitName.Length - 1));

			newName = tempName;

			while (System.IO.File.Exists(path + newName + "." + extension))
			{
				newName = tempName + "-" + (counter++).ToString();
			}

			return newName + "." + extension;
		}
	}
}
