using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace EditorClassifierMaxMinLenRow
{
    internal static class EditorClassifierMaxMinLenRowClassificationDefinition
    {
        /// <summary>
        /// Defines the "EditorClassifierMaxMinLenRow" classification type.
        /// </summary>
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("VeryLongStr")]
        internal static ClassificationTypeDefinition VeryLongStrFormat = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("LongStr")]
        internal static ClassificationTypeDefinition MinLenRowFormat = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("NormStr")]
        internal static ClassificationTypeDefinition NormStrFormat = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("SmallStr")]
        internal static ClassificationTypeDefinition SmallStrFormat = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("VerySmallStr")]
        internal static ClassificationTypeDefinition VerySmallStrFormat = null;
    }
}
