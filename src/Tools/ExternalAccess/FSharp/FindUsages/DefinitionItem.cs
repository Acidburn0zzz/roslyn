﻿using System.Collections.Immutable;

namespace Microsoft.CodeAnalysis.ExternalAccess.FSharp.FindUsages
{
    public class DefinitionItem
    {
        private readonly Microsoft.CodeAnalysis.FindUsages.DefinitionItem _roslynDefinitionItem;

        private DefinitionItem(Microsoft.CodeAnalysis.FindUsages.DefinitionItem roslynDefinitionItem)
        {
            _roslynDefinitionItem = roslynDefinitionItem;
        }

        internal Microsoft.CodeAnalysis.FindUsages.DefinitionItem RoslynDefinitionItem
        {
            get
            {
                return _roslynDefinitionItem;
            }
        }

        public static DefinitionItem Create(ImmutableArray<string> tags, ImmutableArray<TaggedText> displayParts, DocumentSpan sourceSpan)
        {
            return new DefinitionItem(Microsoft.CodeAnalysis.FindUsages.DefinitionItem.Create(tags, displayParts, sourceSpan.ToRoslynDocumentSpan()));
        }

        public static DefinitionItem CreateNonNavigableItem(ImmutableArray<string> tags, ImmutableArray<TaggedText> displayParts, ImmutableArray<TaggedText> originationParts)
        {
            return new DefinitionItem(Microsoft.CodeAnalysis.FindUsages.DefinitionItem.CreateNonNavigableItem(tags, displayParts, originationParts));
        }
    }
}
