using Util = Saklient.Util;
using Client = Saklient.Cloud.Client;
using Activity = Saklient.Cloud.Resources.Activity;
using DiskActivitySample = Saklient.Cloud.Resources.DiskActivitySample;

namespace Saklient.Cloud.Resources
{

	public class DiskActivity : Activity
	{
		
		internal System.Collections.Generic.List<DiskActivitySample> _Samples;

        internal System.Collections.Generic.List<DiskActivitySample> Get_samples() => this._Samples;

        /// <summary>サンプル列
        /// </summary>
        public System.Collections.Generic.List<DiskActivitySample> Samples => this.Get_samples();

        internal override string _ApiPathPrefix() => "/disk";

        public DiskActivity(Client client) : base(client)
		{
			/*!base!*/
		}

        internal override void _AddSample(string atStr, object data) => (this._Samples as System.Collections.IList).Add(new DiskActivitySample(atStr, data));

        /// <summary>現在の最新のアクティビティ情報を取得し、samplesに格納します。
        ///  
        ///  	 * @return this
        /// 
        /// <param name="startDate" />
        /// <param name="endDate" />
        /// </summary>
        public DiskActivity Fetch(System.DateTime? startDate=null, System.DateTime? endDate=null)
		{
			this._Samples = new System.Collections.Generic.List<DiskActivitySample> {  };
			return ((DiskActivity)(this._Fetch(startDate, endDate)));
		}
		
	}
	
}
