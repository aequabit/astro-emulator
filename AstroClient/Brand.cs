using System;
using System.Diagnostics;
using Resources;

namespace Main
{
	public class Brand
	{
		public static string Version = "0.31b";

		public static Companys Company = Companys.Maverick;

		public static string ExeName = Process.GetCurrentProcess().MainModule.ModuleName;

		public static string ProcName = Brand.ExeName.Replace(".exe", "");

		public static string OAuthLink = (Brand.Company == Companys.Maverick) ? "https://maverickcheats.net/community/oauth/authorize/?response_type=code&client_id=28129bf1088c7c7cc694fe7b95712417&redirect_uri=https://maverickcheats.net/community/maverickcheats/OAuth2.php&scope=profile&state=state1234" : "https://astrocheats.net/dashboard/oauth/authorize/?response_type=code&client_id=8a8012361ee2fcebb9b3f7e680f99eaf&redirect_uri=https://astrocheats.net/dashboard/astrocheats/OAuth2.php&scope=profile&state=state1234";

		public static string ProfileLink = (Brand.Company == Companys.Maverick) ? "https://maverickcheats.net/community/profile/" : "https://astrocheats.net/dashboard/profile/";
	}
}
