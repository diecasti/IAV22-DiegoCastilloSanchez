﻿using System;

namespace Ludiq
{
    public sealed class AmbiguousOperatorException : OperatorException
    {
        public AmbiguousOperatorException(string symbol, Type leftType, Type rightType) : base($"Ambiguous use of operator '{symbol}' between types '{leftType?.ToString() ?? "null"}' and '{rightType?.ToString() ?? "null"}'.") { }
    }
}