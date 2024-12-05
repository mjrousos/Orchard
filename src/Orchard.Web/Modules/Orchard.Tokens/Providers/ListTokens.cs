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
using System.Web;
using System.Linq;

namespace Orchard.Tokens.Providers {
    public class ListTokens : ITokenProvider {
        private readonly Func<ITokenizer> _tokenizer;

        public ListTokens(Func<ITokenizer> tokenizer) {
            _tokenizer = tokenizer;
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        public void Describe(DescribeContext context) {
            context.For("List", T("Lists"), T("Handles lists of Content Items"))
                .Token("Join:*", T("Join:<Tokenized text>[,<separator>]"), T("Join each element in the list by applying the tokenized text and concatenating the output with the optional separator."))
                .Token("Sum:*", T("Sum:<Tokenized text>"), T("Sum each element in the list by applying the tokenized text."))
                .Token("First:*", T("First:<Tokenized text>"), T("Apply the tokenized text to the first element."))
                .Token("Last:*", T("Last:<Tokenized text>"), T("Apply the tokenized text to the last element."))
                .Token("Count", T("Count"), T("Get the list count."))
                .Token("ElementAt:*", T("ElementAt:<index>,<Tokenized text>"), T("Apply the tokenized text to the element at its index."));
        }

        public void Evaluate(EvaluateContext context) {
            Func<string, IContent, string> tokenValue = (t, i) => _tokenizer().Replace(t, new { Content = i }, new ReplaceOptions { Encoding = ReplaceOptions.NoEncode });

            context.For<IList<IContent>>("List", () => new List<IContent>())
                .Token( // {List.Join:<string>[,<separator>]}
                    token => FilterToken(token, "Join:"),
                    (token, list) => {
                        if (String.IsNullOrEmpty(token) || !list.Any()) {
                            return String.Empty;
                        }
                        // Split the token to get the tokenized text and optional separator.
                        var index = token.IndexOf(',');
                        var text = index == -1 ? token : token.Substring(0, index);
                        if (String.IsNullOrEmpty(text)) {
                            return String.Empty;
                        }
                        var separator = index == -1 ? String.Empty : token.Substring(index + 1);
                        return String.Join(separator, list.Select(content => tokenValue(text, content)));
                    })
                .Token( // {List.Sum:<string>}
                    token => FilterToken(token, "Sum:"),
                    (token, list) => {
                        if (String.IsNullOrEmpty(token) || !list.Any()) {
                            return "0";
                        }
                        // try long.
                        if (long.TryParse(list.Select(i => tokenValue(token, i)).First(), out long longValue)) {
                            return list.Sum(i => long.Parse(tokenValue(token, i))).ToString();
                        }
                        // try float.
                        if (float.TryParse(list.Select(i => tokenValue(token, i)).First(), out float floatValue)) {
                            return list.Sum(i => float.Parse(tokenValue(token, i))).ToString();
                        }
                        // try decimal.
                        if (decimal.TryParse(list.Select(i => tokenValue(token, i)).First(), out decimal decimalValue)) {
                            return list.Sum(i => decimal.Parse(tokenValue(token, i))).ToString();
                        }
                        return "";
                    })
                .Token( // {List.First:<string>}
                    token => FilterToken(token, "First:"),
                    (token, list) => String.IsNullOrEmpty(token) || !list.Any() ? String.Empty : list.Select(i => tokenValue(token, i)).First())
                .Token( // {List.Last:<string>}
                    token => FilterToken(token, "Last:"),
                    (token, list) => String.IsNullOrEmpty(token) || !list.Any() ? String.Empty : list.Select(i => tokenValue(token, i)).Last())
                .Token( // {List.Count}
                    "Count",
                    list => list.Count.ToString())
                .Token( // {List.ElementAt:<index>,<string>}
                    token => FilterToken(token, "ElementAt:"),
                    (token, list) => {
                        if (String.IsNullOrEmpty(token) || !list.Any()) {
                            return String.Empty;
                        }
                        // Split the token to get the index and the tokenized text.
                        var delimiterIndex = token.IndexOf(',');
                        if (delimiterIndex == -1) {
                            return String.Empty;
                        }
                        var text = token.Substring(delimiterIndex + 1);
                        if (String.IsNullOrEmpty(text)) {
                            return String.Empty;
                        }
                        if (!int.TryParse(token.Substring(0, delimiterIndex), out int index)) {
                            return String.Empty;
                        }
                        if (index < 0 || index >= list.Count) {
                            return String.Empty;
                        }
                        return list.Select(i => tokenValue(text, i)).ElementAt(index);
                    });
        }

        private static string FilterToken(string token, string operation) {
            if (token.StartsWith(operation, StringComparison.OrdinalIgnoreCase)) {
                // html decode to stop double encoding.
                return HttpUtility.HtmlDecode(token.Substring(operation.Length));
            }
            return null;
        }
    }
}
