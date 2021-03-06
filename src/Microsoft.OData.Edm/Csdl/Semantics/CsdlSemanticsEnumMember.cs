//---------------------------------------------------------------------
// <copyright file="CsdlSemanticsEnumMember.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

using System;
using Microsoft.OData.Edm.Csdl.Parsing.Ast;
using Microsoft.OData.Edm.Library;
using Microsoft.OData.Edm.Library.Values;
using Microsoft.OData.Edm.Values;

namespace Microsoft.OData.Edm.Csdl.CsdlSemantics
{
    /// <summary>
    /// Provides semantics for a CsdlEnumMember.
    /// </summary>
    internal class CsdlSemanticsEnumMember : CsdlSemanticsElement, IEdmEnumMember
    {
        private readonly CsdlEnumMember member;
        private readonly CsdlSemanticsEnumTypeDefinition declaringType;

        private readonly Cache<CsdlSemanticsEnumMember, IEdmPrimitiveValue> valueCache = new Cache<CsdlSemanticsEnumMember, IEdmPrimitiveValue>();
        private static readonly Func<CsdlSemanticsEnumMember, IEdmPrimitiveValue> ComputeValueFunc = (me) => me.ComputeValue();

        public CsdlSemanticsEnumMember(CsdlSemanticsEnumTypeDefinition declaringType, CsdlEnumMember member)
            : base(member)
        {
            this.member = member;
            this.declaringType = declaringType;
        }

        public string Name
        {
            get { return this.member.Name; }
        }

        public IEdmEnumType DeclaringType
        {
            get { return this.declaringType; }
        }

        public IEdmPrimitiveValue Value
        {
            get { return this.valueCache.GetValue(this, ComputeValueFunc, null); }
        }

        public override CsdlSemanticsModel Model
        {
            get { return this.declaringType.Model; }
        }

        public override CsdlElement Element
        {
            get { return this.member; }
        }

        private IEdmPrimitiveValue ComputeValue()
        {
            return new EdmIntegerConstant(new EdmPrimitiveTypeReference(this.DeclaringType.UnderlyingType, false), this.member.Value.Value);
        }
    }
}
