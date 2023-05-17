﻿namespace AEPortal.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Should be ID, code,...
        /// </summary>
        public string Evidence { get; set; }
    }
}