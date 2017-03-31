using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace resimindir
{
	class Program
	{
		static void Main(string[] args)
		{
				DownloadRemoteImageFile(resimUrl, @"D:\resimler\resim_ismi.png");
				Console.WriteLine(resimUrl);
		}

		private static void DownloadRemoteImageFile(string uri, string fileName)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			if ((response.StatusCode == HttpStatusCode.OK ||
				response.StatusCode == HttpStatusCode.Moved ||
				response.StatusCode == HttpStatusCode.Redirect) &&
				response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
			{
				using (Stream inputStream = response.GetResponseStream())
				using (Stream outputStream = File.OpenWrite(fileName))
				{
					byte[] buffer = new byte[4096];
					int bytesRead;
					do
					{
						bytesRead = inputStream.Read(buffer, 0, buffer.Length);
						outputStream.Write(buffer, 0, bytesRead);
					} while (bytesRead != 0);
				}
			}
		}
	}
}
