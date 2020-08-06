using Newtonsoft.Json;
using System.Collections.Generic;

namespace Utility.CustomException
{
    public class ErrorModel
    {
        /// <summary>
        /// get or set status code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// get or set error cause
        /// </summary>
        public string ErrorCause { get; set; }

        /// <summary>
        /// get or set error summary
        /// </summary>
        public IEnumerable<string> ErrorSummary { get; set; }

        /// <summary>
        /// override toString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
