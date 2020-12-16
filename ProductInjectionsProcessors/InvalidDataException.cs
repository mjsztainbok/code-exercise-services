// <copyright file="InvalidDataException.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Processors
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>An exception which is thrown when the input data is invalid.</summary>
    public class InvalidDataException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="InvalidDataException" /> class.</summary>
        public InvalidDataException()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="InvalidDataException" /> class.</summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidDataException(string message)
            : base(message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="InvalidDataException" /> class.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference (<span class="keyword"><span class="languageSpecificText"><span class="cs">null</span><span class="vb">Nothing</span><span class="cpp">nullptr</span></span></span><span class="nu">a null reference (<span class="keyword">Nothing</span> in Visual Basic)</span> in Visual Basic) if no inner exception is specified.
        /// </param>
        public InvalidDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="InvalidDataException" /> class.</summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo">SerializationInfo</see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext">StreamingContext</see> that contains contextual information about the source or destination.</param>
        protected InvalidDataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
