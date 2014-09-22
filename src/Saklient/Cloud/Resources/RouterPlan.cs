using Util = Saklient.Util;
using Client = Saklient.Cloud.Client;
using Resource = Saklient.Cloud.Resources.Resource;

namespace Saklient.Cloud.Resources
{

	/**
	 * ルータ帯域プラン情報の1レコードに対応するクラス。
	 * 
	 * @module saklient.cloud.resources.RouterPlan
	 * @class RouterPlan
	 * @constructor
	 * @extends Resource
	 */
	public class RouterPlan : Resource
	{
		
		/**
		 * ID
		 * 
		 * @member saklient.cloud.resources.RouterPlan#M_id
		 * @type string
		 * @internal
		 */
		internal string M_id;
		
		/**
		 * 名前
		 * 
		 * @member saklient.cloud.resources.RouterPlan#M_name
		 * @type string
		 * @internal
		 */
		internal string M_name;
		
		/**
		 * 帯域幅
		 * 
		 * @member saklient.cloud.resources.RouterPlan#M_bandWidthMbps
		 * @type long?
		 * @internal
		 */
		internal long? M_bandWidthMbps;
		
		/**
		 * サービスクラス
		 * 
		 * @member saklient.cloud.resources.RouterPlan#M_serviceClass
		 * @type string
		 * @internal
		 */
		internal string M_serviceClass;
		
		/**
		 * @private
		 * @method _ApiPath
		 * @internal
		 * @ignore
		 * @return {string}
		 */
		internal override string _ApiPath()
		{
			return "/product/internet";
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
			return "InternetPlan";
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
			return "InternetPlans";
		}
		
		/**
		 * @private
		 * @method _ClassName
		 * @ignore
		 * @return {string}
		 */
		public override string _ClassName()
		{
			return "RouterPlan";
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
		 * @ignore
		 * @constructor
		 * @param {Client} client
		 * @param {object} obj
		 * @param {bool} wrapped=false
		 */
		public RouterPlan(Client client, object obj, bool wrapped=false) : base(client)
		{
			/*!base!*/;
			this.ApiDeserialize(obj, wrapped);
		}
		
		/**
		 * @member saklient.cloud.resources.RouterPlan#N_id
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
		 * @member saklient.cloud.resources.RouterPlan#N_name
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
		 * 名前
		 * 
		 * @property Name
		 * @type string
		 * @readOnly
		 * @public
		 */
		public string Name
		{
			get { return this.Get_name(); }
		}
		
		/**
		 * @member saklient.cloud.resources.RouterPlan#N_bandWidthMbps
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
		 * 帯域幅
		 * 
		 * @property BandWidthMbps
		 * @type long?
		 * @readOnly
		 * @public
		 */
		public long? BandWidthMbps
		{
			get { return this.Get_bandWidthMbps(); }
		}
		
		/**
		 * @member saklient.cloud.resources.RouterPlan#N_serviceClass
		 * @default false
		 * @type bool
		 * @private
		 */
		private bool N_serviceClass = false;
		
		/**
		 * (This method is generated in Translator_default#buildImpl)
		 * 
		 * @method Get_serviceClass
		 * @private
		 * @ignore
		 * @return {string}
		 */
		private string Get_serviceClass()
		{
			return this.M_serviceClass;
		}
		
		/**
		 * サービスクラス
		 * 
		 * @property ServiceClass
		 * @type string
		 * @readOnly
		 * @public
		 */
		public string ServiceClass
		{
			get { return this.Get_serviceClass(); }
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
			if (Util.ExistsPath(r, "BandWidthMbps")) {
				this.M_bandWidthMbps = Util.GetByPath(r, "BandWidthMbps") == null ? null : (long?)System.Convert.ToInt64("" + Util.GetByPath(r, "BandWidthMbps"));
			}
			else {
				this.M_bandWidthMbps = null;
				this.IsIncomplete = true;
			}
			this.N_bandWidthMbps = false;
			if (Util.ExistsPath(r, "ServiceClass")) {
				this.M_serviceClass = Util.GetByPath(r, "ServiceClass") == null ? null : "" + Util.GetByPath(r, "ServiceClass");
			}
			else {
				this.M_serviceClass = null;
				this.IsIncomplete = true;
			}
			this.N_serviceClass = false;
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
			object ret = new System.Collections.Generic.Dictionary<string, object> {  };
			if (withClean || this.N_id) {
				Util.SetByPath(ret, "ID", this.M_id);
			}
			if (withClean || this.N_name) {
				Util.SetByPath(ret, "Name", this.M_name);
			}
			if (withClean || this.N_bandWidthMbps) {
				Util.SetByPath(ret, "BandWidthMbps", this.M_bandWidthMbps);
			}
			if (withClean || this.N_serviceClass) {
				Util.SetByPath(ret, "ServiceClass", this.M_serviceClass);
			}
			return ret;
		}
		
	}
	
}
