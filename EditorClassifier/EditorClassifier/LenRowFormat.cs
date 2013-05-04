using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace EditorClassifierMaxMinLenRow
{
    #region Format VeryLongStr
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "VeryLongStr")]
    [Name("VeryLongStr")]
    [UserVisible(true)] //this should be visible to the end user
    [Order(Before = Priority.Default)] //set the priority to be after the default classifiers
    internal sealed class VeryLongStrFormat : ClassificationFormatDefinition
    {
        public VeryLongStrFormat()
        {
            this.BackgroundColor = Color.FromArgb(100, 255, 0, 0);
        }
    }
    #endregion 

    #region Format LongStr
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "LongStr")]
    [Name("LongStr")]
    [UserVisible(true)] 
    [Order(Before = Priority.Default)] 
    internal sealed class MinLenRowFormat : ClassificationFormatDefinition
    {
        public MinLenRowFormat()
        {
            this.BackgroundColor = Color.FromArgb(100, 255, 165, 0);
        }
    }
    #endregion

    #region Format NormStr
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "NormStr")]
    [Name("NormStr")]
    [UserVisible(true)]
    [Order(Before = Priority.Default)]
    internal sealed class NormStrFormat : ClassificationFormatDefinition
    {
        public NormStrFormat()
        {
            this.BackgroundColor = Color.FromArgb(100, 255, 255, 0);
        }
    }
    #endregion

    #region Format SmallStr
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "SmallStr")]
    [Name("SmallStr")]
    [UserVisible(true)]
    [Order(Before = Priority.Default)]
    internal sealed class SmallStrFormat : ClassificationFormatDefinition
    {
        public SmallStrFormat()
        {
            this.BackgroundColor = Color.FromArgb(100, 180, 255, 0);
        }
    }
    #endregion

    #region Format VerySmallStr
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "VerySmallStr")]
    [Name("VerySmallStr")]
    [UserVisible(true)]
    [Order(Before = Priority.Default)]
    internal sealed class VerySmallStrFormat : ClassificationFormatDefinition
    {
        public VerySmallStrFormat()
        {
            this.BackgroundColor = Color.FromArgb(100, 0, 255,0);
        }
    }
    #endregion

}
