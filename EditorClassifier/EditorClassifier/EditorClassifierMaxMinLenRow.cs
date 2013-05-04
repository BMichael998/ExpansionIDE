using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Media;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.Text.RegularExpressions;

namespace EditorClassifierMaxMinLenRow
{

    #region Provider definition
    /// <summary>
    /// This class causes a classifier to be added to the set of classifiers. Since 
    /// the content type is set to "text", this classifier applies to all text files
    /// </summary>
    [Export(typeof(IClassifierProvider))]
    [ContentType("text")]
    internal class EditorClassifierMaxMinLenRowProvider : IClassifierProvider
    {
        /// <summary>
        /// Import the classification registry to be used for getting a reference
        /// to the custom classification type later.
        /// </summary>
        [Import]
        internal IClassificationTypeRegistryService ClassificationRegistry = null; // Set via MEF


        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            return new EditorClassifierMaxMinLenRow(buffer, ClassificationRegistry);
            //return buffer.Properties.GetOrCreateSingletonProperty<EditorClassifierMaxMinLenRow>(delegate { return new EditorClassifierMaxMinLenRow(ClassificationRegistry); });
        }
    }
    #endregion //provider def

    #region Classifier
    /// <summary>
    /// Classifier that classifies all text as an instance of the OrinaryClassifierType
    /// </summary>
    internal sealed class EditorClassifierMaxMinLenRow : IClassifier
    {

        IClassificationType _classificationTypeVeryLong;
        IClassificationType _classificationTypeLong;
        IClassificationType _classificationTypeNormal;
        IClassificationType _classificationTypeSmall;
        IClassificationType _classificationTypeVerySmall;
        private ITextBuffer buffer;


        internal EditorClassifierMaxMinLenRow(ITextBuffer bufferToClassify, IClassificationTypeRegistryService registry)
        {
            buffer = bufferToClassify;
            _classificationTypeVeryLong = registry.GetClassificationType("VeryLongStr");
            _classificationTypeLong = registry.GetClassificationType("LongStr"); ;
            _classificationTypeNormal = registry.GetClassificationType("NormStr"); ;
            _classificationTypeSmall = registry.GetClassificationType("SmallStr"); ;
            _classificationTypeVerySmall = registry.GetClassificationType("VerySmallStr"); ;
        }

        /// <summary>
        /// This method scans the given SnapshotSpan for potential matches for this classification.
        /// In this instance, it classifies everything and returns each span as a new ClassificationSpan.
        /// </summary>
        /// <param name="trackingSpan">The span currently being classified</param>
        /// <returns>A list of ClassificationSpans that represent spans identified to be of this classification</returns>
        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            ITextSnapshot snapshot = span.Snapshot;

            List<ClassificationSpan> spans = new List<ClassificationSpan>();

            if (snapshot.Length == 0)
                return spans;

            var text = span.GetText();
            int maxLength = 80;
            int step = 15;

            IClassificationType type = _classificationTypeVerySmall;

            if (text.Length >= maxLength)
            {
                type = _classificationTypeVeryLong;
            }
            else if (text.Length >= maxLength - step)
            {
                type = _classificationTypeLong;
            }
            else if (text.Length >= maxLength - step * 2)
            {
                type = _classificationTypeNormal;
            }
            else if (text.Length >= maxLength - step * 3)
            {
                type = _classificationTypeSmall;
            }
            else if (text.Length >= maxLength - step * 4)
            {
                type = _classificationTypeVerySmall;
            }

            spans.Add(new ClassificationSpan(span, type));
            return spans;
        }



        /*
        private void ProcessLine(ITextSnapshotLine line,List<ITextSnapshotLine> minLines,List<ITextSnapshotLine> maxLines, ref int min,ref int max)
        {
            
            var text = line.GetText();
            if (String.IsNullOrWhiteSpace(text))
            {
                return;
            }
            if (text.Length > max)
            {
                max = text.Length;
                maxLines.Clear();
                maxLines.Add(line);
            }
            else if (text.Length == max)
            {
                maxLines.Add(line);
            }
            if (line.Length<min)
            {
                min = text.Length;
                minLines.Clear();
                minLines.Add(line);
            }
            else if (text.Length == min)
            {
                minLines.Add(line);
            }
        }*/

#pragma warning disable 67
        // This event gets raised if a non-text change would affect the classification in some way,
        // for example typing /* would cause the classification to change in C# without directly
        // affecting the span.
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
#pragma warning restore 67
    }
    #endregion //Classifier



}
