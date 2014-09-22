using Util = Saklient.Util;
using Client = Saklient.Cloud.Client;
using Model = Saklient.Cloud.Models.Model;
using RouterPlan = Saklient.Cloud.Resources.RouterPlan;

namespace Saklient.Cloud.Models
{

	/**
	 * ルータ帯域プランを検索するための機能を備えたクラス。
	 * 
	 * @module saklient.cloud.models.Model_RouterPlan
	 * @class Model_RouterPlan
	 * @constructor
	 * @extends Model
	 */
	public class Model_RouterPlan : Model
	{
		
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
		 * @internal
		 * @ignore
		 * @return {string}
		 */
		internal override string _ClassName()
		{
			return "RouterPlan";
		}
		
		/**
		 * 次に取得するリストの開始オフセットを指定します。
		 * 
		 * @method Offset
		 * @chainable
		 * @public
		 * @param {long} offset オフセット
		 * @return {Model_RouterPlan} this
		 */
		public Model_RouterPlan Offset(long offset)
		{
			return ((Model_RouterPlan)(this._Offset(offset)));
		}
		
		/**
		 * 次に取得するリストの上限レコード数を指定します。
		 * 
		 * @method Limit
		 * @chainable
		 * @public
		 * @param {long} count 上限レコード数
		 * @return {Model_RouterPlan} this
		 */
		public Model_RouterPlan Limit(long count)
		{
			return ((Model_RouterPlan)(this._Limit(count)));
		}
		
		/**
		 * Web APIのフィルタリング設定を直接指定します。
		 * 
		 * @method FilterBy
		 * @chainable
		 * @public
		 * @param {string} key キー
		 * @param {object} value 値
		 * @param {bool} multiple=false valueに配列を与え、OR条件で完全一致検索する場合にtrueを指定します。通常、valueはスカラ値であいまい検索されます。
		 * @return {Model_RouterPlan}
		 */
		public Model_RouterPlan FilterBy(string key, object value, bool multiple=false)
		{
			return ((Model_RouterPlan)(this._FilterBy(key, value, multiple)));
		}
		
		/**
		 * 次のリクエストのために設定されているステートをすべて破棄します。
		 * 
		 * @method Reset
		 * @chainable
		 * @public
		 * @return {Model_RouterPlan} this
		 */
		public Model_RouterPlan Reset()
		{
			return ((Model_RouterPlan)(this._Reset()));
		}
		
		/**
		 * 指定したIDを持つ唯一のリソースを取得します。
		 * 
		 * @method GetById
		 * @public
		 * @param {string} id
		 * @return {RouterPlan} リソースオブジェクト
		 */
		public RouterPlan GetById(string id)
		{
			return ((RouterPlan)(this._GetById(id)));
		}
		
		/**
		 * リソースの検索リクエストを実行し、結果をリストで取得します。
		 * 
		 * @method Find
		 * @public
		 * @return {System.Collections.Generic.List<RouterPlan>} リソースオブジェクトの配列
		 */
		public System.Collections.Generic.List<RouterPlan> Find()
		{
			return Util.CastArray(this._Find(), ((RouterPlan)(null)));
		}
		
		/**
		 * @ignore
		 * @constructor
		 * @param {Client} client
		 */
		public Model_RouterPlan(Client client) : base(client)
		{
			/*!base!*/;
		}
		
	}
	
}
