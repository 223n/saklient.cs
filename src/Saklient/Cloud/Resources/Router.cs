using Util = Saklient.Util;
using SaklientException = Saklient.Errors.SaklientException;
using Client = Saklient.Cloud.Client;
using Resource = Saklient.Cloud.Resources.Resource;
using Icon = Saklient.Cloud.Resources.Icon;
using Swytch = Saklient.Cloud.Resources.Swytch;
using Ipv4Net = Saklient.Cloud.Resources.Ipv4Net;
using Ipv6Net = Saklient.Cloud.Resources.Ipv6Net;
using Model_Swytch = Saklient.Cloud.Models.Model_Swytch;

namespace Saklient.Cloud.Resources
{

	/**
	 * ルータの実体1つに対応し、属性の取得や操作を行うためのクラス。
	 * 
	 * @module saklient.cloud.resources.Router
	 * @class Router
	 * @constructor
	 * @extends Resource
	 */
	public class Router : Resource
	{
		
		/**
		 * ID
		 * 
		 * @member saklient.cloud.resources.Router#M_id
		 * @type string
		 * @internal
		 */
		internal string M_id;
		
		/**
		 * 名前
		 * 
		 * @member saklient.cloud.resources.Router#M_name
		 * @type string
		 * @internal
		 */
		internal string M_name;
		
		/**
		 * 説明
		 * 
		 * @member saklient.cloud.resources.Router#M_description
		 * @type string
		 * @internal
		 */
		internal string M_description;
		
		/**
		 * ネットワークのマスク長
		 * 
		 * @member saklient.cloud.resources.Router#M_networkMaskLen
		 * @type long?
		 * @internal
		 */
		internal long? M_networkMaskLen;
		
		/**
		 * 帯域幅
		 * 
		 * @member saklient.cloud.resources.Router#M_bandWidthMbps
		 * @type long?
		 * @internal
		 */
		internal long? M_bandWidthMbps;
		
		/**
		 * スイッチ
		 * 
		 * @member saklient.cloud.resources.Router#M_swytchId
		 * @type string
		 * @internal
		 */
		internal string M_swytchId;
		
		/**
		 * @private
		 * @method _ApiPath
		 * @internal
		 * @ignore
		 * @return {string}
		 */
		internal override string _ApiPath()
		{
			return "/internet";
		}
		
		/**
		 * @private
		 * @method _RootKey
		 * @internal
		 * @ignore
		 * @return {string}
		 */
		internal override string _RootKey()
		{
			return "Internet";
		}
		
		/**
		 * @private
		 * @method _RootKeyM
		 * @internal
		 * @ignore
		 * @return {string}
		 */
		internal override string _RootKeyM()
		{
			return "Internet";
		}
		
		/**
		 * @private
		 * @method _ClassName
		 * @ignore
		 * @return {string}
		 */
		public override string _ClassName()
		{
			return "Router";
		}
		
		/**
		 * @private
		 * @method _Id
		 * @ignore
		 * @return {string}
		 */
		public override string _Id()
		{
			return this.Get_id();
		}
		
		/**
		 * このローカルオブジェクトに現在設定されているリソース情報をAPIに送信し、新規作成または上書き保存します。
		 * 
		 * @method Save
		 * @chainable
		 * @public
		 * @return {Router} this
		 */
		public Router Save()
		{
			return ((Router)(this._Save()));
		}
		
		/**
		 * 最新のリソース情報を再取得します。
		 * 
		 * @method Reload
		 * @chainable
		 * @public
		 * @return {Router} this
		 */
		public Router Reload()
		{
			return ((Router)(this._Reload()));
		}
		
		/**
		 * @ignore
		 * @constructor
		 * @param {Client} client
		 * @param {object} obj
		 * @param {bool} wrapped=false
		 */
		public Router(Client client, object obj, bool wrapped=false) : base(client)
		{
			/*!base!*/;
			this.ApiDeserialize(obj, wrapped);
		}
		
		/**
		 * 作成中のルータが利用可能になるまで待機します。
		 * 
		 * @ignore
		 * @method AfterCreate
		 * @param {long} timeoutSec
		 * @param {System.Action<Router, bool>} callback
		 * @return {void}
		 */
		public void AfterCreate(long timeoutSec, System.Action<Router, bool> callback)
		{
			bool ret = this.SleepWhileCreating(timeoutSec);
			callback(this, ret);
		}
		
		/**
		 * 作成中のルータが利用可能になるまで待機します。
		 * 
		 * @method SleepWhileCreating
		 * @public
		 * @param {long} timeoutSec=120
		 * @return {bool} 成功時はtrue、タイムアウトやエラーによる失敗時はfalseを返します。
		 */
		public bool SleepWhileCreating(long timeoutSec=120)
		{
			long step = 3;
			while (0 < timeoutSec) {
				if (this.Exists()) {
					this.Reload();
					return true;
				}
				timeoutSec -= step;
				if (0 < timeoutSec) {
					Util.Sleep(step);
				}
			}
			return false;
		}
		
		/**
		 * このルータが接続されているスイッチを取得します。
		 * 
		 * @method GetSwytch
		 * @public
		 * @return {Swytch}
		 */
		public Swytch GetSwytch()
		{
			Model_Swytch model = new Model_Swytch(this._Client);
			string id = this.Get_swytchId();
			return model.GetById(id);
		}
		
		/**
		 * このルータ＋スイッチでIPv6アドレスを有効にします。
		 * 
		 * @method AddIpv6Net
		 * @public
		 * @return {Ipv6Net} 有効化されたIPv6ネットワーク
		 */
		public Ipv6Net AddIpv6Net()
		{
			object result = this._Client.Request("POST", this._ApiPath() + "/" + Util.UrlEncode(this._Id()) + "/ipv6net");
			this.Reload();
			return new Ipv6Net(this._Client, (result as System.Collections.Generic.Dictionary<string, object>)["IPv6Net"]);
		}
		
		/**
		 * このルータ＋スイッチでIPv6アドレスを無効にします。
		 * 
		 * @method RemoveIpv6Net
		 * @chainable
		 * @public
		 * @param {Ipv6Net} ipv6Net
		 * @return {Router} this
		 */
		public Router RemoveIpv6Net(Ipv6Net ipv6Net)
		{
			this._Client.Request("DELETE", this._ApiPath() + "/" + Util.UrlEncode(this._Id()) + "/ipv6net/" + ipv6Net._Id());
			this.Reload();
			return this;
		}
		
		/**
		 * このルータ＋スイッチにスタティックルートを追加します。
		 * 
		 * @method AddStaticRoute
		 * @public
		 * @param {long} maskLen
		 * @param {string} nextHop
		 * @return {Ipv4Net} 追加されたスタティックルート
		 */
		public Ipv4Net AddStaticRoute(long maskLen, string nextHop)
		{
			object q = new System.Collections.Generic.Dictionary<string, object> {};
			Util.SetByPath(q, "NetworkMaskLen", maskLen);
			Util.SetByPath(q, "NextHop", nextHop);
			object result = this._Client.Request("POST", this._ApiPath() + "/" + Util.UrlEncode(this._Id()) + "/subnet", q);
			this.Reload();
			return new Ipv4Net(this._Client, (result as System.Collections.Generic.Dictionary<string, object>)["Subnet"]);
		}
		
		/**
		 * このルータ＋スイッチからスタティックルートを削除します。
		 * 
		 * @method RemoveStaticRoute
		 * @chainable
		 * @public
		 * @param {Ipv4Net} ipv4Net
		 * @return {Router} this
		 */
		public Router RemoveStaticRoute(Ipv4Net ipv4Net)
		{
			this._Client.Request("DELETE", this._ApiPath() + "/" + Util.UrlEncode(this._Id()) + "/subnet/" + ipv4Net._Id());
			this.Reload();
			return this;
		}
		
		/**
		 * このルータ＋スイッチの帯域プランを変更します。
		 * 
		 * 成功時はリソースIDが変わることにご注意ください。
		 * 
		 * @method ChangePlan
		 * @chainable
		 * @public
		 * @param {long} bandWidthMbps
		 * @return {Router} this
		 */
		public Router ChangePlan(long bandWidthMbps)
		{
			string path = this._ApiPath() + "/" + Util.UrlEncode(this._Id()) + "/bandwidth";
			object q = new System.Collections.Generic.Dictionary<string, object> {};
			Util.SetByPath(q, "Internet.BandWidthMbps", bandWidthMbps);
			object result = this._Client.Request("PUT", path, q);
			this.ApiDeserialize(result, true);
			return this;
		}
		
		/**
		 * @member saklient.cloud.resources.Router#N_id
		 * @default false
		 * @type bool
		 * @private
		 */
		private bool N_id = false;
		
		/**
		 * (This method is generated in Translator_default#buildImpl)
		 * 
		 * @method Get_id
		 * @private
		 * @ignore
		 * @return {string}
		 */
		private string Get_id()
		{
			return this.M_id;
		}
		
		/**
		 * ID
		 * 
		 * @property Id
		 * @type string
		 * @readOnly
		 * @public
		 */
		public string Id
		{
			get { return this.Get_id(); }
		}
		
		/**
		 * @member saklient.cloud.resources.Router#N_name
		 * @default false
		 * @type bool
		 * @private
		 */
		private bool N_name = false;
		
		/**
		 * (This method is generated in Translator_default#buildImpl)
		 * 
		 * @method Get_name
		 * @private
		 * @ignore
		 * @return {string}
		 */
		private string Get_name()
		{
			return this.M_name;
		}
		
		/**
		 * (This method is generated in Translator_default#buildImpl)
		 * 
		 * @method Set_name
		 * @private
		 * @ignore
		 * @param {string} v
		 * @return {string}
		 */
		private string Set_name(string v)
		{
			this.M_name = v;
			this.N_name = true;
			return this.M_name;
		}
		
		/**
		 * 名前
		 * 
		 * @property Name
		 * @type string
		 * @public
		 */
		public string Name
		{
			get { return this.Get_name(); }
			set { this.Set_name(value); }
		}
		
		/**
		 * @member saklient.cloud.resources.Router#N_description
		 * @default false
		 * @type bool
		 * @private
		 */
		private bool N_description = false;
		
		/**
		 * (This method is generated in Translator_default#buildImpl)
		 * 
		 * @method Get_description
		 * @private
		 * @ignore
		 * @return {string}
		 */
		private string Get_description()
		{
			return this.M_description;
		}
		
		/**
		 * (This method is generated in Translator_default#buildImpl)
		 * 
		 * @method Set_description
		 * @private
		 * @ignore
		 * @param {string} v
		 * @return {string}
		 */
		private string Set_description(string v)
		{
			this.M_description = v;
			this.N_description = true;
			return this.M_description;
		}
		
		/**
		 * 説明
		 * 
		 * @property Description
		 * @type string
		 * @public
		 */
		public string Description
		{
			get { return this.Get_description(); }
			set { this.Set_description(value); }
		}
		
		/**
		 * @member saklient.cloud.resources.Router#N_networkMaskLen
		 * @default false
		 * @type bool
		 * @private
		 */
		private bool N_networkMaskLen = false;
		
		/**
		 * (This method is generated in Translator_default#buildImpl)
		 * 
		 * @method Get_networkMaskLen
		 * @private
		 * @ignore
		 * @return {long?}
		 */
		private long? Get_networkMaskLen()
		{
			return this.M_networkMaskLen;
		}
		
		/**
		 * (This method is generated in Translator_default#buildImpl)
		 * 
		 * @method Set_networkMaskLen
		 * @private
		 * @ignore
		 * @param {long?} v
		 * @return {long?}
		 */
		private long? Set_networkMaskLen(long? v)
		{
			if (!this.IsNew) {
				throw new SaklientException("immutable_field", "Immutable fields cannot be modified after the resource creation: " + "saklient.cloud.resources.Router#Set_networkMaskLen");
			}
			this.M_networkMaskLen = v;
			this.N_networkMaskLen = true;
			return this.M_networkMaskLen;
		}
		
		/**
		 * ネットワークのマスク長
		 * 
		 * @property NetworkMaskLen
		 * @type long?
		 * @public
		 */
		public long? NetworkMaskLen
		{
			get { return this.Get_networkMaskLen(); }
			set { this.Set_networkMaskLen(value); }
		}
		
		/**
		 * @member saklient.cloud.resources.Router#N_bandWidthMbps
		 * @default false
		 * @type bool
		 * @private
		 */
		private bool N_bandWidthMbps = false;
		
		/**
		 * (This method is generated in Translator_default#buildImpl)
		 * 
		 * @method Get_bandWidthMbps
		 * @private
		 * @ignore
		 * @return {long?}
		 */
		private long? Get_bandWidthMbps()
		{
			return this.M_bandWidthMbps;
		}
		
		/**
		 * (This method is generated in Translator_default#buildImpl)
		 * 
		 * @method Set_bandWidthMbps
		 * @private
		 * @ignore
		 * @param {long?} v
		 * @return {long?}
		 */
		private long? Set_bandWidthMbps(long? v)
		{
			if (!this.IsNew) {
				throw new SaklientException("immutable_field", "Immutable fields cannot be modified after the resource creation: " + "saklient.cloud.resources.Router#Set_bandWidthMbps");
			}
			this.M_bandWidthMbps = v;
			this.N_bandWidthMbps = true;
			return this.M_bandWidthMbps;
		}
		
		/**
		 * 帯域幅
		 * 
		 * @property BandWidthMbps
		 * @type long?
		 * @public
		 */
		public long? BandWidthMbps
		{
			get { return this.Get_bandWidthMbps(); }
			set { this.Set_bandWidthMbps(value); }
		}
		
		/**
		 * @member saklient.cloud.resources.Router#N_swytchId
		 * @default false
		 * @type bool
		 * @private
		 */
		private bool N_swytchId = false;
		
		/**
		 * (This method is generated in Translator_default#buildImpl)
		 * 
		 * @method Get_swytchId
		 * @private
		 * @ignore
		 * @return {string}
		 */
		private string Get_swytchId()
		{
			return this.M_swytchId;
		}
		
		/**
		 * スイッチ
		 * 
		 * @property SwytchId
		 * @type string
		 * @readOnly
		 * @public
		 */
		public string SwytchId
		{
			get { return this.Get_swytchId(); }
		}
		
		/**
		 * (This method is generated in Translator_default#buildImpl)
		 * 
		 * @method ApiDeserializeImpl
		 * @internal
		 * @param {object} r
		 */
		internal override void ApiDeserializeImpl(object r)
		{
			this.IsNew = r == null;
			if (this.IsNew) {
				r = new System.Collections.Generic.Dictionary<string, object> {  };
			}
			this.IsIncomplete = false;
			if (Util.ExistsPath(r, "ID")) {
				this.M_id = Util.GetByPath(r, "ID") == null ? null : "" + Util.GetByPath(r, "ID");
			}
			else {
				this.M_id = null;
				this.IsIncomplete = true;
			}
			this.N_id = false;
			if (Util.ExistsPath(r, "Name")) {
				this.M_name = Util.GetByPath(r, "Name") == null ? null : "" + Util.GetByPath(r, "Name");
			}
			else {
				this.M_name = null;
				this.IsIncomplete = true;
			}
			this.N_name = false;
			if (Util.ExistsPath(r, "Description")) {
				this.M_description = Util.GetByPath(r, "Description") == null ? null : "" + Util.GetByPath(r, "Description");
			}
			else {
				this.M_description = null;
				this.IsIncomplete = true;
			}
			this.N_description = false;
			if (Util.ExistsPath(r, "NetworkMaskLen")) {
				this.M_networkMaskLen = Util.GetByPath(r, "NetworkMaskLen") == null ? null : (long?)System.Convert.ToInt64("" + Util.GetByPath(r, "NetworkMaskLen"));
			}
			else {
				this.M_networkMaskLen = null;
				this.IsIncomplete = true;
			}
			this.N_networkMaskLen = false;
			if (Util.ExistsPath(r, "BandWidthMbps")) {
				this.M_bandWidthMbps = Util.GetByPath(r, "BandWidthMbps") == null ? null : (long?)System.Convert.ToInt64("" + Util.GetByPath(r, "BandWidthMbps"));
			}
			else {
				this.M_bandWidthMbps = null;
				this.IsIncomplete = true;
			}
			this.N_bandWidthMbps = false;
			if (Util.ExistsPath(r, "Switch.ID")) {
				this.M_swytchId = Util.GetByPath(r, "Switch.ID") == null ? null : "" + Util.GetByPath(r, "Switch.ID");
			}
			else {
				this.M_swytchId = null;
				this.IsIncomplete = true;
			}
			this.N_swytchId = false;
		}
		
		/**
		 * @ignore
		 * @method ApiSerializeImpl
		 * @internal
		 * @param {bool} withClean=false
		 * @return {object}
		 */
		internal override object ApiSerializeImpl(bool withClean=false)
		{
			System.Collections.Generic.List<string> missing = new System.Collections.Generic.List<string> {  };
			object ret = new System.Collections.Generic.Dictionary<string, object> {  };
			if (withClean || this.N_id) {
				Util.SetByPath(ret, "ID", this.M_id);
			}
			if (withClean || this.N_name) {
				Util.SetByPath(ret, "Name", this.M_name);
			}
			else {
				if (this.IsNew) {
					(missing as System.Collections.IList).Add("name");
				}
			}
			if (withClean || this.N_description) {
				Util.SetByPath(ret, "Description", this.M_description);
			}
			if (withClean || this.N_networkMaskLen) {
				Util.SetByPath(ret, "NetworkMaskLen", this.M_networkMaskLen);
			}
			else {
				if (this.IsNew) {
					(missing as System.Collections.IList).Add("networkMaskLen");
				}
			}
			if (withClean || this.N_bandWidthMbps) {
				Util.SetByPath(ret, "BandWidthMbps", this.M_bandWidthMbps);
			}
			else {
				if (this.IsNew) {
					(missing as System.Collections.IList).Add("bandWidthMbps");
				}
			}
			if (withClean || this.N_swytchId) {
				Util.SetByPath(ret, "Switch.ID", this.M_swytchId);
			}
			if (missing.Count > 0) {
				throw new SaklientException("required_field", "Required fields must be set before the Router creation: " + string.Join(", ", (missing).ToArray()));
			}
			return ret;
		}
		
	}
	
}
