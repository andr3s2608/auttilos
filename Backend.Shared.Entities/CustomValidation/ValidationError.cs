using Newtonsoft.Json;

namespace Backend.Shared.Entities.CustomValidation
{
    /// <summary>
    /// ValidationError
    /// </summary>
    public class ValidationError
    {
        #region Attributes
        /// <summary>
        /// Field
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// ValidationError
        /// </summary>
        /// <param name="field"></param>
        /// <param name="message"></param>
        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
        #endregion
    }
}
