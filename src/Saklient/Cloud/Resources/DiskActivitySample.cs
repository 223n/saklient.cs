using Util = Saklient.Util;

namespace Saklient.Cloud.Resources
{

    /// <summary>
    /// 
    /// </summary>
    public class DiskActivitySample
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

        internal double _Write;

        public double Get_write() => this._Write;

        /// <summary>ライト[BPS]
        /// </summary>
        public double Write => this.Get_write();

        internal double _Read;

        public double Get_read() => this._Read;

        /// <summary>リード[BPS]
        /// </summary>
        public double Read => this.Get_read();

        /// <summary>
        /// <param name="atStr" />
        /// <param name="data" />
        /// </summary>
        public DiskActivitySample(string atStr, object data)
        {
            this._At = ((System.DateTime)(Util.Str2date(atStr)));
            this._IsAvailable = true;
            object v = null;
            v = (data as System.Collections.Generic.Dictionary<string, object>)["Write"];
            if (v == null)
                this._IsAvailable = false;
            else
                this._Write = ((double)(v));
            v = (data as System.Collections.Generic.Dictionary<string, object>)["Read"];
            if (v == null)
                this._IsAvailable = false;
            else
                this._Read = ((double)(v));
        }

    }

}
