﻿//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------
namespace Microsoft.Azure.Cosmos.CosmosElements
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Cosmos.Json;

#if INTERNAL
#pragma warning disable SA1601 // Partial elements should be documented
    public abstract partial class CosmosBinary : CosmosElement
#else
    internal abstract partial class CosmosBinary : CosmosElement
#endif
    {
        private sealed class EagerCosmosBinary : CosmosBinary
        {
            public EagerCosmosBinary(IReadOnlyList<byte> value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(value)}");
                }

                this.Value = value;
            }

            public override IReadOnlyList<byte> Value { get; }

            public override void WriteTo(IJsonWriter jsonWriter)
            {
                if (jsonWriter == null)
                {
                    throw new ArgumentNullException($"{nameof(jsonWriter)}");
                }

                jsonWriter.WriteBinaryValue(this.Value);
            }
        }
    }
#if INTERNAL
#pragma warning restore SA1601 // Partial elements should be documented
#endif
}