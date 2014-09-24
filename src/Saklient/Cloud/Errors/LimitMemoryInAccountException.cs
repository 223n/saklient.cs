using HttpConflictException = Saklient.Errors.HttpConflictException;

namespace Saklient.Cloud.Errors
{

	/// <summary>要求を受け付けできません。アカウントあたりの全サーバメモリサイズ上限により、リソースの割り当てに失敗しました。
	/// </summary>
	public class LimitMemoryInAccountException : HttpConflictException
	{
		
		/// <summary>
		/// <param name="status" />
		/// <param name="code" />
		/// <param name="message" />
		/// </summary>
		public LimitMemoryInAccountException(long status, string code=null, string message="") : base(status, code, message == null || message == "" ? "要求を受け付けできません。アカウントあたりの全サーバメモリサイズ上限により、リソースの割り当てに失敗しました。" : message)
		{
			/*!base!*/;
		}
		
	}
	
}
