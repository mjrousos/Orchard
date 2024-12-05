using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Globalization;
using System.Linq;
using Orchard.Events;

namespace Orchard.Localization.Conditions {
    public interface IConditionProvider : IEventHandler {
        void Evaluate(dynamic evaluationContext);
    }
    public class CultureConditionProvider : IConditionProvider
    {
        private readonly WorkContext _workContext;
        public CultureConditionProvider(WorkContext workContext) {
            _workContext = workContext;
        }
        
        public void Evaluate(dynamic evaluationContext)
        {
            if (String.Equals(evaluationContext.FunctionName, "culturecode", StringComparison.OrdinalIgnoreCase)) {
                ProcessCultureCode(evaluationContext);
            }
            if (String.Equals(evaluationContext.FunctionName, "culturelcid", StringComparison.OrdinalIgnoreCase)) {
                ProcessCultureId(evaluationContext);
            if (String.Equals(evaluationContext.FunctionName, "cultureisrtl", StringComparison.OrdinalIgnoreCase)) {
                ProcessCurrentCultureIsRtl(evaluationContext);
            if (String.Equals(evaluationContext.FunctionName, "culturelang", StringComparison.OrdinalIgnoreCase)) {
                ProcessLanguageCode(evaluationContext);
        private void ProcessCurrentCultureIsRtl(dynamic ruleContext) {
            var currentUserCulture = CultureInfo.GetCultureInfo(_workContext.CurrentCulture);
            var isRtl = ((object[]) ruleContext.Arguments)
                .Cast<bool>()
                .SingleOrDefault();
            ruleContext.Result = (isRtl == currentUserCulture.TextInfo.IsRightToLeft);
        private void ProcessCultureCode(dynamic ruleContext) {
            ruleContext.Result = ((object[])ruleContext.Arguments)
                .Cast<string>()
                .Select(CultureInfo.GetCultureInfo)
                .Any(c => c.Name == currentUserCulture.Name);
        private void ProcessLanguageCode(dynamic ruleContext) {
                .Any(c => c.Name == currentUserCulture.TwoLetterISOLanguageName);
        private void ProcessCultureId(dynamic ruleContext) {
                .Cast<int>()
}
