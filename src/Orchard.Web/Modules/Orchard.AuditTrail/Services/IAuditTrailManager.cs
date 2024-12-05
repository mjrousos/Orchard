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
using Orchard.AuditTrail.Models;
using Orchard.AuditTrail.Services.Models;
using Orchard.Collections;

namespace Orchard.AuditTrail.Services {
    /// <summary>
    /// Manage the audit trail.
    /// </summary>
    public interface IAuditTrailManager : IDependency {
        /// <summary>
        /// Gets a page of event records from the audit trail.
        /// </summary>
        /// <param name="page">The page number to get records from.</param>
        /// <param name="pageSize">The number of records to get.</param>
        /// <param name="orderBy">The value to order by.</param>
        /// <param name="filters">Optional. An object to filter the records on.</param>
        /// <returns>A page of event records.</returns>
        IPageOfItems<AuditTrailEventRecord> GetRecords(int page, int pageSize, Filters filters = null, AuditTrailOrderBy orderBy = AuditTrailOrderBy.DateDescending);
        /// Gets a single event record from the audit trail by ID.
        /// <param name="id">The event record ID.</param>
        /// <returns>A single event record.</returns>
        AuditTrailEventRecord GetRecord(int id);
        /// Builds a shape tree of filter displays.
        /// <param name="filters">Input for each filter builder.</param>
        /// <returns>A tree of shapes.</returns>
        dynamic BuildFilterDisplay(Filters filters);
        
        /// Records an audit trail event.
        /// <typeparam name="T">The audit trail event provider type to determine the scope of the event name.</typeparam>
        /// <param name="eventName">The shorthand name of the event</param>
        /// <param name="user">The user to associate with the event. This is typically the currently loggedin user.</param>
        /// <param name="properties">A property bag of custom event data that could be useful for <see cref="IAuditTrailEventHandler"/> implementations. These values aren't stored. Use the eventData parameter to persist additional data with the event.</param>
        /// <param name="eventData">A property bag of custom event data that will be stored with the event record.</param>
        /// <param name="eventFilterKey">The name of a custom key to use when filtering events.</param>
        /// <param name="eventFilterData">The value of a custom filter key to filter on.</param>
        /// <returns>The created audit trail event record if the specified event was not disabled.</returns>
        AuditTrailEventRecordResult CreateRecord<T>(string eventName, IUser user, IDictionary<string, object> properties = null, IDictionary<string, object> eventData = null, string eventFilterKey = null, string eventFilterData = null) where T : IAuditTrailEventProvider;
        /// Describes all audit trail events provided by the system.
        /// <returns>A list of audit trail category descriptors.</returns>
        IEnumerable<AuditTrailCategoryDescriptor> DescribeCategories();
        /// Describes all audit trail event providers.
        DescribeContext DescribeProviders();
        /// Describes a single audit trail event.
        /// <param name="record">The audit trail event record for which to find its descriptor.</param>
        /// <returns>A single audit trail event descriptor.</returns>
        AuditTrailEventDescriptor DescribeEvent(AuditTrailEventRecord record);
        /// <typeparam name="T">The scope of the specified event name.</typeparam>
        /// <param name="eventName">The shorthand name of the event.</param>
        AuditTrailEventDescriptor DescribeEvent<T>(string eventName) where T : IAuditTrailEventProvider;
        /// <param name="fullyQualifiedEventName">The fully qualified event name to describe.</param>
        AuditTrailEventDescriptor DescribeEvent(string fullyQualifiedEventName);
        /// Trims the audit trail by deleting all records older than the specified retention period.
        /// <returns>A list of deleted records.</returns>
        IEnumerable<AuditTrailEventRecord> Trim(TimeSpan retentionPeriod);
        /// Serializes the specified list of settings into a string.
        string SerializeProviderConfiguration(IEnumerable<AuditTrailEventSetting> settings);
        /// Deserializes the specified string into a list of settings.
        IEnumerable<AuditTrailEventSetting> DeserializeProviderConfiguration(string data);
    }
}
