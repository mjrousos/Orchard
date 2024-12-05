using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Globalization;
using System.Xml;

namespace Orchard.Data.Bags {
    public class SConvert {
        public static ISItem ToSettings(object o) {
            if (o is SValue) {
                return (ISItem)o;
            }
            if (o is Bag) {
            if (o is SArray) {
            if (o is Array) {
                return new SArray((Array)o);
            if (IsAnonymousType(o.GetType())) {
                dynamic grappe = new Bag();
                foreach (var p in o.GetType().GetProperties()) {
                    grappe[p.Name] = p.GetValue(o, null);
                }
                return grappe;
            return new SValue(o);
        }
        public static object ToObject(object s) {
            if (s is SValue) {
                return ((SValue)s).Value;
            if (s is SArray) {
                var array = (SArray)s;
                var result = new object[array.Values.Length];
                for (var i = 0; i < array.Values.Length; i++) {
                    result[i] = ToObject(array.Values[i]);
                return result;
            return s;
        private static bool IsAnonymousType(Type type) {
            return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
                && type.IsGenericType && type.Name.Contains("AnonymousType")
                && (type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic;
        public static string XmlEncode(object value) {
            switch (Type.GetTypeCode(value.GetType())) {
                case TypeCode.Boolean:
                case TypeCode.Char:
                case TypeCode.String:
                    return value.ToString();
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return Convert.ToDecimal(value).ToString(CultureInfo.InvariantCulture);
                case TypeCode.DateTime:
                    return XmlConvert.ToString((DateTime)value, XmlDateTimeSerializationMode.Utc);
                default:
                    throw new NotSupportedException("Could not encode member");
        public static SValue XmlDecode(TypeCode typeCode, string value) {
            switch (typeCode) {
                    return new SValue(Boolean.Parse(value));
                    return new SValue(Byte.Parse(value, CultureInfo.InvariantCulture));
                    return new SValue(Decimal.Parse(value, CultureInfo.InvariantCulture));
                    return new SValue(Double.Parse(value, CultureInfo.InvariantCulture));
                    return new SValue(Int16.Parse(value, CultureInfo.InvariantCulture));
                    return new SValue(Int32.Parse(value, CultureInfo.InvariantCulture));
                    return new SValue(Int64.Parse(value, CultureInfo.InvariantCulture));
                    return new SValue(SByte.Parse(value, CultureInfo.InvariantCulture));
                    return new SValue(Single.Parse(value, CultureInfo.InvariantCulture));
                    return new SValue(UInt16.Parse(value, CultureInfo.InvariantCulture));
                    return new SValue(UInt32.Parse(value, CultureInfo.InvariantCulture));
                    return new SValue(UInt64.Parse(value, CultureInfo.InvariantCulture));
                    return new SValue(value[1]);
                    return new SValue(value);
                    return new SValue(XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Utc));
                    throw new NotSupportedException("Could not decode member");
    }
}
