using HttpConflictException = Saklient.Errors.HttpConflictException;

namespace Saklient.Cloud.Errors
{

	/// <summary>要求された操作を行えません。このテンプレートは不完全です。複製処理等の完了後に再度お試しください。
	/// </summary>
	public class TemplateIsIncompleteException : HttpConflictException
	{
		
		/// <summary>
		/// <param name="status" />
		/// <param name="code" />
		/// <param name="message" />
		/// </summary>
		public TemplateIsIncompleteException(long status, string code=null, string message="") : base(status, code, message == null || message == "" ? "要求された操作を行えません。このテンプレートは不完全です。複製処理等の完了後に再度お試しください。" : message)
		{
			/*!base!*/;
		}
		
	}
	
}
