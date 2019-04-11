﻿using System.Collections.Generic;
using System.Composition;

namespace Microsoft.CodeAnalysis.ExternalAccess.FSharp.Diagnostics
{
    [Shared]
    [Export(typeof(IDiagnosticAnalyzerService))]
    internal class DiagnosticAnalyzerService : IDiagnosticAnalyzerService
    {
        private readonly Microsoft.CodeAnalysis.Diagnostics.IDiagnosticAnalyzerService _delegatee;

        [ImportingConstructor]
        public DiagnosticAnalyzerService(Microsoft.CodeAnalysis.Diagnostics.IDiagnosticAnalyzerService delegatee)
        {
            _delegatee = delegatee;
        }

        public void Reanalyze(Workspace workspace, IEnumerable<ProjectId> projectIds = null, IEnumerable<DocumentId> documentIds = null, bool highPriority = false)
        {
            _delegatee.Reanalyze(workspace, projectIds, documentIds, highPriority);
        }
    }
}
