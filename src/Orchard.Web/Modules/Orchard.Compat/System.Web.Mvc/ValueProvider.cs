using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace System.Web.Mvc
{
    public interface IValueProvider
    {
        bool ContainsPrefix(string prefix);
        ValueProviderResult GetValue(string key);
    }

    public class ValueProviderResult
    {
        public ValueProviderResult(object rawValue, string attemptedValue, CultureInfo culture)
        {
            RawValue = rawValue;
            AttemptedValue = attemptedValue;
            Culture = culture;
        }

        public object RawValue { get; private set; }
        public string AttemptedValue { get; private set; }
        public CultureInfo Culture { get; private set; }

        public static implicit operator string(ValueProviderResult result)
        {
            return result?.AttemptedValue;
        }

        public static implicit operator string[](ValueProviderResult result)
        {
            if (result == null || result.RawValue == null)
            {
                return null;
            }

            if (result.RawValue is string[] rawValueAsStringArray)
            {
                return rawValueAsStringArray;
            }

            return new[] { result.AttemptedValue };
        }

        public static ValueProviderResult None => null;
    }

    public class DictionaryValueProvider<TValue> : IValueProvider
    {
        private readonly IDictionary<string, TValue> _dictionary;
        private readonly CultureInfo _culture;

        public DictionaryValueProvider(IDictionary<string, TValue> dictionary, CultureInfo culture)
        {
            _dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
            _culture = culture;
        }

        public bool ContainsPrefix(string prefix)
        {
            return _dictionary.Keys.Any(key => key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
        }

        public ValueProviderResult GetValue(string key)
        {
            if (_dictionary.TryGetValue(key, out TValue value))
            {
                return new ValueProviderResult(value, value?.ToString(), _culture);
            }
            return null;
        }
    }
}
