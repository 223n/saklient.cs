using Util = Saklient.Util;

namespace Saklient.Cloud.Resources
{

	/// <summary>
	/// 
	/// </summary>
	public class ServerActivitySample
	{
		
		internal System.DateTime _At;

        public System.DateTime Get_at() => this._At;

        /// <summary>記録日時
        /// </summary>
        public System.DateTime At => this.Get_at();

        internal bool _IsAvailable;

        public bool Get_isAvailable() => this._IsAvailable;

        /// <summary>有効な値のとき真
        /// </summary>
        public bool IsAvailable => this.Get_isAvailable();

        internal double _CpuTime;

        public double Get_cpuTime() => this._CpuTime;

        /// <summary>CPU時間
        /// </summary>
        public double CpuTime => this.Get_cpuTime();

        /// <summary>
        /// <param name="atStr" />
        /// <param name="data" />
        /// </summary>
        public ServerActivitySample(string atStr, object data)
		{
			this._At = ((System.DateTime)(Util.Str2date(atStr)));
			this._IsAvailable = false;
			object v = (data as System.Collections.Generic.Dictionary<string, object>)["CPU-TIME"];
			if (v != null) {
				this._IsAvailable = true;
				this._CpuTime = ((double)(v));
			}
		}
		
	}
	
}
