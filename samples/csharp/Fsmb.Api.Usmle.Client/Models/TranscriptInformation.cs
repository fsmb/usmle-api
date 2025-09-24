/*
 * Copyright © Federation of State Medical Boards
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
 * documentation files (the “Software”), to deal in the Software without restriction, including without limitation the
 * rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit
 * persons to whom the Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
 * WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
using System;

namespace Fsmb.Api.Usmle.Client.Models
{
    /// <summary>Transcript information</summary>
    public class TranscriptInformation
    {
        /// <summary>Determines if an FCVS profile was released</summary>
        public bool HasFcvsProfile { get; set; }

        /// <summary>Date the FCVS profile was released, if any</summary>
        public DateTime? FcvsReleaseDate { get; set; }

        /// <summary>Determines if a standalone transcript request was sent</summary>
        public bool HasTranscriptRequest { get; set; }

        /// <summary>Date the transcript request was sent, if any</summary>
        public DateTime? TranscriptSentDate { get; set; }
    }
}