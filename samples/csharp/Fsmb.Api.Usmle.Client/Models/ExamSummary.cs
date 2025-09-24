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
namespace Fsmb.Api.Usmle.Client.Models
{
    /// <summary>Exam summary</summary>
    public class ExamSummary
    {
        /// <summary>USMLE Step 1 exam summary</summary>
        public ExamSummaryDetail Step1 { get; set; }

        /// <summary>USMLE Step 2 CS exam summary</summary>
        public ExamSummaryDetail Step2CS { get; set; }

        /// <summary>USMLE Step 2 CK exam summary</summary>
        public ExamSummaryDetail Step2CK { get; set; }

        /// <summary>USMLE Step 3 exam summary</summary>
        public ExamSummaryDetail Step3 { get; set; }
    }
}