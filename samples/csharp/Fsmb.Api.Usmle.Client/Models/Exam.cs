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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Fsmb.Api.Usmle.Client.Models
{
    /// <summary>Exam history/summary>
    public class Exam
    {
        /// <summary>Exam code</summary>
        [Required(AllowEmptyStrings = false)]        
        [StringLength(10)]
        public string ExamCode { get; set; }

        /// <summary>Exam description</summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string ExamDescription { get; set; }

        /// <summary>Date exam was taken</summary>
        public DateTime ExamDate { get; set; }

        /// <summary>Pass/fail status</summary>
        [StringLength(20)]
        public string PassFailStatus { get; set; }

        /// <summary>Date score is available</summary>
        public DateTime ScoreAvailableDate { get; set; }

        /// <summary>Score</summary>
        public int? Score { get; set; }

        /// <summary>Minimum passing score</summary>
        public int? MinimumPassScore { get; set; }

        /// <summary>Note</summary>
        [StringLength(1000)]
        public string Note { get; set; }

        /// <summary>Is there irregular behavior?</summary>
        public bool HasIrregularBehavior { get; set; }

        /// <summary>Irregular behavior</summary>
        public IEnumerable<IrregularBehavior> IrregularBehavior { get; set; } = Enumerable.Empty<IrregularBehavior>();
    }
}
