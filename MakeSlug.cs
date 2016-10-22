using System.Text.RegularExpressions;
using System.Web;

namespace Codes
{
	public class MakeSlug
	{
		public string Slug(string text)
		{

			string Slug = Regex.Replace(HttpUtility.HtmlDecode(text.Replace("&nbsp;", string.Empty)), "<.*?>", string.Empty);

			Slug = Slug.ToLower().Trim();

			Slug = Slug.Replace('ı', 'i');
			Slug = Slug.Replace('ü', 'u');
			Slug = Slug.Replace('ö', 'o');
			Slug = Slug.Replace('ç', 'c');
			Slug = Slug.Replace('ğ', 'g');
			Slug = Slug.Replace('ş', 's');


			Slug = Regex.Replace(Slug, @"[^0-9a-z\s]+", string.Empty);
			Slug = Regex.Replace(Slug, @"\s+", "-");

			return Slug;
		}

	}
}
