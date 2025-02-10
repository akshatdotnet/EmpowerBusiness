using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Empower.Models.API
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public object? Result { get; set; }
        public Dictionary<string, List<string>> ValidationMessages { get; set; } = new Dictionary<string, List<string>>();
        public List<string> ErrorMessages { get; set; } = new List<string>();

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? DevError { get; set; }

        public Dictionary<string, List<string>> GetErrorsFromModelState(ModelStateDictionary modelState)
        {
            var errors = new Dictionary<string, List<string>>();

            foreach (var key in modelState.Keys)
            {
                var state = modelState[key];
                var errorMessages = state.Errors.Select(error => error.ErrorMessage).ToList();
                errors[key] = errorMessages;
            }
            return errors;
        }
    }
}
