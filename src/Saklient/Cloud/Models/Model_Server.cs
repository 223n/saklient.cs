using Util = Saklient.Util;
using Client = Saklient.Cloud.Client;
using Model = Saklient.Cloud.Models.Model;
using Resource = Saklient.Cloud.Resources.Resource;
using Server = Saklient.Cloud.Resources.Server;
using ServerPlan = Saklient.Cloud.Resources.ServerPlan;
using IsoImage = Saklient.Cloud.Resources.IsoImage;
using EServerInstanceStatus = Saklient.Cloud.Enums.EServerInstanceStatus;

namespace Saklient.Cloud.Models
{

	/// <summary>サーバを検索・作成するための機能を備えたクラス。
	/// </summary>
	public class Model_Server : Model
	{

        internal override string _ApiPath() => "/server";

        internal override string _RootKey() => "Server";

        internal override string _RootKeyM() => "Servers";

        internal override string _ClassName() => "Server";

        internal override Resource _CreateResourceImpl(object obj, bool wrapped = false) => new Server(this._Client, obj, wrapped);

        /// <summary>次に取得するリストの開始オフセットを指定します。
        /// 
        /// <param name="offset">オフセット</param>
        /// <returns>this</returns>
        /// </summary>
        public Model_Server Offset(long offset) => ((Model_Server)(this._Offset(offset)));

        /// <summary>次に取得するリストの上限レコード数を指定します。
        /// 
        /// <param name="count">上限レコード数</param>
        /// <returns>this</returns>
        /// </summary>
        public Model_Server Limit(long count) => ((Model_Server)(this._Limit(count)));

        /// <summary>Web APIのフィルタリング設定を直接指定します。
        /// 
        /// <param name="key">キー</param>
        /// <param name="value">値</param>
        /// <param name="multiple">valueに配列を与え、OR条件で完全一致検索する場合にtrueを指定します。通常、valueはスカラ値であいまい検索されます。</param>
        /// </summary>
        public Model_Server FilterBy(string key, object value, bool multiple = false) => ((Model_Server)(this._FilterBy(key, value, multiple)));

        /// <summary>次のリクエストのために設定されているステートをすべて破棄します。
        /// 
        /// <returns>this</returns>
        /// </summary>
        public Model_Server Reset() => ((Model_Server)(this._Reset()));

        /// <summary>新規リソース作成用のオブジェクトを用意します。
        /// 
        /// 返り値のオブジェクトにパラメータを設定し、save() を呼ぶことで実際のリソースが作成されます。
        /// 
        /// <returns>リソースオブジェクト</returns>
        /// </summary>
        public Server Create() => ((Server)(this._Create()));

        /// <summary>指定したIDを持つ唯一のリソースを取得します。
        /// 
        /// <param name="id" />
        /// <returns>リソースオブジェクト</returns>
        /// </summary>
        public Server GetById(string id) => ((Server)(this._GetById(id)));

        /// <summary>リソースの検索リクエストを実行し、結果をリストで取得します。
        /// 
        /// <returns>リソースオブジェクトの配列</returns>
        /// </summary>
        public System.Collections.Generic.List<Server> Find() => Util.CastArray(this._Find(), ((Server)(null)));

        /// <summary>指定した文字列を名前に含むリソースに絞り込みます。
        /// 
        /// 大文字・小文字は区別されません。
        /// 半角スペースで区切られた複数の文字列は、それらをすべて含むことが条件とみなされます。
        /// 
        /// 
        /// <param name="name" />
        /// </summary>
        public Model_Server WithNameLike(string name) => ((Model_Server)(this._WithNameLike(name)));

        /// <summary>指定したタグを持つリソースに絞り込みます。
        /// 
        /// 複数のタグを指定する場合は withTags() を利用してください。
        /// 
        /// 
        /// <param name="tag" />
        /// </summary>
        public Model_Server WithTag(string tag) => ((Model_Server)(this._WithTag(tag)));

        /// <summary>指定したすべてのタグを持つリソースに絞り込みます。
        /// 
        /// 
        /// <param name="tags" />
        /// </summary>
        public Model_Server WithTags(System.Collections.Generic.List<string> tags) => ((Model_Server)(this._WithTags(tags)));

        /// <summary>指定したDNFに合致するタグを持つリソースに絞り込みます。
        /// 
        /// 
        /// <param name="dnf" />
        /// </summary>
        public Model_Server WithTagDnf(System.Collections.Generic.List<System.Collections.Generic.List<string>> dnf) => ((Model_Server)(this._WithTagDnf(dnf)));

        /// <summary>名前でソートします。
        /// 
        /// 
        /// <param name="reverse" />
        /// </summary>
        public Model_Server SortByName(bool reverse = false) => ((Model_Server)(this._SortByName(reverse)));

        public Model_Server(Client client) : base(client)
		{
			/*!base!*/
		}
		
		/// <summary>指定したプランのサーバに絞り込みます。
		/// 
		/// <param name="plan" />
		/// </summary>
		public Model_Server WithPlan(ServerPlan plan)
		{
			this._FilterBy("ServerPlan.ID", new System.Collections.Generic.List<object> { plan._Id() });
			return this;
		}
		
		/// <summary>インスタンスが指定した状態にあるサーバに絞り込みます。
		/// 
		/// <param name="status" />
		/// </summary>
		public Model_Server WithStatus(string status)
		{
			this._FilterBy("Instance.Status", new System.Collections.Generic.List<object> { status });
			return this;
		}

        /// <summary>インスタンスが起動中のサーバに絞り込みます。
        /// </summary>
        public Model_Server WithStatusUp() => this.WithStatus(EServerInstanceStatus.UP);

        /// <summary>インスタンスが停止中のサーバに絞り込みます。
        /// </summary>
        public Model_Server WithStatusDown() => this.WithStatus(EServerInstanceStatus.DOWN);

        /// <summary>指定したISOイメージが挿入されているサーバに絞り込みます。
        /// 
        /// <param name="iso" />
        /// </summary>
        public Model_Server WithIsoImage(IsoImage iso)
		{
			this._FilterBy("Instance.CDROM.ID", new System.Collections.Generic.List<object> { iso._Id() });
			return this;
		}
		
		/// <summary>仮想コア数でソートします。
		/// 
		/// <param name="reverse" />
		/// </summary>
		public Model_Server SortByCpu(bool reverse=false)
		{
			this._Sort("ServerPlan.CPU", reverse);
			return this;
		}
		
		/// <summary>メモリ容量でソートします。
		/// 
		/// <param name="reverse" />
		/// </summary>
		public Model_Server SortByMemory(bool reverse=false)
		{
			this._Sort("ServerPlan.MemoryMB", reverse);
			return this;
		}
		
	}
	
}
