using System.Collections.Generic;

namespace AWork.Core.Communication
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            Errors = new ResponseErrorsMessages();
        }

        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorsMessages Errors { get; set; }
    }

    public class ResponseErrorsMessages
    {
        public ResponseErrorsMessages()
        {
            Messages = new List<string>();
        }

        public List<string> Messages { get; set; }
    }
}
