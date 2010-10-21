﻿using System;
using System.Collections.Generic;

namespace Lextm.SharpSnmpLib.Pipeline
{
    /// <summary>
    /// GET NEXT message handler.
    /// </summary>    
    public class GetNextV1MessageHandler : IMessageHandler
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="store">The object store.</param>
        /// <returns></returns>
        public ResponseData Handle(SnmpContext context, ObjectStore store)
        {
            ErrorCode status = ErrorCode.NoError;
            int index = 0;
            IList<Variable> result = new List<Variable>();
            foreach (Variable v in context.Request.Pdu.Variables)
            {
                index++;
                try
                {
                    ScalarObject next = store.GetNextObject(v.Id);
                    if (next == null)
                    {
                        status = ErrorCode.NoSuchName;
                    }
                    else
                    {
                        // TODO: how to handle write only object here?
                        result.Add(next.Variable);
                    }
                }
                catch (Exception)
                {
                    return new ResponseData(context.Request.Pdu.Variables, ErrorCode.GenError, index);
                }
                
                if (status != ErrorCode.NoError)
                {
                    return new ResponseData(null, status, index);
                }
            }

            return new ResponseData(result, status, index);
        }
    }
}