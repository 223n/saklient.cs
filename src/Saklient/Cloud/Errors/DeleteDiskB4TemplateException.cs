using HttpConflictException = Saklient.Errors.HttpConflictException;

namespace Saklient.Cloud.Errors
{

	/// <summary>要求された操作を行えません。このテンプレートから作成したすべてのディスクを削除した後に実行してください。
	/// </summary>
	public class DeleteDiskB4TemplateException : HttpConflictException
	{
		
		/// <summary>
		/// <param name="status" />
		/// <param name="code" />
		/// <param name="message" />
		/// </summary>
		public DeleteDiskB4TemplateException(long status, string code=null, string message="") : base(status, code, message == null || message == "" ? "要求された操作を行えません。このテンプレートから作成したすべてのディスクを削除した後に実行してください。" : message)
		{
			/*!base!*/;
		}
		
	}
	
}
