using Util = Saklient.Util;
using Client = Saklient.Cloud.Client;
using Model = Saklient.Cloud.Models.Model;
using Resource = Saklient.Cloud.Resources.Resource;
using Swytch = Saklient.Cloud.Resources.Swytch;

namespace Saklient.Cloud.Models
{

	/// <summary>スイッチを検索・作成するための機能を備えたクラス。
	/// </summary>
	public class Model_Swytch : Model
	{

        internal override string _ApiPath() => "/switch";

        internal override string _RootKey() => "Switch";

        internal override string _RootKeyM() => "Switches";

        internal override string _ClassName() => "Swytch";

        internal override Resource _CreateResourceImpl(object obj, bool wrapped = false) => new Swytch(this._Client, obj, wrapped);

        /// <summary>次に取得するリストの開始オフセットを指定します。
        /// 
        /// <param name="offset">オフセット</param>
        /// <returns>this</returns>
        /// </summary>
        public Model_Swytch Offset(long offset) => ((Model_Swytch)(this._Offset(offset)));

        /// <summary>次に取得するリストの上限レコード数を指定します。
        /// 
        /// <param name="count">上限レコード数</param>
        /// <returns>this</returns>
        /// </summary>
        public Model_Swytch Limit(long count) => ((Model_Swytch)(this._Limit(count)));

        /// <summary>Web APIのフィルタリング設定を直接指定します。
        /// 
        /// <param name="key">キー</param>
        /// <param name="value">値</param>
        /// <param name="multiple">valueに配列を与え、OR条件で完全一致検索する場合にtrueを指定します。通常、valueはスカラ値であいまい検索されます。</param>
        /// </summary>
        public Model_Swytch FilterBy(string key, object value, bool multiple = false) => ((Model_Swytch)(this._FilterBy(key, value, multiple)));

        /// <summary>次のリクエストのために設定されているステートをすべて破棄します。
        /// 
        /// <returns>this</returns>
        /// </summary>
        public Model_Swytch Reset() => ((Model_Swytch)(this._Reset()));

        /// <summary>新規リソース作成用のオブジェクトを用意します。
        /// 
        /// 返り値のオブジェクトにパラメータを設定し、save() を呼ぶことで実際のリソースが作成されます。
        /// 
        /// <returns>リソースオブジェクト</returns>
        /// </summary>
        public Swytch Create() => ((Swytch)(this._Create()));

        /// <summary>指定したIDを持つ唯一のリソースを取得します。
        /// 
        /// <param name="id" />
        /// <returns>リソースオブジェクト</returns>
        /// </summary>
        public Swytch GetById(string id) => ((Swytch)(this._GetById(id)));

        /// <summary>リソースの検索リクエストを実行し、結果をリストで取得します。
        /// 
        /// <returns>リソースオブジェクトの配列</returns>
        /// </summary>
        public System.Collections.Generic.List<Swytch> Find() => Util.CastArray(this._Find(), ((Swytch)(null)));

        /// <summary>指定した文字列を名前に含むリソースに絞り込みます。
        /// 
        /// 大文字・小文字は区別されません。
        /// 半角スペースで区切られた複数の文字列は、それらをすべて含むことが条件とみなされます。
        /// 
        /// 
        /// <param name="name" />
        /// </summary>
        public Model_Swytch WithNameLike(string name) => ((Model_Swytch)(this._WithNameLike(name)));

        /// <summary>指定したタグを持つリソースに絞り込みます。
        /// 
        /// 複数のタグを指定する場合は withTags() を利用してください。
        /// 
        /// 
        /// <param name="tag" />
        /// </summary>
        public Model_Swytch WithTag(string tag) => ((Model_Swytch)(this._WithTag(tag)));

        /// <summary>指定したすべてのタグを持つリソースに絞り込みます。
        /// 
        /// 
        /// <param name="tags" />
        /// </summary>
        public Model_Swytch WithTags(System.Collections.Generic.List<string> tags) => ((Model_Swytch)(this._WithTags(tags)));

        /// <summary>指定したDNFに合致するタグを持つリソースに絞り込みます。
        /// 
        /// 
        /// <param name="dnf" />
        /// </summary>
        public Model_Swytch WithTagDnf(System.Collections.Generic.List<System.Collections.Generic.List<string>> dnf) => ((Model_Swytch)(this._WithTagDnf(dnf)));

        /// <summary>名前でソートします。
        /// 
        /// 
        /// <param name="reverse" />
        /// </summary>
        public Model_Swytch SortByName(bool reverse = false) => ((Model_Swytch)(this._SortByName(reverse)));

        public Model_Swytch(Client client) : base(client)
		{
			/*!base!*/
		}
		
	}
	
}
