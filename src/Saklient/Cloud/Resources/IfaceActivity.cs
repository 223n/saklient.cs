using Util = Saklient.Util;
using Client = Saklient.Cloud.Client;
using Activity = Saklient.Cloud.Resources.Activity;
using IfaceActivitySample = Saklient.Cloud.Resources.IfaceActivitySample;

namespace Saklient.Cloud.Resources
{

	public class IfaceActivity : Activity
	{
		
		internal System.Collections.Generic.List<IfaceActivitySample> _Samples;

        internal System.Collections.Generic.List<IfaceActivitySample> Get_samples() => this._Samples;

        /// <summary>サンプル列
        /// </summary>
        public System.Collections.Generic.List<IfaceActivitySample> Samples => this.Get_samples();

        internal override string _ApiPathPrefix() => "/interface";

        internal override string _ApiPathSuffix() => "/monitor";

        public IfaceActivity(Client client) : base(client)
		{
			/*!base!*/
		}

        internal override void _AddSample(string atStr, object data) => (this._Samples as System.Collections.IList).Add(new IfaceActivitySample(atStr, data));

        /// <summary>現在の最新のアクティビティ情報を取得し、samplesに格納します。
        ///  
        ///  	 * @return this
        /// 
        /// <param name="startDate" />
        /// <param name="endDate" />
        /// </summary>
        public IfaceActivity Fetch(System.DateTime? startDate=null, System.DateTime? endDate=null)
		{
			this._Samples = new System.Collections.Generic.List<IfaceActivitySample> {  };
			return ((IfaceActivity)(this._Fetch(startDate, endDate)));
		}
		
	}
	
}
