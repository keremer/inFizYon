﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xbim.Common.Exceptions
{

    [Serializable]
    public class XbimInitializationFailedException : Exception
    {
        public XbimInitializationFailedException() { }
        public XbimInitializationFailedException(string message) : base(message) { }
        public XbimInitializationFailedException(string message, Exception inner) : base(message, inner) { }
        protected XbimInitializationFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
