using System.Collections.Generic;

namespace ECommerce.Core.Models
{
    
    public class ValidationErrorResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public List<KeyValuePair<string, object>> PlaceHolderValues { get; set; }
        
    }
}