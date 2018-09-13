using Util = Saklient.Util;

namespace Saklient.Cloud.Resources
{

	/// <summary>FTPサーバのアカウント情報。
	/// </summary>
	public class FtpInfo
	{
		
		internal string _HostName;

        public string Get_hostName() => this._HostName;

        /// <summary>ホスト名
        /// </summary>
        public string HostName => this.Get_hostName();

        internal string _User;

        public string Get_user() => this._User;

        /// <summary>ユーザ名
        /// </summary>
        public string User => this.Get_user();

        internal string _Password;

        public string Get_password() => this._Password;

        /// <summary>パスワード
        /// </summary>
        public string Password => this.Get_password();

        public FtpInfo(object obj)
		{
			this._HostName = ((string)((obj as System.Collections.Generic.Dictionary<string, object>)["HostName"]));
			this._User = ((string)((obj as System.Collections.Generic.Dictionary<string, object>)["User"]));
			this._Password = ((string)((obj as System.Collections.Generic.Dictionary<string, object>)["Password"]));
		}
		
	}
	
}
