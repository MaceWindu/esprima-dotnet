﻿using System.Collections.Generic;

namespace Esprima
{
    public class ErrorHandler : IErrorHandler
    {
        public List<Error> Errors { get; }
        public bool Tolerant { get; set; }

        public ErrorHandler()
        {
            Errors = new List<Error>();
            Tolerant = false;
        }

        public void RecordError(Error error)
        {
            Errors.Add(error);
        }

        public void Tolerate(Error error)
        {
            if (Tolerant)
            {
                RecordError(error);
            }
            else
            {
                throw error;
            }
        }

        public void ThrowError(int index, int line, int column, string message)
        {
            throw this.CreateError(index, line, column, message);
        }

        public void TolerateError(int index, int line, int col, string description)
        {
            var error = this.CreateError(index, line, col, description);
            if (Tolerant)
            {
                this.RecordError(error);
            }
            else
            {
                throw error;
            }
        }
    }

}
