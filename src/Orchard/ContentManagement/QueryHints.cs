using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.ContentManagement.Records;

namespace Orchard.ContentManagement
{
    public class QueryHints
    {
        private readonly List<string> _records = new List<string>();
        private static readonly QueryHints _empty = new QueryHints();
        public IEnumerable<string> Records
        {
            get { return _records; }
        }
        public static QueryHints Empty
            get { return _empty; }
        public QueryHints ExpandRecords(IEnumerable<string> records)
            _records.AddRange(records);
            return this;
        public QueryHints ExpandRecords(params string[] records)
        public QueryHints ExpandRecords<TRecord1>() where TRecord1 : ContentPartRecord
            _records.AddRange(new[] { typeof(TRecord1).Name });
        public QueryHints ExpandRecords<TRecord1, TRecord2>()
            where TRecord1 : ContentPartRecord
            where TRecord2 : ContentPartRecord
            _records.AddRange(new[] { typeof(TRecord1).Name, typeof(TRecord2).Name });
        public QueryHints ExpandRecords<TRecord1, TRecord2, TRecord3>()
            where TRecord3 : ContentPartRecord
            _records.AddRange(new[] { typeof(TRecord1).Name, typeof(TRecord2).Name, typeof(TRecord3).Name });
        public QueryHints ExpandRecords<TRecord1, TRecord2, TRecord3, TRecord4>()
            where TRecord4 : ContentPartRecord
            _records.AddRange(new[] { typeof(TRecord1).Name, typeof(TRecord2).Name, typeof(TRecord3).Name, typeof(TRecord4).Name });
        public QueryHints ExpandRecords<TRecord1, TRecord2, TRecord3, TRecord4, TRecord5>()
            where TRecord5 : ContentPartRecord
            _records.AddRange(new[] { typeof(TRecord1).Name, typeof(TRecord2).Name, typeof(TRecord3).Name, typeof(TRecord4).Name, typeof(TRecord5).Name });
        public QueryHints ExpandRecords<TRecord1, TRecord2, TRecord3, TRecord4, TRecord5, TRecord6>()
            where TRecord6 : ContentPartRecord
            _records.AddRange(new[] { typeof(TRecord1).Name, typeof(TRecord2).Name, typeof(TRecord3).Name, typeof(TRecord4).Name, typeof(TRecord5).Name, typeof(TRecord6).Name });
        public QueryHints ExpandRecords<TRecord1, TRecord2, TRecord3, TRecord4, TRecord5, TRecord6, TRecord7>()
            where TRecord7 : ContentPartRecord
            _records.AddRange(new[] { typeof(TRecord1).Name, typeof(TRecord2).Name, typeof(TRecord3).Name, typeof(TRecord4).Name, typeof(TRecord5).Name, typeof(TRecord6).Name, typeof(TRecord7).Name });
        public QueryHints ExpandRecords<TRecord1, TRecord2, TRecord3, TRecord4, TRecord5, TRecord6, TRecord7, TRecord8>()
            where TRecord8 : ContentPartRecord
            _records.AddRange(new[] { typeof(TRecord1).Name, typeof(TRecord2).Name, typeof(TRecord3).Name, typeof(TRecord4).Name, typeof(TRecord5).Name, typeof(TRecord6).Name, typeof(TRecord7).Name, typeof(TRecord8).Name });
        public QueryHints ExpandParts<TPart1>() where TPart1 : ContentPart
            return ExpandPartsImpl(typeof(TPart1));
        public QueryHints ExpandParts<TPart1, TPart2>()
            where TPart1 : ContentPart
            where TPart2 : ContentPart
            return ExpandPartsImpl(typeof(TPart1), typeof(TPart2));
        public QueryHints ExpandParts<TPart1, TPart2, TPart3>()
            where TPart3 : ContentPart
            return ExpandPartsImpl(typeof(TPart1), typeof(TPart2), typeof(TPart3));
        public QueryHints ExpandParts<TPart1, TPart2, TPart3, TPart4>()
            where TPart4 : ContentPart
            return ExpandPartsImpl(typeof(TPart1), typeof(TPart2), typeof(TPart3), typeof(TPart4));
        public QueryHints ExpandParts<TPart1, TPart2, TPart3, TPart4, TPart5>()
            where TPart5 : ContentPart
            return ExpandPartsImpl(typeof(TPart1), typeof(TPart2), typeof(TPart3), typeof(TPart4), typeof(TPart5));
        public QueryHints ExpandParts<TPart1, TPart2, TPart3, TPart4, TPart5, TPart6>()
            where TPart6 : ContentPart
            return ExpandPartsImpl(typeof(TPart1), typeof(TPart2), typeof(TPart3), typeof(TPart4), typeof(TPart5), typeof(TPart6));
        public QueryHints ExpandParts<TPart1, TPart2, TPart3, TPart4, TPart5, TPart6, TPart7>()
            where TPart7 : ContentPart
            return ExpandPartsImpl(typeof(TPart1), typeof(TPart2), typeof(TPart3), typeof(TPart4), typeof(TPart5), typeof(TPart6), typeof(TPart7));
        public QueryHints ExpandParts<TPart1, TPart2, TPart3, TPart4, TPart5, TPart6, TPart7, TPart8>()
            where TPart8 : ContentPart
            return ExpandPartsImpl(typeof(TPart1), typeof(TPart2), typeof(TPart3), typeof(TPart4), typeof(TPart5), typeof(TPart6), typeof(TPart7), typeof(TPart8));
        private QueryHints ExpandPartsImpl(params Type[] parts)
            foreach (var part in parts)
            {
                for (var scan = part; scan != typeof(Object); scan = scan.BaseType)
                {
                    if (scan.IsGenericType && scan.GetGenericTypeDefinition() == typeof(ContentPart<>))
                    {
                        _records.Add(scan.GetGenericArguments().Single().Name);
                        break;
                    }
                }
            }
    }
}
