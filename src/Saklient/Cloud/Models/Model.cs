using Util = Saklient.Util;
using Client = Saklient.Cloud.Client;
using Resource = Saklient.Cloud.Resources.Resource;
using QueryParams = Saklient.Cloud.Models.QueryParams;
using SaklientException = Saklient.Errors.SaklientException;

namespace Saklient.Cloud.Models
{

	/// <summary>
	/// 
	/// </summary>
	public class Model
	{
		
		internal Client _Client;
		
		internal Client Get_client() => this._Client;

        public Client Client => this.Get_client();

        internal QueryParams _Query;

        internal QueryParams Get_query() => this._Query;

        public QueryParams Query => this.Get_query();

        internal long? _Total;

        internal long? Get_total() => this._Total;

        public long? Total => this.Get_total();

        internal long? _Count;

        internal long? Get_count() => this._Count;

        public long? Count => this.Get_count();

        internal virtual string _ApiPath() => null;

        internal virtual string _RootKey() => null;

        internal virtual string _RootKeyM() => null;

        internal virtual string _ClassName() => null;

        /// <summary>
        /// <param name="client" />
        /// </summary>
        public Model(Client client)
		{
			this._Client = client;
			this._Reset();
		}
		
		internal Model _Offset(long offset)
		{
			this._Query.Begin = offset;
			return this;
		}
		
		internal Model _Limit(long count)
		{
			this._Query.Count = count;
			return this;
		}
		
		internal Model _Sort(string column, bool reverse=false)
		{
			string op = reverse ? "-" : "";
			(this._Query.Sort as System.Collections.IList).Add(op + column);
			return this;
		}
		
		internal Model _FilterBy(string key, object value, bool multiple=false)
		{
			var filter = this._Query.Filter as System.Collections.Generic.Dictionary<string, object>;
			if (multiple) {
				if (!filter.ContainsKey(key))
                    filter[key] = new System.Collections.Generic.List<object> {  };
				System.Collections.Generic.List<object> values = ((System.Collections.Generic.List<object>)(filter[key]));
				(values as System.Collections.IList).Add(value);
			}
			else {
				if (filter.ContainsKey(key))
					throw new SaklientException("filter_duplicated", "The same filter key can be specified only once (by calling the same method 'withFooBar')");
                filter[key] = value;
			}
			return this;
		}
		
		internal Model _Reset()
		{
			this._Query = new QueryParams();
			this._Total = 0;
			this._Count = 0;
			return this;
		}

        internal virtual Resource _CreateResourceImpl(object obj, bool wrapped = false) => null;

        internal Resource _Create() => this._CreateResourceImpl(null);

        internal Resource _GetById(string id)
		{
			object query = this._Query.Build();
			this._Reset();
			object result = this._Client.Request("GET", this._ApiPath() + "/" + Util.UrlEncode(id), query);
			this._Total = 1;
			this._Count = 1;
			return this._CreateResourceImpl(result, true);
		}
		
		internal System.Collections.Generic.List<Resource> _Find()
		{
			object query = this._Query.Build();
			this._Reset();
			object result = this._Client.Request("GET", this._ApiPath(), query);
			this._Total = System.Convert.ToInt64((result as System.Collections.Generic.Dictionary<string, object>)["Total"]);
			this._Count = System.Convert.ToInt64((result as System.Collections.Generic.Dictionary<string, object>)["Count"]);
			System.Collections.Generic.List<Resource> data = new System.Collections.Generic.List<Resource> {  };
			System.Collections.Generic.List<object> records = ((System.Collections.Generic.List<object>)((result as System.Collections.Generic.Dictionary<string, object>)[this._RootKeyM()]));
			for (int __it1=0; __it1 < (records as System.Collections.IList).Count; __it1++) {
				var record = records[__it1];
				(data as System.Collections.IList).Add(this._CreateResourceImpl(record));
			}
			return data;
		}
		
		internal Resource _FindOne()
		{
			object query = this._Query.Build();
			this._Reset();
			object result = this._Client.Request("GET", this._ApiPath(), query);
			this._Total = System.Convert.ToInt64((result as System.Collections.Generic.Dictionary<string, object>)["Total"]);
			this._Count = System.Convert.ToInt64((result as System.Collections.Generic.Dictionary<string, object>)["Count"]);
            if (this._Total == 0) return null;
            System.Collections.Generic.List<object> records = ((System.Collections.Generic.List<object>)((result as System.Collections.Generic.Dictionary<string, object>)[this._RootKeyM()]));
			return this._CreateResourceImpl(records[System.Convert.ToInt32(0)]);
		}

        internal Model _WithNameLike(string name) => this._FilterBy("Name", name);

        internal Model _WithTag(string tag) => this._FilterBy("Tags.Name", new System.Collections.Generic.List<object> { tag });

        internal Model _WithTags(System.Collections.Generic.List<string> tags) => this._FilterBy("Tags.Name", new System.Collections.Generic.List<object> { tags });

        internal Model _WithTagDnf(System.Collections.Generic.List<System.Collections.Generic.List<string>> dnf) => this._FilterBy("Tags.Name", dnf);

        internal Model _SortByName(bool reverse = false) => this._Sort("Name", reverse);

    }
	
}
