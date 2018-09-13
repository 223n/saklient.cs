using Util = Saklient.Util;

namespace Saklient.Cloud.Resources
{

    /// <summary>
    /// 
    /// </summary>
    public class RouterActivitySample
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

        internal double _Outgoing;

        public double Get_outgoing() => this._Outgoing;

        /// <summary>送信[BPS]
        /// </summary>
        public double Outgoing => this.Get_outgoing();

        internal double _Incoming;

        public double Get_incoming() => this._Incoming;

        /// <summary>受信[BPS]
        /// </summary>
        public double Incoming => this.Get_incoming();

        /// <summary>
        /// <param name="atStr" />
        /// <param name="data" />
        /// </summary>
        public RouterActivitySample(string atStr, object data)
        {
            this._At = ((System.DateTime)(Util.Str2date(atStr)));
            this._IsAvailable = true;
            object v = null;
            v = (data as System.Collections.Generic.Dictionary<string, object>)["Out"];
            if (v == null)
                this._IsAvailable = false;
            else
                this._Outgoing = ((double)(v));
            v = (data as System.Collections.Generic.Dictionary<string, object>)["In"];
            if (v == null)
                this._IsAvailable = false;
            else
                this._Incoming = ((double)(v));
        }

    }

}
