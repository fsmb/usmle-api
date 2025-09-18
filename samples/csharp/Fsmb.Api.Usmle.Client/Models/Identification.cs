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
    /// <summary>Identity information/summary>
    public class Identification
    {
        /// <summary>SSN/summary>        
        [MaxLength(9)]
        public string Ssn { get; set; }

        /// <summary>Last 4 of the SSN/summary>        
        [MaxLength(4)]
        public string SsnLast4 { get; set; }

        /// <summary>NPI/summary>        
        [MaxLength(10)]
        public string Npi { get; set; }

        /// <summary>USMLE ID/summary>        
        [MaxLength(9)]
        public string UsmleId { get; set; }

        /// <summary>US citizen indicator/summary>
        [MaxLength(1)]
        public string IsUSCitizen { get; set; }

        /// <summary>Date of birth/summary>
        public DateTime BirthDate { get; set; }

        /// <summary>City of birth/summary>
        [Required(AllowEmptyStrings = false)]        
        [MaxLength(50)]
        public string BirthCity { get; set; }

        /// <summary>State/province of birth/summary>
        [Required]        
        public StateOrProvince BirthStateOrProvince { get; set; }

        /// <summary>Gender/summary>
        [Required(AllowEmptyStrings = false)]        
        [MaxLength(1)]
        public string Gender { get; set; }
    }
}