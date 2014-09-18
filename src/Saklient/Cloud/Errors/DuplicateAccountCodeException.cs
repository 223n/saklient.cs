using HttpConflictException = Saklient.Errors.HttpConflictException;

namespace Saklient.Cloud.Errors
{

	/**
	 * 要求された操作を行えません。同一アカウント名で複数のアカウントを作成することはできません。
	 */
	public class DuplicateAccountCodeException : HttpConflictException
	{
		
		/**
		 * @constructor
		 * @public
		 * @param {long} status
		 * @param {string} code=null
		 * @param {string} message=""
		 */
		public DuplicateAccountCodeException(long status, string code=null, string message="") : base(status, code, message == null || message == "" ? "要求された操作を行えません。同一アカウント名で複数のアカウントを作成することはできません。" : message)
		{
			/*!base!*/;
		}
		
	}
	
}
