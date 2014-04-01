//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

using Microsoft.OData.Edm.Csdl.Parsing.Ast;

namespace Microsoft.OData.Edm.Csdl.CsdlSemantics
{
    /// <summary>
    /// Provides semantics for an out-of-line CSDL Annotations.
    /// </summary>
    internal class CsdlSemanticsAnnotations
    {
        private readonly CsdlAnnotations annotations;
        private readonly CsdlSemanticsSchema context;

        public CsdlSemanticsAnnotations(CsdlSemanticsSchema context, CsdlAnnotations annotations)
        {
            this.context = context;
            this.annotations = annotations;
        }

        public CsdlSemanticsSchema Context
        {
            get { return this.context; }
        }

        public CsdlAnnotations Annotations
        {
            get { return this.annotations; }
        }
    }
}