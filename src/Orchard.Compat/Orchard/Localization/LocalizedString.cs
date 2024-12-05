using System;
using System.Globalization;

namespace Orchard.Localization
{
    public class LocalizedString
    {
        private readonly string _localized;
        private readonly string _scope;
        private readonly string _textHint;
        private readonly object[] _args;

        public LocalizedString(string localized)
        {
            _localized = localized;
            _scope = String.Empty;
            _textHint = String.Empty;
            _args = Array.Empty<object>();
        }

        public LocalizedString(string localized, string scope, string textHint, params object[] args)
        {
            _localized = localized;
            _scope = scope;
            _textHint = textHint;
            _args = args;
        }

        public string Text
        {
            get
            {
                if (_args == null || _args.Length == 0)
                    return _localized;

                return String.Format(CultureInfo.InvariantCulture, _localized, _args);
            }
        }

        public string Scope => _scope;
        public string TextHint => _textHint;
        public object[] Args => _args;

        public static implicit operator string(LocalizedString str)
        {
            return str.Text;
        }

        public static implicit operator LocalizedString(string str)
        {
            return new LocalizedString(str);
        }

        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is LocalizedString))
                return false;

            var other = (LocalizedString)obj;
            return string.Equals(Text, other.Text);
        }

        public override int GetHashCode()
        {
            return Text?.GetHashCode() ?? 0;
        }
    }
}
