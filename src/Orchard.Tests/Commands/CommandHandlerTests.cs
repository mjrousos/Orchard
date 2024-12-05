using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Orchard.Commands;
using System;
using System.Linq;

namespace Orchard.Tests.Commands {
    [TestFixture]
    public class CommandsTests {
        private ICommandHandler _handler;
        [SetUp]
        public void Init() {
            _handler = new StubCommandHandler();
        }
        private CommandContext CreateCommandContext(string commandName) {
            return CreateCommandContext(commandName, new Dictionary<string, string>(), new string[]{});
        private CommandContext CreateCommandContext(string commandName, IDictionary<string, string> switches) {
            return CreateCommandContext(commandName, switches, new string[]{});
        private CommandContext CreateCommandContext(string commandName, IDictionary<string, string> switches, string[] args) {
            var builder = new CommandHandlerDescriptorBuilder();
            var descriptor = builder.Build(typeof(StubCommandHandler));
            var commandDescriptor = descriptor.Commands.Single(d => string.Equals(d.Name, commandName, StringComparison.OrdinalIgnoreCase));
            return new CommandContext { 
                Command = commandName, 
                Switches = switches, 
                CommandDescriptor = commandDescriptor,
                Arguments = args,
                Input = new StringReader(string.Empty),
                Output = new StringWriter()
            };
        [Test]
        public void TestFooCommand() {
            var commandContext = CreateCommandContext("Foo");
            _handler.Execute(commandContext);
            Assert.That(commandContext.Output.ToString(), Is.EqualTo("Command Foo Executed"));
        public void TestNotExistingCommand() {
            Assert.Throws<InvalidOperationException>(() => {
                var commandContext = CreateCommandContext("NoSuchCommand");
                _handler.Execute(commandContext);
            });
        public void TestCommandWithCustomAlias() {
            var commandContext = CreateCommandContext("Bar");
            Assert.That(commandContext.Output.ToString(), Is.EqualTo("Hello World!"));
        public void TestHelpText() {
            var commandContext = CreateCommandContext("Baz");
            Assert.That(commandContext.CommandDescriptor.HelpText, Is.EqualTo("Baz help"));
        public void TestEmptyHelpText() {
            Assert.That(commandContext.CommandDescriptor.HelpText, Is.EqualTo(string.Empty));
        public void TestCaseInsensitiveForCommand() {
            var commandContext = CreateCommandContext("BAZ", new Dictionary<string, string> { { "VERBOSE", "true" } });
            Assert.That(commandContext.Output.ToString(), Is.EqualTo("Command Baz Called : This was a test"));
        public void TestBooleanSwitchForCommand() {
            var commandContext = CreateCommandContext("Baz", new Dictionary<string, string> {{"Verbose", "true"}});
        public void TestIntSwitchForCommand() {
            var commandContext = CreateCommandContext("Baz", new Dictionary<string, string> {{"Level", "2"}});
            Assert.That(commandContext.Output.ToString(), Is.EqualTo("Command Baz Called : Entering Level 2"));
        public void TestStringSwitchForCommand() {
            var commandContext = CreateCommandContext("Baz", new Dictionary<string, string> {{"User", "OrchardUser"}});
            Assert.That(commandContext.Output.ToString(), Is.EqualTo("Command Baz Called : current user is OrchardUser"));
        public void TestSwitchForCommandWithoutSupportForIt() {
            var switches = new Dictionary<string, string> {{"User", "OrchardUser"}};
            var commandContext = CreateCommandContext("Foo", switches);
            Assert.Throws<InvalidOperationException>(() => _handler.Execute(commandContext));
        public void TestCommandThatDoesNotReturnAValue() {
            var commandContext = CreateCommandContext("Log");
            Assert.That(commandContext.Output.ToString(), Is.EqualTo(""));
        public void TestNotExistingSwitch() {
            var switches = new Dictionary<string, string> {{"ThisSwitchDoesNotExist", "Insignificant"}};
        public void TestCommandArgumentsArePassedCorrectly() {
            var commandContext = CreateCommandContext("Concat", new Dictionary<string, string>(), new[] {"left to ", "right"});
            Assert.That(commandContext.Output.ToString(), Is.EqualTo("left to right"));
        public void TestCommandArgumentsArePassedCorrectlyWithAParamsParameters() {
            var commandContext = CreateCommandContext("ConcatParams", new Dictionary<string, string>(), new[] {"left to ", "right"});
        public void TestCommandArgumentsArePassedCorrectlyWithAParamsParameterAndNoArguments() {
            var commandContext = CreateCommandContext("ConcatParams", new Dictionary<string, string>());
        public void TestCommandArgumentsArePassedCorrectlyWithNormalParametersAndAParamsParameters() {
            var commandContext = CreateCommandContext("ConcatAllParams",
                new Dictionary<string, string>(),
                new[] { "left-", "center-", "right"});
            Assert.That(commandContext.Output.ToString(), Is.EqualTo("left-center-right"));
        public void TestCommandParamsMismatchWithoutParamsNotEnoughArguments() {
            var commandContext = CreateCommandContext("Concat", new Dictionary<string, string>(), new[] { "left to " });
        public void TestCommandParamsMismatchWithoutParamsTooManyArguments() {
            var commandContext = CreateCommandContext("Foo", new Dictionary<string, string>(), new[] { "left to " });
        public void TestCommandParamsMismatchWithParamsButNotEnoughArguments() {
            var commandContext = CreateCommandContext("ConcatAllParams", new Dictionary<string, string>());
    }
    public class StubCommandHandler : DefaultOrchardCommandHandler {
        [OrchardSwitch]
        public bool Verbose { get; set; }
        public int Level { get; set; }
        public string User { get; set; }
        public string Foo() {
            return "Command Foo Executed";
        [CommandName("Bar")]
        public string Hello() {
            return "Hello World!";
        [OrchardSwitches("Verbose, Level, User")]
        [CommandHelp("Baz help")]
        public string Baz() {
            string trace = "Command Baz Called";
            if (Verbose) {
                trace += " : This was a test";
            }
            if (Level == 2) {
                trace += " : Entering Level 2";
            if (!String.IsNullOrEmpty(User)) {
                trace += " : current user is " + User;
            return trace;
        public string Concat(string left, string right) {
            return left + right;
        public string ConcatParams(params string[] parameters) {
            string concatenated = "";
            foreach (var s in parameters) {
                concatenated += s;
            return concatenated;
        public string ConcatAllParams(string leftmost, params string[] rest) {
            string concatenated = leftmost;
            foreach (var s in rest) {
        public void Log() {
            return;
}
