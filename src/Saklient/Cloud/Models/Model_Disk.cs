using Util = Saklient.Util;
using Client = Saklient.Cloud.Client;
using Model = Saklient.Cloud.Models.Model;
using Disk = Saklient.Cloud.Resources.Disk;

namespace Saklient.Cloud.Models
{

	/**
	 * ディスクを検索・作成するための機能を備えたクラス。
	 * 
	 * @module saklient.cloud.models.Model_Disk
	 * @class Model_Disk
	 * @constructor
	 * @extends Model
	 */
	public class Model_Disk : Model
	{
		
		/**
		 * @private
		 * @method _apiPath
		 * @internal
		 * @ignore
		 * @return {string}
		 */
		internal override string _apiPath()
		{
			return "/disk";
		}
		
		/**
		 * @private
		 * @method _rootKey
		 * @internal
		 * @ignore
		 * @return {string}
		 */
		internal override string _rootKey()
		{
			return "Disk";
		}
		
		/**
		 * @private
		 * @method _rootKeyM
		 * @internal
		 * @ignore
		 * @return {string}
		 */
		internal override string _rootKeyM()
		{
			return "Disks";
		}
		
		/**
		 * @private
		 * @method _className
		 * @internal
		 * @ignore
		 * @return {string}
		 */
		internal override string _className()
		{
			return "Disk";
		}
		
		/**
		 * 次に取得するリストの開始オフセットを指定します。
		 * 
		 * @method Offset
		 * @chainable
		 * @public
		 * @param {long} offset オフセット
		 * @return {Model_Disk} this
		 */
		public Model_Disk Offset(long offset)
		{
			return ((Model_Disk)(this._offset(offset)));
		}
		
		/**
		 * 次に取得するリストの上限レコード数を指定します。
		 * 
		 * @method Limit
		 * @chainable
		 * @public
		 * @param {long} count 上限レコード数
		 * @return {Model_Disk} this
		 */
		public Model_Disk Limit(long count)
		{
			return ((Model_Disk)(this._limit(count)));
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
		 * @return {Model_Disk}
		 */
		public Model_Disk FilterBy(string key, object value, bool multiple=false)
		{
			return ((Model_Disk)(this._filterBy(key, value, multiple)));
		}
		
		/**
		 * 次のリクエストのために設定されているステートをすべて破棄します。
		 * 
		 * @method Reset
		 * @chainable
		 * @public
		 * @return {Model_Disk} this
		 */
		public Model_Disk Reset()
		{
			return ((Model_Disk)(this._reset()));
		}
		
		/**
		 * 新規リソース作成用のオブジェクトを用意します。
		 * 
		 * 返り値のオブジェクトにパラメータを設定し、save() を呼ぶことで実際のリソースが作成されます。
		 * 
		 * @method Create
		 * @public
		 * @return {Disk} リソースオブジェクト
		 */
		public Disk Create()
		{
			return ((Disk)(this._create()));
		}
		
		/**
		 * 指定したIDを持つ唯一のリソースを取得します。
		 * 
		 * @method GetById
		 * @public
		 * @param {string} id
		 * @return {Disk} リソースオブジェクト
		 */
		public Disk GetById(string id)
		{
			return ((Disk)(this._getById(id)));
		}
		
		/**
		 * リソースの検索リクエストを実行し、結果をリストで取得します。
		 * 
		 * @method Find
		 * @public
		 * @return {System.Collections.Generic.List<Disk>} リソースオブジェクトの配列
		 */
		public System.Collections.Generic.List<Disk> Find()
		{
			return Util.CastArray(this._find(), ((Disk)(null)));
		}
		
		/**
		 * 指定した文字列を名前に含むリソースに絞り込みます。
		 * 
		 * 大文字・小文字は区別されません。
		 * 半角スペースで区切られた複数の文字列は、それらをすべて含むことが条件とみなされます。
		 * 
		 * @todo Implement test case
		 * @method WithNameLike
		 * @chainable
		 * @public
		 * @param {string} name
		 * @return {Model_Disk}
		 */
		public Model_Disk WithNameLike(string name)
		{
			return ((Model_Disk)(this._withNameLike(name)));
		}
		
		/**
		 * 指定したタグを持つリソースに絞り込みます。
		 * 
		 * 複数のタグを指定する場合は withTags() を利用してください。
		 * 
		 * @todo Implement test case
		 * @method WithTag
		 * @chainable
		 * @public
		 * @param {string} tag
		 * @return {Model_Disk}
		 */
		public Model_Disk WithTag(string tag)
		{
			return ((Model_Disk)(this._withTag(tag)));
		}
		
		/**
		 * 指定したすべてのタグを持つリソースに絞り込みます。
		 * 
		 * @todo Implement test case
		 * @method WithTags
		 * @chainable
		 * @public
		 * @param {System.Collections.Generic.List<string>} tags
		 * @return {Model_Disk}
		 */
		public Model_Disk WithTags(System.Collections.Generic.List<string> tags)
		{
			return ((Model_Disk)(this._withTags(tags)));
		}
		
		/**
		 * 指定したDNFに合致するタグを持つリソースに絞り込みます。
		 * 
		 * @todo Implement test case
		 * @method WithTagDnf
		 * @chainable
		 * @public
		 * @param {System.Collections.Generic.List<System.Collections.Generic.List<string>>} dnf
		 * @return {Model_Disk}
		 */
		public Model_Disk WithTagDnf(System.Collections.Generic.List<System.Collections.Generic.List<string>> dnf)
		{
			return ((Model_Disk)(this._withTagDnf(dnf)));
		}
		
		/**
		 * 名前でソートします。
		 * 
		 * @todo Implement test case
		 * @method SortByName
		 * @chainable
		 * @public
		 * @param {bool} reverse=false
		 * @return {Model_Disk}
		 */
		public Model_Disk SortByName(bool reverse=false)
		{
			return ((Model_Disk)(this._sortByName(reverse)));
		}
		
		/**
		 * @ignore
		 * @constructor
		 * @param {Client} client
		 */
		public Model_Disk(Client client) : base(client)
		{
			/*!base!*/;
		}
		
		/**
		 * 指定したサイズのディスクに絞り込みます。
		 * 
		 * @method WithSizeGib
		 * @chainable
		 * @public
		 * @param {long} sizeGib
		 * @return {Model_Disk}
		 */
		public Model_Disk WithSizeGib(long sizeGib)
		{
			this._filterBy("SizeMB", new System.Collections.Generic.List<object> { sizeGib * 1024 });
			return this;
		}
		
		/**
		 * 指定したサーバへ接続されているディスクに絞り込みます。
		 * 
		 * @method WithServerId
		 * @chainable
		 * @public
		 * @param {string} id
		 * @return {Model_Disk}
		 */
		public Model_Disk WithServerId(string id)
		{
			this._filterBy("Server.ID", new System.Collections.Generic.List<object> { id });
			return this;
		}
		
		/**
		 * サイズでソートします。
		 * 
		 * @method SortBySize
		 * @chainable
		 * @public
		 * @param {bool} reverse=false
		 * @return {Model_Disk}
		 */
		public Model_Disk SortBySize(bool reverse=false)
		{
			this._sort("SizeMB", reverse);
			return this;
		}
		
	}
	
}
