using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Scripting.Compiler {
    public enum TokenKind {
        Invalid,
        Eof,
        OpenParen,
        CloseParen,
        StringLiteral,
        SingleQuotedStringLiteral,
        Identifier,
        Integer,
        Comma,
        Plus,
        Minus,
        Mul,
        Div,
        True,
        False,
        And,
        AndSign,
        Or,
        OrSign,
        Not,
        NotSign,
        Equal,
        EqualEqual,
        NotEqual,
        LessThan,
        LessThanEqual,
        GreaterThan,
        GreaterThanEqual,
        NullLiteral
    }
}
