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
using System.ComponentModel.DataAnnotations;

namespace Fsmb.Api.Usmle.Client.Models
{
    /// <summary>Available transcripts summary request</summary>
    public class TranscriptSummaryRequest
    {
        /// <summary>Start date, inclusive</summary>
        public DateTime FromDate { get; set; }

        /// <summary>End date, inclusive</summary>
        public DateTime ToDate { get; set; }

        /// <summary>Field(s) to order by. (Default: `sentDate`)</summary>        
        public string OrderBy { get; set; }

        /// <summary>Number of items to skip</summary>
        [Range(0, Int32.MaxValue)]
        public int? Offset { get; set; }

        /// <summary>Number of items to return. (Default: 100)</summary>        
        [Range(1, Int32.MaxValue)]
        public int? Limit { get; set; }        
    }
}