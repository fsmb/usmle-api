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
    /// <summary>Physician transcript</summary>
    public class Transcript
    {
        /// <summary>USMLE ID</summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(8, MinimumLength = 8)]
        public string UsmleId { get; set; }

        /// <summary>FID</summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(9, MinimumLength = 9)]
        public string Fid { get; set; }

        /// <summary>Recipient information</summary>
        public Recipient Recipient { get; set; }

        /// <summary>Transcript information</summary>
        public TranscriptInformation Information { get; set; }

        /// <summary>Legal name</summary>
        public Name LegalName { get; set; }

        /// <summary>Other names</summary>
        public IEnumerable<Name> OtherNames { get; set; } = Enumerable.Empty<Name>();

        /// <summary>Identity information</summary>
        public Identification Identity { get; set; }

        /// <summary>Exam history</summary>
        public IEnumerable<Exam> Exams { get; set; } = Enumerable.Empty<Exam>();

        /// <summary>Exam history summary</summary>
        public ExamSummary ExamSummary { get; set; }

        /// <summary>Is there non-administrative irregular behavior?</summary>
        public bool HasNonAdministrativeIrregularBehavior { get; set; }

        /// <summary>Non-administrative irregular behavior</summary>
        public IEnumerable<IrregularBehavior> NonAdministrativeIrregularBehavior { get; set; } = Enumerable.Empty<IrregularBehavior>();

        /// <summary>Board action information</summary>
        public BoardActions BoardActions { get; set; }

        /// <summary>NBME information</summary>
        public NbmeInformation Nbme { get; set; }

        /// <summary>ECFMG information</summary>
        public EcfmgInformation Ecfmg { get; set; }
       
        /// <summary>FLEX information</summary>
        public FlexInformation Flex { get; set; }

        /// <summary>ICE information</summary>
        public IceInformation Ice { get; set; }

        /// <summary>USMLE information</summary>
        public UsmleInformation Usmle { get; set; }
    }
}