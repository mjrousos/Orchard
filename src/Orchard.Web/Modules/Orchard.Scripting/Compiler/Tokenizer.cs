using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Text;

namespace Orchard.Scripting.Compiler {
    public class Tokenizer {
        private readonly string _expression;
        private readonly StringBuilder _stringBuilder;
        private int _index;
        private int _startTokenIndex;
        public Tokenizer(string expression) {
            _expression = expression;
            _stringBuilder = new StringBuilder();
        }
        public Token NextToken() {
            while (true) {
                if (Eof())
                    return CreateToken(TokenKind.Eof);
                _startTokenIndex = _index;
                char ch = Character();
                switch (ch) {
                    case '(':
                        NextCharacter();
                        return CreateToken(TokenKind.OpenParen);
                    case ')':
                        return CreateToken(TokenKind.CloseParen);
                    case ',':
                        return CreateToken(TokenKind.Comma);
                    case '+':
                        return CreateToken(TokenKind.Plus);
                    case '-':
                        return CreateToken(TokenKind.Minus);
                    case '*':
                        return CreateToken(TokenKind.Mul);
                    case '/':
                        return CreateToken(TokenKind.Div);
                    case '"':
                        return LexStringLiteral();
                    case '\'':
                        return LexSingleQuotedStringLiteral();
                    case '!':
                        return LexNotSign();
                    case '|':
                        return LexOrSign();
                    case '&':
                        return LexAndSign();
                    case '=':
                        return LexEqual();
                    case '<':
                        return LexLessThan();
                    case '>':
                        return LexGreaterThan();
                }
                if (IsDigitCharacter(ch)) {
                    return LexInteger();
                if (IsIdentifierCharacter(ch)) {
                    return LexIdentifierOrKeyword();
                if (IsWhitespaceCharacter(ch)) {
                    NextCharacter();
                    continue;
                return InvalidToken();
            }
        private Token InvalidToken() {
            return CreateToken(TokenKind.Invalid, "Unrecognized character");
        private Token LexNotSign() {
            NextCharacter();
            char ch = Character();
            if (ch == '=') {
                NextCharacter();
                return CreateToken(TokenKind.NotEqual);
            return CreateToken(TokenKind.NotSign);
        private Token LexOrSign() {
            if (ch == '|') {
                return CreateToken(TokenKind.OrSign);
            return InvalidToken();
        private Token LexAndSign() {
            if (ch == '&') {
                return CreateToken(TokenKind.AndSign);
        private Token LexGreaterThan() {
                return CreateToken(TokenKind.GreaterThanEqual);
            return CreateToken(TokenKind.GreaterThan);
        private Token LexLessThan() {
                return CreateToken(TokenKind.LessThanEqual);
            return CreateToken(TokenKind.LessThan);
        private Token LexEqual() {
                return CreateToken(TokenKind.EqualEqual);
            return CreateToken(TokenKind.Equal);
        private Token LexIdentifierOrKeyword() {
            _stringBuilder.Clear();
            _stringBuilder.Append(Character());
                if (!Eof() && (IsIdentifierCharacter(Character()) || IsDigitCharacter(Character()))) {
                    _stringBuilder.Append(Character());
                else {
                    return CreateIdentiferOrKeyword(_stringBuilder.ToString());
        private Token LexInteger() {
                if (!Eof() && IsDigitCharacter(Character())) {
                    return CreateToken(TokenKind.Integer, Int32.Parse(_stringBuilder.ToString()));
        private Token CreateIdentiferOrKeyword(string identifier) {
            switch (identifier) {
                case "true":
                    return CreateToken(TokenKind.True, true);
                case "false":
                    return CreateToken(TokenKind.False, false);
                case "or":
                    return CreateToken(TokenKind.Or, null);
                case "and":
                    return CreateToken(TokenKind.And, null);
                case "not":
                    return CreateToken(TokenKind.Not, null);
                case "null":
                case "nil":
                    return CreateToken(TokenKind.NullLiteral, null);
                default:
                    return CreateToken(TokenKind.Identifier, identifier);
        private static bool IsWhitespaceCharacter(char character) {
            return char.IsWhiteSpace(character);
        private static bool IsIdentifierCharacter(char ch) {
            return
                (ch >= 'a' && ch <= 'z') ||
                (ch >= 'A' && ch <= 'Z') ||
                (ch == '_');
        private static bool IsDigitCharacter(char ch) {
            return ch >= '0' && ch <= '9';
        private Token LexSingleQuotedStringLiteral() {
                    return CreateToken(TokenKind.Invalid, "Unterminated string literal");
                // Termination
                if (Character() == '\'') {
                    return CreateToken(TokenKind.SingleQuotedStringLiteral, _stringBuilder.ToString());
                // backslash notation
                if (Character() == '\\') {
                    if (Eof())
                        return CreateToken(TokenKind.Invalid, "Unterminated string literal");
                    switch (Character()) {
                        case '\\':
                            _stringBuilder.Append('\\');
                            break;
                        case '\'':
                            _stringBuilder.Append('\'');
                        default:
                            _stringBuilder.Append(Character());
                    }
                    // Regular character in string
        private Token LexStringLiteral() {
                if (Character() == '"') {
                    return CreateToken(TokenKind.StringLiteral, _stringBuilder.ToString());
        private void NextCharacter() {
            _index++;
        private char Character() {
            return _expression[_index];
        private Token CreateToken(TokenKind kind, object value = null) {
            return new Token {
                Kind = kind,
                Position = _startTokenIndex,
                Value = value
            };
        private bool Eof() {
            return (_index >= _expression.Length);
    }
}
