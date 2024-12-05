using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Localization {
    public static class Constants {
        public static string TransliterationDefaultValue = @"
[Input]
// Insert a several-word description of the module’s input.
// For example:
//     Romanization

[Output]
// Insert a several-word description of the module’s output.
//     Cyrillic
[Description]
// Give a several-sentence description of the module.
[Preprocess]
// If you need to preprocess your input before applying
// rules specify the procedure here.  
//     ToLower
//     ToUpper(tr-TR)
[States]
// If you need any states other than the two predefined ones
// (START and DEFAULT) then declare their names here.  
//     CONSONANT
//     VOWEL
[FollowingContextMacros]
// Insert any following context macro definitions here.
//     Cons        b c d f g h j k l m n p q r s t v w x y z
//     ConsOrEnd   <END> :Cons:
//     Vowel       a e i o u
//     VowelAtEnd  a<END> e<END> i<END> o<END> u<END>
[EscapeSpanDelimiters]
// If you need to be able to prevent spans of the input
// from being processed you can specify one pair of strings
// to indicate the beginning and end of such escaped spans.   
//     {   }
//     /*  */
[Rules]
// List your rules here.  For example:
//             a          –> x
//             a(<END>)   –> y
//     [START] fa         –> z [VOWEL]
";
    }
}
