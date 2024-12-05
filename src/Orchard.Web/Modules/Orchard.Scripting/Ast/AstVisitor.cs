using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;

namespace Orchard.Scripting.Ast {
    public class AstVisitor {
        public virtual object Visit(AstNode node) {
            return node.Accept(this);
        }
        public virtual object VisitChildren(AstNode node) {
            return node.Children.Aggregate<AstNode, object>(null, (prev, child) => Visit(child));
        public virtual object VisitBinary(BinaryAstNode node) {
            return null;
        public virtual object VisitConstant(ConstantAstNode node) {
        public virtual object VisitError(ErrorAstNode node) {
        public virtual object VisitUnary(UnaryAstNode node) {
        public virtual object VisitMethodCall(MethodCallAstNode node) {
    }
}
