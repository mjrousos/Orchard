using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Linq;
using Orchard.Projections.Models;

namespace Orchard.Projections.Services {
    public class FieldIndexService : IFieldIndexService {
        public void Set(FieldIndexPart part, string partName, string fieldName, string valueName, object value, Type valueType) =>
            Set(part, partName, fieldName, valueName, value, valueType, FieldIndexRecordVersionOptions.Value);
        public void Set(FieldIndexPart part, string partName, string fieldName, string valueName, object value, Type valueType,
            FieldIndexRecordVersionOptions fieldIndexRecordVersionOption) {
            var propertyName = string.Join(".", partName, fieldName, valueName ?? "");
            var typeCode = Type.GetTypeCode(valueType);
            if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                typeCode = Type.GetTypeCode(Nullable.GetUnderlyingType(valueType));
            }
            switch (typeCode) {
                case TypeCode.Char:
                case TypeCode.String:
                    var stringRecord = part.Record.StringFieldIndexRecords.FirstOrDefault(r => r.PropertyName == propertyName);
                    if (stringRecord == null) {
                        stringRecord = new StringFieldIndexRecord { PropertyName = propertyName };
                        part.Record.StringFieldIndexRecords.Add(stringRecord);
                    }
                    // Take the first 4000 chars as it is the limit for the field.
                    var stringRecordValue = value?.ToString().Substring(0, Math.Min(value.ToString().Length, 4000));
                    switch (fieldIndexRecordVersionOption) {
                        case FieldIndexRecordVersionOptions.Value:
                            stringRecord.Value = stringRecordValue;
                            break;
                        case FieldIndexRecordVersionOptions.LatestValue:
                            stringRecord.LatestValue = stringRecordValue;
                    break;
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    var integerRecord = part.Record.IntegerFieldIndexRecords.FirstOrDefault(r => r.PropertyName == propertyName);
                    if (integerRecord == null) {
                        integerRecord = new IntegerFieldIndexRecord { PropertyName = propertyName };
                        part.Record.IntegerFieldIndexRecords.Add(integerRecord);
                    var integerRecordValue = value == null ? default(long?) : Convert.ToInt64(value);
                            integerRecord.Value = integerRecordValue;
                            integerRecord.LatestValue = integerRecordValue;
                case TypeCode.DateTime:
                    var dateTimeRecord = part.Record.IntegerFieldIndexRecords.FirstOrDefault(r => r.PropertyName == propertyName);
                    if (dateTimeRecord == null) {
                        dateTimeRecord = new IntegerFieldIndexRecord { PropertyName = propertyName };
                        part.Record.IntegerFieldIndexRecords.Add(dateTimeRecord);
                    var dateTimeRecordValue = value == null ? default(long?) : ((DateTime)value).Ticks;
                            dateTimeRecord.Value = dateTimeRecordValue;
                            dateTimeRecord.LatestValue = dateTimeRecordValue;
                case TypeCode.Boolean:
                    var booleanRecord = part.Record.IntegerFieldIndexRecords.FirstOrDefault(r => r.PropertyName == propertyName);
                    if (booleanRecord == null) {
                        booleanRecord = new IntegerFieldIndexRecord { PropertyName = propertyName };
                        part.Record.IntegerFieldIndexRecords.Add(booleanRecord);
                    var booleanRecordValue = value == null ? default(long?) : Convert.ToInt64((bool)value);
                            booleanRecord.Value = booleanRecordValue;
                            booleanRecord.LatestValue = booleanRecordValue;
                case TypeCode.Decimal:
                    var decimalRecord = part.Record.DecimalFieldIndexRecords.FirstOrDefault(r => r.PropertyName == propertyName);
                    if (decimalRecord == null) {
                        decimalRecord = new DecimalFieldIndexRecord { PropertyName = propertyName };
                        part.Record.DecimalFieldIndexRecords.Add(decimalRecord);
                    var decimalRecordValue = value == null ? default(decimal?) : Convert.ToDecimal((decimal)value);
                            decimalRecord.Value = decimalRecordValue;
                            decimalRecord.LatestValue = decimalRecordValue;
                case TypeCode.Single:
                case TypeCode.Double:
                    var doubleRecord = part.Record.DoubleFieldIndexRecords.FirstOrDefault(r => r.PropertyName == propertyName);
                    if (doubleRecord == null) {
                        doubleRecord = new DoubleFieldIndexRecord { PropertyName = propertyName };
                        part.Record.DoubleFieldIndexRecords.Add(doubleRecord);
                    var doubleRecordValue = value == null ? default(double?) : Convert.ToDouble(value);
                            doubleRecord.Value = doubleRecordValue;
                            doubleRecord.LatestValue = doubleRecordValue;
        }
        public T Get<T>(FieldIndexPart part, string partName, string fieldName, string valueName) =>
            Get<T>(part, partName, fieldName, valueName, FieldIndexRecordVersionOptions.Value);
        public T Get<T>(FieldIndexPart part, string partName, string fieldName, string valueName, FieldIndexRecordVersionOptions fieldIndexRecordVersionOption) {
            var typeCode = Type.GetTypeCode(typeof(T));
                    var stringRecordValue = default(T);
                            stringRecordValue = (T)Convert.ChangeType(stringRecord.Value, typeof(T));
                            stringRecordValue = (T)Convert.ChangeType(stringRecord.LatestValue, typeof(T));
                    return stringRecord != null ? stringRecordValue : default;
                    var integerRecordValue = default(T);
                            integerRecordValue = (T)Convert.ChangeType(integerRecord.Value, typeof(T));
                            integerRecordValue = (T)Convert.ChangeType(integerRecord.LatestValue, typeof(T));
                    return integerRecord != null ? integerRecordValue : default;
                    var decimalRecordValue = default(T);
                            decimalRecordValue = (T)Convert.ChangeType(decimalRecord.Value, typeof(T));
                            decimalRecordValue = (T)Convert.ChangeType(decimalRecord.LatestValue, typeof(T));
                    return decimalRecord != null ? decimalRecordValue : default;
                    var doubleRecordValue = default(T);
                            doubleRecordValue = (T)Convert.ChangeType(doubleRecord.Value, typeof(T));
                            doubleRecordValue = (T)Convert.ChangeType(doubleRecord.LatestValue, typeof(T));
                    return doubleRecord != null ? doubleRecordValue : default;
                    var dateTimeRecordValue = default(T);
                            dateTimeRecordValue = (T)Convert.ChangeType(new DateTime(Convert.ToInt64(dateTimeRecord.Value)), typeof(T));
                            dateTimeRecordValue = (T)Convert.ChangeType(new DateTime(Convert.ToInt64(dateTimeRecord.LatestValue)), typeof(T));
                    return dateTimeRecord != null ? dateTimeRecordValue : default;
                    var booleanRecordValue = default(T);
                            booleanRecordValue = (T)Convert.ChangeType(booleanRecord.Value, typeof(T));
                            booleanRecordValue = (T)Convert.ChangeType(booleanRecord.LatestValue, typeof(T));
                    return booleanRecord != null ? booleanRecordValue : default;
                default:
                    return default;
    }
}
