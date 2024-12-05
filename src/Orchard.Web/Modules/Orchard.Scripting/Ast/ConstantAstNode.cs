using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Scripting.Compiler;

namespace Orchard.Scripting.Ast {
    public class ConstantAstNode : AstNode, IAstNodeWithToken {
        private readonly Token _token;
        public ConstantAstNode(Token token) {
            _token = token;
        }
        public Token Token {
            get { return _token; }
        public object Value { get { return _token.Value; } }
        public override object Accept(AstVisitor visitor) {
            return visitor.VisitConstant(this);
    }
}
