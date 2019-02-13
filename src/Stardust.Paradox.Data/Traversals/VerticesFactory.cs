﻿using System.Globalization;
using Stardust.Paradox.Data.Annotations;
using Stardust.Paradox.Data.Internals;

namespace Stardust.Paradox.Data.Traversals
{
    public static class VerticesFactory
    {
	    

        public static GremlinQuery V(this IGremlinLanguageConnector connector)
        {
            return new GremlinQuery(connector, "g.V()");
        }

        public static GremlinQuery WithSackV(this IGremlinLanguageConnector connector, float sack)
        {
            return new GremlinQuery(connector, $"g.withSack({sack.ToString(CultureInfo.InvariantCulture)}f).V()");
        }

		/// <summary>
		/// Does escaping of id value
		/// </summary>
		/// <param name="connector"></param>
		/// <param name="id"></param>
		/// <returns></returns>
        public static UpdatableGremlinQuery V(this IGremlinLanguageConnector connector, string id)
        {
	        var baseQuery=new UpdatableGremlinQuery(connector,"g");
	         baseQuery._query = $"g.V({baseQuery.ComposeParameter(id)})";
	        return baseQuery;
	        //return new UpdatableGremlinQuery(connector, $"g.V('{ id.EscapeGremlinString()}')");
        }

	    public static UpdatableGremlinQuery E(this IGremlinLanguageConnector connector, string id)
	    {
		    var baseQuery = new UpdatableGremlinQuery(connector, "g");
		    baseQuery._query = $"g.E({baseQuery.ComposeParameter(id)})";
		    return baseQuery;
			//return new UpdatableGremlinQuery(connector, $"g.E('{ id.EscapeGremlinString()}')");
	    }

	    public static UpdatableGremlinQuery E(this IGremlinLanguageConnector connector)
	    {
		    var baseQuery = new UpdatableGremlinQuery(connector, "g");
		    baseQuery._query = $"g.E()";
		    return baseQuery;
		    //return new UpdatableGremlinQuery(connector, $"g.V('{ id.EscapeGremlinString()}')");
	    }

		public static UpdatableGremlinQuery V(this IGremlinLanguageConnector connector, int index)
        {
	        var baseQuery = new UpdatableGremlinQuery(connector, "g");
	        baseQuery._query = $"g.V({baseQuery.ComposeParameter(index)})";
	        return baseQuery;
			//return new UpdatableGremlinQuery(connector, $"g.V({index})");
        }
    }
}