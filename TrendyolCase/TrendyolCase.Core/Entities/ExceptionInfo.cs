using System;

namespace TrendyolCase.Core.Entities
{
    /// <summary>
    /// Keeps error messages
    /// </summary>
    public class ExceptionInfo : BaseEntity
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string RequestPath { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
