using System;
using System.Collections.Generic;

namespace TenderManagementSytem.Models
{
    public partial class TenderMaster
    {
        public int TenderId { get; set; }
        public string TenderTitle { get; set; }
        public string Organization { get; set; }
        public string Details { get; set; }
        public string TenderAddress { get; set; }
        public long Tendervalue { get; set; }
        public DateTime LastSubmissionDate { get; set; }
        public string Attachment { get; set; }
    }
}
